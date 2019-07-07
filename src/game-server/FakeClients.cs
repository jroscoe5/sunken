using System;
using character_system;
using turn_system;

namespace game_server
{
    class Program
    {
        static void Main(string[] args)
        {
            GameServer server = new GameServer(2);

            var jonnie = server.RegisterCharacter("jonnie").Result;
            var bridger = server.RegisterCharacter("bridger").Result;
            var kyle = server.RegisterCharacter("kyle").Result;
            Console.WriteLine(jonnie);
            Console.WriteLine(bridger);
            Console.WriteLine(server.RollInitiative(bridger).Result);
            Console.WriteLine(server.RollInitiative(jonnie).Result);


 
            Console.WriteLine(server.State);



        }
    }
}
