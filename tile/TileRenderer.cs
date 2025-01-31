﻿using Godot;
using Terraria.chunk;

namespace Terraria.tile
{
    public partial class TileRenderer : Node
    {
        private TileMapLayer _terrainLayer;

        public override void _Ready()
        {
            _terrainLayer = GetNode<TileMapLayer>("../TerrainLayer");

            var controller = GetNode<ChunkController>("../ChunkController");
            controller.ChunkLoaded += OnChunkLoaded;
            controller.ChunkUnloaded += OnChunkUnloaded;
        }

        private void OnChunkLoaded(Chunk chunk)
        {
            Render(chunk);
        }

        private void OnChunkUnloaded(Chunk chunk)
        {
            Render(chunk, remove: true);
        }

        private void Render(Chunk chunk, bool remove = false)
        {
            var chunkWorldPos = chunk.Position * Chunk.Size;

            for (int x = 0; x < Chunk.Size.X; x++)
            {
                for (int y = 0; y < Chunk.Size.Y; y++)
                {
                    var tile = chunk.Tiles[x, y];

                    if (tile == TileType.Air)
                        continue;

                    var cellCoords = chunkWorldPos + new Vector2I(x, y);

                    if (remove)
                    {
                        _terrainLayer.EraseCell(cellCoords);
                    } 
                    else
                    {
                        var atlasCoords = Tile.GetMetadata(tile).AtlasCoords;
                        _terrainLayer.SetCell(cellCoords, 0, atlasCoords);
                    }
                }
            }
        }
    }
}
