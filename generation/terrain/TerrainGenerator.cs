using Terraria.chunk;
using Terraria.tile;

namespace Terraria.generation.terrain
{
    public class TerrainGenerator : IWorldGenerator
    {
        public void Generate(Chunk chunk, WorldGeneratorContext context)
        {
            for (int x = 0; x < Chunk.Size.X; x++)
            {
                for (int y = 0; y < Chunk.Size.Y; y++)
                {
                    chunk.Tiles[x, y] = TileType.Stone;
                }
            }
        }
    }
}
