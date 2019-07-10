using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Sunken.TurnManagement;
using Sunken.Character;

namespace Sunken.Server
{
    public enum GameState
    {
        WaitingForUsernames,
        RoomGeneration,
        InitiativeRolling,
        TurnTaking,
        Looting,
        DirectionChoice
    };

    class GameServer
    {
        private readonly Mutex stateLock;
        private readonly Mutex characterLock;
        private GameState state;

        private List<GameCharacter> characters;

        private readonly int numMortals;

        public GameServer(int numMortals)
        {
            stateLock = new Mutex();
            characterLock = new Mutex();
            characters = new List<GameCharacter>();
            state = GameState.WaitingForUsernames;
            this.numMortals = numMortals;
        }

        public string DumpInfo()
        {
            string ret = "";
            lock (characterLock)
            {
                foreach (GameCharacter character in characters)
                {
                    ret += character.ToJson() + "\n";
                }
            }
            return ret;
        }

        public async Task<string> GetServerState()
        {
            return await Task.Run(() =>
            {
                return state.ToString();
            });
        }

        public async Task<string> RegisterUsername(string username)
        {
            return await Task.Run(() => {
                lock (stateLock) {
                    if (state != GameState.WaitingForUsernames)
                        return new Exception("Invalid game state").ToString();
                    lock (characterLock)
                    {
                        if (characters.Count < numMortals)
                        {
                            GameCharacter character = new GameCharacter(name: username);
                            characters.Add(character);
                            if (characters.Count == numMortals)
                                state = GameState.RoomGeneration;
                            // Once the last mortal registers, generate the first level.
                            Task.Run(GenerateLevel);
                            return character.Id;
                        }          
                    }
                }
                return new Exception("Game is full").ToString();
            });
        }

        private async Task GenerateLevel()
        {
            await Task.Run(() =>
            {

            });
        }
    }
}
