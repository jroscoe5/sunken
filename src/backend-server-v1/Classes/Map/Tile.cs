using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sunken.Character;

namespace Sunken.Map
{
    public enum TileType
    {
        Spawnable,
        Playable,
        Wall,
        Hole
    };

    public class Tile
    {
        public TileType Type { get; protected set; }
        public int Elevation { get; protected set; }
        public GameCharacter Character { get; set; }
        public Tile(TileType type, int elevation = 0)
        {
            Type = type;
            Elevation = elevation;
        }
    }
}
