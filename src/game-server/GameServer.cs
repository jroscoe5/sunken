using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using turn_system;
using character_system;
using System.Threading.Tasks;

namespace game_server
{
    public enum GameState
    {
        Setup,
        InitiativeRolling,
        Combat,
        Looting,
        DirectionChoice
    };

    class GameServer
    {
        private TurnManager turnManager;

        private int maxCount, currCount;

        private List<GameCharacter> gameCharacters;
        private Mutex characterLock;
        private Mutex stateLock;

        public string ServerId;
        public GameState State { get; private set; }

        public GameServer(int numPlayers)
        {
            turnManager = new TurnManager();
            gameCharacters = new List<GameCharacter>();
            characterLock = new Mutex();
            stateLock = new Mutex();
            ServerId = Guid.NewGuid().ToString();
            State = GameState.Setup;
            maxCount = numPlayers;
            currCount = 0;
        }

        public async Task<string> RegisterCharacter(string username)
        {
            return await Task.Run(() =>
            {
                lock (stateLock)
                {
                    if (State != GameState.Setup || currCount == maxCount)
                        return null;
                    currCount++;
                    // Once all players have registered, change game state
                    if (currCount == maxCount)
                    {
                        State = GameState.InitiativeRolling;
                        currCount = 0;
                    }
                }
                GameCharacter character = new GameCharacter(username);
                Console.WriteLine(character.ToJson());
                lock (characterLock)
                {
                    gameCharacters.Add(character);     
                }
                return character.Id;
            });
        }

        public async Task<int> RollInitiative(string id)
        {
            return await Task.Run(() =>
            {
                lock (stateLock)
                {
                    if (State != GameState.InitiativeRolling || currCount == maxCount)
                        return -1;
                    currCount++;
                }
                // gameCharacters should be safe from modifications atm
                GameCharacter character = gameCharacters.Find(x => x.Id == id);
                if (character == null)
                    return -1;
                character.Stats.Modify(initiative: character.Dice.RollOne()); // check for any additional modifiers here

                lock (stateLock)
                {
                    // Once all players have rolled, change game state
                    if (currCount == maxCount)
                    {
                        State = GameState.Combat;
                        currCount = 0;

                        lock (characterLock)
                        {
                            gameCharacters.Sort((l, r) =>
                            {
                                if (l.Stats.Initiative == r.Stats.Initiative)
                                {
                                    if (l.Dice.RollOne() > 3)
                                        return -1;
                                }
                                return r.Stats.Initiative - l.Stats.Initiative;
                            });
                        }
                        turnManager.Initialize(gameCharacters.ToArray());
                    }
                }
                return character.Stats.Initiative;
            });
        }

    }
}
