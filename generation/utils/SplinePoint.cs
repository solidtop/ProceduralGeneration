using System.Text.Json.Serialization;

namespace ProceduralGeneration.generation.utils
{
    public class SplinePoint
    {
        [JsonPropertyName("x")]
        public float X { get; set; }

        [JsonPropertyName("y")]
        public float Y { get; set; }
    }
}
