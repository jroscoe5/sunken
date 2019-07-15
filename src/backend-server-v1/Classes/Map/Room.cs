using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sunken.Character;

namespace Sunken.Map
{
    public class Room
    {
        protected Tile[,] board;
        
        public Room()
        {
            board = GenerateRoom();
        }

        public bool SpawnCharacter(Tuple<int,int> pos, GameCharacter character)
        {
            if (board[pos.Item1, pos.Item2].Type != TileType.Spawnable || 
                board[pos.Item1, pos.Item2].Character != null)
                return false;
            board[pos.Item1, pos.Item2].Character = character;
            return true;
        }

        public bool MoveCharacter(Tuple<int,int> init, Tuple<int,int> fin)
        {
            GameCharacter character = board[init.Item1, init.Item2].Character;
            if ( character == null || board[fin.Item1, fin.Item2].Character != null)
                return false;
            board[fin.Item1, fin.Item2].Character = character;
            return true;
        }

        public override string ToString()
        {
            string ret = "";
            for (int i = 0; i < 10; i++)
            {
                ret += "[ ";
                for (int j = 0; j < 10; j++)
                {
                    ret += "{ ";
                    if (board[i, j].Character != null)
                    {
                        ret += board[i, j].Character.Id;
                    }
                    else
                    {
                        ret += board[i, j].Type.ToString() + " " + board[i, j].Elevation;
                    }
                    ret += " }";
                }
                ret += " ]\n";
            }
            return ret;
        }

        //TODO: Implement this
        protected virtual Tile[,] GenerateRoom()
        {
            Tile[,] room = new Tile[10, 10];
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 10; j++)
                    room[i, j] = new Tile(TileType.Spawnable);
            for (int i = 0; i < 10; i++)
            {
                room[4, i] = new Tile(TileType.Playable, 1);
                room[5, i] = new Tile(TileType.Playable, 2);
                room[6, i] = new Tile(TileType.Playable, 1);
            }
            room[5, 5] = new Tile(TileType.Wall);
            for (int i = 7; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    room[i, j] = new Tile(TileType.Playable);
            return room;
        }
    }
}
