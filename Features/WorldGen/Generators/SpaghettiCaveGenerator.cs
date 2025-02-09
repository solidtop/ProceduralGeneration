using System;
using ProceduralGeneration.Features.WorldGen.Chunks;
using ProceduralGeneration.Features.WorldGen.Contexts;
using ProceduralGeneration.Features.WorldGen.Tiles;

namespace ProceduralGeneration.Features.WorldGen.Generators
{
    public class SpaghettiCaveGenerator : IWorldGenerator
    {
        public void Generate(Chunk chunk, WorldGenContext context)
        {
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

                    var rubble = Math.Abs(context.Noises.SpaghettiRubble.Sample2D(worldX, worldY));
                    var threshold = context.Config.Cave.RubbleNoise.Threshold;
                    var allowRubble = worldY >= height + 40;

                    if (allowRubble && rubble < threshold)
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
