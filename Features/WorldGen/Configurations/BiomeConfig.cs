using ProceduralGeneration.Common.Utilities;

namespace ProceduralGeneration.Features.WorldGen.Configurations
{
    public class BiomeConfig : ConfigLoader<BiomeConfig>
    {
        public NoiseConfig TemperatureNoise { get; set; }
        public NoiseConfig HumidityNoise { get; set; }
    }
}
