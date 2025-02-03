namespace ProceduralGeneration.worldgen.config
{
    public class NoiseConfig
    {
        public int Octaves { get; set; }
        public float Frequency { get; set; }
        public float Amplitude { get; set; }
        public float Persistence { get; set; }
        public float Lacunarity { get; set; }
        public float? Threshold { get; set; }
    }
}
