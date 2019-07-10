using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Sunken.Character;
using Sunken.RandomGeneration;
using Sunken.TurnManagement;

namespace Sunken.Server
{
    static public class ServerManager
    {
        private static readonly Dictionary<string, GameServer> servers;
        private static readonly Mutex serverLock;
        
        static ServerManager()
        {
            servers = new Dictionary<string, GameServer>();
            serverLock = new Mutex();
        }

        public static async Task<string> CreateNewGame(int numMortals)
        {
            return await Task.Run(() =>
            {
                if (numMortals <= 0) return null;
                string serverId = Guid.NewGuid().ToString();
                lock (serverLock)
                {
                    servers.Add(serverId, new GameServer(numMortals));
                }
                return serverId;
            });
        }

        public static async Task<string> GetServerStatus(string id)
        {
            return await Task.Run(() =>
            {
                try
                {
                    lock (serverLock)
                    {
                        return servers[id].GetServerState().Result;
                    }
                }
                catch (Exception exc)
                {
                    return exc.ToString();
                }
            });
        }

        public static async Task<string> RegisterUser(string serverId, string username)
        {
            return await Task.Run(() =>
            {
                try
                {
                    GameServer server;
                    lock (serverLock)
                    {
                        server = servers[serverId];
                    }
                    return server.RegisterUsername(username).Result;
                }
                catch (Exception exc)
                {
                    return exc.ToString();
                }
            });
        }

        public static async Task<string> DumpInfo()
        {
            return await Task.Run(() =>
            {
                string ret = "";
                lock (serverLock)
                {
                    foreach(var pair in servers)
                    {
                        ret += "serverId: " + pair.Key + "\n" + pair.Value.DumpInfo() + "\n";
                    }
                }
                return ret;
            });
        }
    }
}
