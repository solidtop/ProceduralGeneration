using Godot;
using ProceduralGeneration.chunk;
using ProceduralGeneration.tile;

namespace ProceduralGeneration.worldgen.terrain.dirt
{
    public class DirtGenerator : IWorldGenerator
    {
        public void Generate(Chunk chunk, WorldGenContext context)
        {
            var tileWorldPos = new Vector2(
               (chunk.Position.X * Chunk.PixelSize.X) / Tile.Size,
               (chunk.Position.Y * Chunk.PixelSize.Y) / Tile.Size);

            for (int x = 0; x < Chunk.Size.X; x++)
            {
                var worldX = tileWorldPos.X + x;
                var height = context.HeightMap[x];

                for (int y = 0; y < Chunk.Size.Y; y++)
                {
                    var worldY = tileWorldPos.Y + y;

                    var noiseValue = context.Noises.Dirt.Sample2D(worldX, worldY);
                    var threshold = context.Splines.Dirt.Interpolate(worldY);

                    if (worldY > height && noiseValue > threshold)
                    {
                        chunk.Tiles[x, y] = TileType.Dirt;
                    }
                }
            }
        }
    }
}
