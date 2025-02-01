using ProceduralGeneration.generation.terrain;
using ProceduralGeneration.generation.utils;

namespace Terraria.generation
{
    public class WorldGeneratorContext(int seed, TerrainSettings terrain)
    {
        public int Seed { get; } = seed;

        public TerrainSettings Terrain { get; } = terrain;

        public PerlinNoise HeightNoise { get; } = new(seed, terrain.Octaves, terrain.Frequency);
        public Spline HeightSpline { get; } = new(terrain.HeightPoints);
    }
}
