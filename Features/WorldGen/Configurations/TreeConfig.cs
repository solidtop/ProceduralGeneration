using ProceduralGeneration.Common.Utilities;

namespace ProceduralGeneration.Features.WorldGen.Configurations
{
    public class TreeConfig : ConfigLoader<TreeConfig>
    {
        public int RegionSize { get; set; }
        public int MinTreeCount { get; set; }
        public int MaxTreeCount { get; set; }
        public NoiseConfig DensityNoise { get; set; }
    }
}
