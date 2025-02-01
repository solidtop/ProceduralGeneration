using Godot;
using Terraria.chunk;
using Terraria.tile;

namespace Terraria.generation.terrain
{
    public class TerrainGenerator : IWorldGenerator
    {
        public void Generate(Chunk chunk, WorldGeneratorContext context)
        {
            var tileWorldPos = new Vector2(
               (chunk.Position.X * Chunk.PixelSize.X) / Tile.Size,
               (chunk.Position.Y * Chunk.PixelSize.Y) / Tile.Size);

            for (int x = 0; x < Chunk.Size.X; x++)
            {
                var worldX = tileWorldPos.X + x;

                var noiseValue = context.HeightNoise.Sample1D(worldX);
                var height = context.HeightSpline.Interpolate(noiseValue);

                for (int y = 0; y < Chunk.Size.Y; y++)
                {
                    var worldY = tileWorldPos.Y + y;

                    if (worldY > height)
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
