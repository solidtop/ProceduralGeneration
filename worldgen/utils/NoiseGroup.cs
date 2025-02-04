﻿using ProceduralGeneration.worldgen.config;

namespace ProceduralGeneration.worldgen.utils
{
    public class NoiseGroup(int seed, WorldGenConfig config)
    {
        public PerlinNoise Temperature { get; } = CreateNoise(seed, config.Biome.TemperatureNoise);
        public PerlinNoise Humidity { get; } = CreateNoise(seed, config.Biome.HumidityNoise);
        public PerlinNoise Height { get; } = CreateNoise(seed, config.Terrain.Height.Noise);
        public PerlinNoise Dirt { get; } = CreateNoise(seed, config.Dirt.Noise);

        private static PerlinNoise CreateNoise(int seed, NoiseConfig config)
        {
            return new(seed, config.Octaves, config.Frequency, config.Amplitude);
        }
    }
}
