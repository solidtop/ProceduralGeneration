using ProceduralGeneration.worldgen.config;

namespace ProceduralGeneration.worldgen.cave
{
    public class CaveConfig : ConfigLoader<CaveConfig>
    {
        public SplineNoiseConfig Cheese {  get; set; }
        public NoiseConfig SpaghettiNoise {  get; set; }
    }
}
