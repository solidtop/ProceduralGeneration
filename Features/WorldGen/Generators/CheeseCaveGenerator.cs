using ProceduralGeneration.Features.WorldGen.Chunks;
using ProceduralGeneration.Features.WorldGen.Contexts;
using ProceduralGeneration.Features.WorldGen.Tiles;

namespace ProceduralGeneration.Features.WorldGen.Generators
{
    public class CheeseCaveGenerator : IWorldGenerator
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

                    if (tile == TileType.Air)
                        continue;

                    var worldY = chunkWorldPos.Y + y;

                    var noiseValue = context.Noises.CheeseCave.Sample2D(worldX, worldY);
                    var hollowness = context.Splines.CheeseCave.Interpolate(worldY);

                    if (noiseValue > hollowness)
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
