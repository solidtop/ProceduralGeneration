using ProceduralGeneration.chunk;
using ProceduralGeneration.tile;

namespace ProceduralGeneration.worldgen.dirt
{
    public class DirtGenerator : IWorldGenerator
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
                    var worldY = chunkWorldPos.Y + y;

                    var noiseValue = context.Noises.Dirt.Sample2D(worldX, worldY);
                    var threshold = context.Splines.Dirt.Interpolate(worldY);

                    if (worldY >= height && noiseValue > threshold)
                    {
                        chunk.Tiles[x, y] = TileType.Dirt;

                        if (worldY == height)
                        {
                            context.SurfaceTileMap[x] = TileType.Dirt;
                        }
                    }
                }
            }
        }
    }
}
