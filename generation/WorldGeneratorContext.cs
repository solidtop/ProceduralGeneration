using ProceduralGeneration.generation.terrain;
using ProceduralGeneration.generation.utils;

namespace ProceduralGeneration.generation
{
    public class WorldGeneratorContext(int seed, WorldSettings world, TerrainSettings terrain)
    {
        public int Seed { get; } = seed;

        public WorldSettings World { get; } = world;
        public TerrainSettings Terrain { get; } = terrain;

        public PerlinNoise HeightNoise { get; } = new(seed, terrain.Octaves, terrain.Frequency);
        public Spline HeightSpline { get; } = new(terrain.HeightPoints);
    }
}
