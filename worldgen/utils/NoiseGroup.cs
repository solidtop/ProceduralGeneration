using ProceduralGeneration.worldgen.config;

namespace ProceduralGeneration.worldgen.utils
{
    public class NoiseGroup(int seed, WorldGenConfig config)
    {
        public PerlinNoise Height { get; } = CreateNoise(seed, config.Terrain.Height.Noise);
        public PerlinNoise Dirt { get; } = CreateNoise(seed, config.Dirt.Noise);

        private static PerlinNoise CreateNoise(int seed, NoiseConfig config)
        {
            return new PerlinNoise(seed, config.Octaves, config.Frequency, config.Amplitude);
        }
    }
}
