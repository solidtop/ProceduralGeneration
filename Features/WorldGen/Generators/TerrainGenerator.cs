using ProceduralGeneration.Features.WorldGen.Chunks;
using ProceduralGeneration.Features.WorldGen.Contexts;
using ProceduralGeneration.Features.WorldGen.Tiles;

namespace ProceduralGeneration.Features.WorldGen.Generators
{
    public class TerrainGenerator : IWorldGenerator
    {
        public void Generate(Chunk chunk, WorldGenContext context)
        {
            var chunkWorldPos = chunk.Position * Chunk.Size;

            var defaultTile = context.Config.Terrain.DefaultTile;
            var defaultFluid = context.Config.Terrain.DefaultFluid;

            for (int x = 0; x < Chunk.Size.X; x++)
            {
                var worldX = chunkWorldPos.X + x;

                var noiseValue = context.Noises.Height.Sample1D(worldX);

                var seaLevel = context.Definitions.World.SeaLevel;
                var height = (int)context.Splines.Height.Interpolate(noiseValue);

                context.HeightMap[x] = height;

                for (int y = 0; y < Chunk.Size.Y; y++)
                {
                    var worldY = chunkWorldPos.Y + y;

                    if (worldY >= height)
                    {
                        chunk.Tiles[x, y] = defaultTile;

                        if (worldY == height)
                        {
                            context.SurfaceTileMap[x] = defaultTile;
                        }
                    }
                    else if (worldY >= seaLevel)
                    {
                        chunk.Tiles[x, y] = defaultFluid;

                        if (worldY == height)
                        {
                            context.SurfaceTileMap[x] = defaultFluid;
                        }
                    }
                    else
                    {
                        chunk.Tiles[x, y] = TileType.Air;
                    }
                }
            }
        }
    }
}
