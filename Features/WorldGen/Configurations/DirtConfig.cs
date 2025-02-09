using ProceduralGeneration.Common.Utilities;

namespace ProceduralGeneration.Features.WorldGen.Configurations
{
    public class DirtConfig : ConfigLoader<DirtConfig>
    {
        public NoiseConfig Noise { get; set; }
        public SplineConfig Spline { get; set; }
    }
}
