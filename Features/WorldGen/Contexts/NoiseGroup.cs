using ProceduralGeneration.Common.Utilities;
using ProceduralGeneration.Features.WorldGen.Configurations;

namespace ProceduralGeneration.Features.WorldGen.Contexts
{
    public class NoiseGroup(int seed, WorldGenConfig config)
    {
        public PerlinNoise Temperature { get; } = CreateNoise(seed, config.Biome.TemperatureNoise);
        public PerlinNoise Humidity { get; } = CreateNoise(seed, config.Biome.HumidityNoise);
        public PerlinNoise Height { get; } = CreateNoise(seed, config.Terrain.HeightNoise);
        public PerlinNoise Dirt { get; } = CreateNoise(seed, config.Dirt.Noise);
        public PerlinNoise CheeseCave { get; } = CreateNoise(seed, config.Cave.CheeseNoise);
        public PerlinNoise SpaghettiCave { get; } = CreateNoise(seed, config.Cave.SpaghettiNoise);
        public PerlinNoise SpaghettiRubble { get; } = CreateNoise(seed, config.Cave.RubbleNoise);
        public PerlinNoise TreeDensity { get; } = CreateNoise(seed, config.Tree.DensityNoise);

        private static PerlinNoise CreateNoise(int seed, NoiseConfig config)
        {
            return new(seed, config.Octaves, config.Frequency, config.Amplitude);
        }
    }
}
