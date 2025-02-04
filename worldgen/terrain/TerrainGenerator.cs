using Godot;
using ProceduralGeneration.chunk;
using ProceduralGeneration.tile;

namespace ProceduralGeneration.worldgen.terrain
{
    public class TerrainGenerator : IWorldGenerator
    {
        public void Generate(Chunk chunk, WorldGenContext context)
        {
            var tileWorldPos = new Vector2(
               (chunk.Position.X * Chunk.PixelSize.X) / Tile.Size,
               (chunk.Position.Y * Chunk.PixelSize.Y) / Tile.Size);

            var defaultTile = context.Config.Terrain.DefaultTile;
            var defaultFluid = context.Config.Terrain.DefaultFluid;

            for (int x = 0; x < Chunk.Size.X; x++)
            {
                var worldX = tileWorldPos.X + x;

                var noiseValue = context.Noises.Height.Sample1D(worldX);

                var seaLevel = context.Config.World.SeaLevel;
                var height = (int)context.Splines.Height.Interpolate(noiseValue);

                context.HeightMap[x] = height;

                for (int y = 0; y < Chunk.Size.Y; y++)
                {
                    var worldY = tileWorldPos.Y + y;

                    if (worldY > height)
                    {
                        chunk.Tiles[x, y] = defaultTile;
                    }
                    else if (worldY >= seaLevel)
                    {
                        chunk.Tiles[x, y] = defaultFluid;
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
