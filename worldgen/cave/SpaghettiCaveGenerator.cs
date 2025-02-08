using System;
using ProceduralGeneration.chunk;
using ProceduralGeneration.tile;
using ProceduralGeneration.worldgen.utils;

namespace ProceduralGeneration.worldgen.cave
{
    public class SpaghettiCaveGenerator : IWorldGenerator
    {
        private PerlinNoise _rubbleNoise;
        private const float RubbleThreshold = 0.3f;

        public void Generate(Chunk chunk, WorldGenContext context)
        {
            _rubbleNoise ??= new(context.Seed, 4, 1);

            var chunkWorldPos = chunk.Position * Chunk.Size;

            for (int x = 0; x < Chunk.Size.X; x++)
            {
                var worldX = chunkWorldPos.X + x;
                var height = context.HeightMap[x];

                for (int y = 0; y < Chunk.Size.Y; y++)
                {
                    var tile = chunk.Tiles[x, y];

                    if (tile == TileType.Air || tile == TileType.Water)
                        continue;

                    var worldY = chunkWorldPos.Y + y;

                    var rubble = Math.Abs(_rubbleNoise.Sample2D(worldX, worldY));
                    var allowRubble = worldY >= height + 40;

                    if (allowRubble && rubble < RubbleThreshold)
                        continue;

                    var noiseValue = Math.Abs(context.Noises.SpaghettiCave.Sample2D(worldX, worldY));
                    var thickness = context.Config.Cave.SpaghettiNoise.Threshold;

                    if (noiseValue < thickness)
                    {
                        chunk.Tiles[x, y] = TileType.Air;

                        if (worldY == height)
                        {
                            context.SurfaceTileMap[x] = TileType.Air;
                        }
                    }
                }
            }
        }
    }
}
