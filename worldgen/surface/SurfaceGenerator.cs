using ProceduralGeneration.chunk;
using ProceduralGeneration.tile;
using ProceduralGeneration.worldgen.biome;

namespace ProceduralGeneration.worldgen.surface
{
    public class SurfaceGenerator : IWorldGenerator
    {
        public void Generate(Chunk chunk, WorldGenContext context)
        {
            var chunkWorldPos = chunk.Position * Chunk.Size;

            for (int x = 0; x < Chunk.Size.X; x++)
            {
                var worldX = chunkWorldPos.X + x;
                var biome = context.BiomeMap[x];
                var height = context.HeightMap[x];

                // Placeholder
                var surfaceTile = biome switch
                {
                    BiomeType.Desert => TileType.Sand,
                    BiomeType.Tundra => TileType.Snow,
                    _ => TileType.Grass,
                };

                for (int y = 0; y < Chunk.Size.Y; y++)
                {
                    if (chunk.Tiles[x, y] != TileType.Dirt)
                        continue;

                    var worldY = chunkWorldPos.Y + y;

                    if (worldY == height)
                    {
                        chunk.Tiles[x, y] = surfaceTile; 
                        context.SurfaceTileMap[x] = surfaceTile;
                    }
                }
            }
        }
    }
}
