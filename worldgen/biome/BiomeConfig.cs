using System.IO;
using Newtonsoft.Json;
using ProceduralGeneration.worldgen.config;

namespace ProceduralGeneration.worldgen.biome
{
    public class BiomeConfig
    {
        public NoiseConfig TemperatureNoise { get; set; }
        public NoiseConfig HumidityNoise { get; set; }

        public static BiomeConfig Load(string filePath)
        {
            var json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<BiomeConfig>(json);
        }
    }
}
