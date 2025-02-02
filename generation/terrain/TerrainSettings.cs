using System.IO;
using System.Numerics;
using Newtonsoft.Json;

namespace ProceduralGeneration.generation.terrain
{
    public class TerrainSettings
    {
        public int Octaves { get; set; }
        public float Frequency { get; set; }
        public Vector2[] HeightPoints { get; set; }

        public static TerrainSettings Load(string filePath)
        {
            var json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<TerrainSettings>(json);
        }
    }
}
