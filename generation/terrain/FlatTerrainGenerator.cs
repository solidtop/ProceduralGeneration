using Godot;
using ProceduralGeneration.chunk;
using ProceduralGeneration.tile;

namespace ProceduralGeneration.generation.terrain
{
    public class FlatTerrainGenerator : IWorldGenerator
    {
        public void Generate(Chunk chunk, WorldGeneratorContext context)
        {
            var tileWorldPos = new Vector2(
               (chunk.Position.X * Chunk.PixelSize.X) / Tile.Size,
               (chunk.Position.Y * Chunk.PixelSize.Y) / Tile.Size);

            for (int x = 0; x < Chunk.Size.X; x++)
            {
                for (int y = 0; y < Chunk.Size.Y; y++)
                {
                    var worldY = tileWorldPos.Y + y;

                    if (worldY > 100)
                    {
                        chunk.Tiles[x, y] = TileType.Stone;
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
