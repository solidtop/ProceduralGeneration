using ProceduralGeneration.worldgen.config;

namespace ProceduralGeneration.worldgen.tree
{
    public class TreeConfig : ConfigLoader<TreeConfig>
    {
        public int RegionSize { get; set; }
        public int MinTreeCount { get; set; }
        public int MaxTreeCount { get; set; }
        public NoiseConfig DensityNoise { get; set; }
    }
}
