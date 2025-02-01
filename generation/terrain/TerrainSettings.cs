using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using ProceduralGeneration.generation.utils;

namespace ProceduralGeneration.generation.terrain
{
    public class TerrainSettings
    {
        [JsonPropertyName("octaves")]
        public int Octaves { get; set; }
        
        [JsonPropertyName("frequency")]
        public float Frequency { get; set; }

        [JsonPropertyName("heightPoints")]
        public SplinePoint[] HeightPoints { get; set; }

        public static TerrainSettings Load(string filePath)
        {
            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<TerrainSettings>(json);
        }
    }
}
