using ProceduralGeneration.Common.Utilities;

namespace ProceduralGeneration.Features.WorldGen.Configurations
{
    public class CaveConfig : ConfigLoader<CaveConfig>
    {
        public NoiseConfig SpaghettiNoise { get; set; }
        public NoiseConfig RubbleNoise { get; set; }
        public NoiseConfig CheeseNoise { get; set; }
        public SplineConfig CheeseSpline { get; set; }
    }
}
