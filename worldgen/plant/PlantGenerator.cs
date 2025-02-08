using System;
using Godot;
using ProceduralGeneration.chunk;
using ProceduralGeneration.tile;
using ProceduralGeneration.worldgen.utils;

namespace ProceduralGeneration.worldgen.plant
{
    public class PlantGenerator : IWorldGenerator
    {
        private PerlinNoise _densityNoise;

        public void Generate(Chunk chunk, WorldGenContext context)
        {
            _densityNoise ??= new(context.Seed, 3, 6);

            var chunkWorldPos = chunk.Position * Chunk.Size;

            for (int x = 0; x < Chunk.Size.X; x++)
            {
                var worldX = chunkWorldPos.X + x;
                var height = context.HeightMap[x];
                var surfaceTile = context.SurfaceTileMap[x];

                var density = _densityNoise.Sample1D(worldX);

                if (density < 0.2f)
                    continue;

                var plantTile = new Random().Next(100) < 10 ?  TileType.RoseFlower : TileType.GrassPlant;

                for (int y = 0; y < Chunk.Size.Y; y++)
                {
                    if (surfaceTile != TileType.Grass || chunk.Tiles[x, y] != TileType.Air)
                        continue;

                    var worldY = chunkWorldPos.Y + y;

                    if (worldY == height - 1)
                    {
                        chunk.Tiles[x, y] = plantTile;
                    }
                }
            }
        }
    }
}
