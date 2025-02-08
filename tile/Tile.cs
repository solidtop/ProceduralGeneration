using System.Collections.Generic;
using Godot;

namespace ProceduralGeneration.tile
{
    public readonly struct TileMetadata(Vector2I atlasCoords)
    {
        public Vector2I AtlasCoords { get; } = atlasCoords;
    }

    public class Tile
    {
        public const int Size = 16;

        private static readonly Dictionary<TileType, TileMetadata> Metadata = new()
        {
            { TileType.Grass, new TileMetadata(new(0, 0)) },
            { TileType.Dirt, new TileMetadata(new(1, 0)) },
            { TileType.Stone, new TileMetadata(new(2, 0)) },
            { TileType.Water, new TileMetadata(new(3, 0)) },
            { TileType.Sand, new TileMetadata(new(4, 0)) },
            { TileType.Snow, new TileMetadata(new(5, 0)) },
            { TileType.OakLog, new TileMetadata(new(6, 0)) },
            { TileType.OakLeaves, new TileMetadata(new(7, 0)) },  
            { TileType.SpruceLog, new TileMetadata(new(3, 2)) },
            { TileType.SpruceLeaves, new TileMetadata(new(1, 2)) },
            { TileType.BirchLog, new TileMetadata(new(2, 2)) },
            { TileType.BirchLeaves, new TileMetadata(new(0, 2)) },
            { TileType.GrassPlant, new TileMetadata(new(2, 1)) },
            { TileType.RoseFlower, new TileMetadata(new(5, 1)) },
        };

        public static TileMetadata GetMetadata(TileType type)
        {
            return Metadata[type];
        }
    }
}
