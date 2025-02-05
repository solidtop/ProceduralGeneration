using ProceduralGeneration.worldgen.config;

namespace ProceduralGeneration.worldgen.biome
{
    public class BiomeConfig : ConfigLoader<BiomeConfig>
    {
        public NoiseConfig TemperatureNoise { get; set; }
        public NoiseConfig HumidityNoise { get; set; }
    }
}
