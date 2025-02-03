using System.IO;
using Newtonsoft.Json;
using ProceduralGeneration.worldgen.config;

namespace ProceduralGeneration.worldgen.terrain.dirt
{
    public class DirtConfig
    {
        public NoiseConfig Noise {  get; set; }
        public SplineConfig Spline { get; set; }

        public static DirtConfig Load(string filePath)
        {
            var json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<DirtConfig>(json);
        }
    }
}
