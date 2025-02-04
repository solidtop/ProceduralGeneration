﻿using System.Collections.Generic;
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
            { TileType.Grass, new TileMetadata(new Vector2I(0, 0)) },
            { TileType.Dirt, new TileMetadata(new Vector2I(1, 0)) },
            { TileType.Stone, new TileMetadata(new Vector2I(2, 0)) },
            { TileType.Water, new TileMetadata(new Vector2I(3, 0)) },
            { TileType.Sand, new TileMetadata(new Vector2I(4, 0)) },
            { TileType.Snow, new TileMetadata(new Vector2I(5, 0)) },
        };

        public static TileMetadata GetMetadata(TileType type)
        {
            return Metadata[type];
        }
    }
}
