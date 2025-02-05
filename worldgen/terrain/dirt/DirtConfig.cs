using ProceduralGeneration.worldgen.config;

namespace ProceduralGeneration.worldgen.terrain.dirt
{
    public class DirtConfig : ConfigLoader<DirtConfig>
    {
        public NoiseConfig Noise {  get; set; }
        public SplineConfig Spline { get; set; }
    }
}
