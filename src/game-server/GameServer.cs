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

        private List<GameCharacter> gameCharacters;
        private Mutex characterLock;
        private Mutex stateLock;

        public string ServerId;
        public GameState State { get; private set; }

        public GameServer()
        {
            turnManager = new TurnManager();
            gameCharacters = new List<GameCharacter>();
            characterLock = new Mutex();
            ServerId = Guid.NewGuid().ToString();
            State = GameState.Setup;
        }

        /// <summary>
        /// Creates a new character on the server
        /// </summary>
        /// <param name="name">The characters display name</param>
        /// <returns>The characters Id for future references</returns>
        public async Task<string> AddCharacter(string name)
        {
            lock (stateLock)
            {
                if (State != GameState.Setup) throw new Exception("wrong game state");
            }
            GameCharacter character = new GameCharacter(name);
            lock (characterLock)
            {
               gameCharacters.Add(character);
            }
            return character.Id;
        }

        /// <summary>
        /// Rolls initative for a given character
        /// </summary>
        /// <param name="id">Character's Id</param>
        /// <returns></returns>
        public async Task<int> RollInitiative(string id)
        {
            lock (stateLock)
            {
                if (State != GameState.InitiativeRolling) throw new Exception("wrong game state");
            }
            GameCharacter character = GetPlayerById(id);
            character.Initiative = character.Dice.RollOne();
            return character.Initiative;
        }

        /// <summary>
        /// Updates the current state of the game
        /// </summary>
        /// <param name="serverId">Server's Id</param>
        /// <param name="state">Target state to change to</param>
        /// <returns>If state was changed successfully</returns>
        public async Task<bool> ChangeState(string serverId, int state)
        {
            if (serverId != ServerId) return false;
            lock (stateLock)
            {
                try
                {
                    State = (GameState) state;
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        private GameCharacter GetPlayerById(string id)
        {
            lock (characterLock)
            {
                return gameCharacters.Find(x => x.Id == id);
            }
        }
    }
}
