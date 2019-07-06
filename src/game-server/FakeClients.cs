using System;
using character_system;
using turn_system;

namespace game_server
{
    class Program
    {
        static void Main(string[] args)
        {
            GameServer server = new GameServer();
            string player1 = server.AddCharacter("jonnie").Result;
            string player2 = server.AddCharacter("bridger").Result;

            Console.WriteLine(player1);
            Console.WriteLine(player2);


        }
    }
}
