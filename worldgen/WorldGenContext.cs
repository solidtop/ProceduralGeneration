using ProceduralGeneration.chunk;
using ProceduralGeneration.worldgen.biome;
using ProceduralGeneration.worldgen.config;
using ProceduralGeneration.worldgen.tree;
using ProceduralGeneration.worldgen.utils;

namespace ProceduralGeneration.worldgen
{
    public class WorldGenContext
    {
        public int Seed { get; }

        public WorldGenConfig Config { get; }
        public NoiseGroup Noises { get; }
        public SplineGroup Splines { get; }

        public BiomeType[] BiomeMap { get; set; } = new BiomeType[Chunk.Size.X];
        public int[] HeightMap { get; set; } = new int[Chunk.Size.X];

        public TreeManager Tree { get; }

        public WorldGenContext(int seed, WorldGenConfig config)
        {
            Seed = seed;
            Config = config;
            Noises = new(seed, config);
            Splines = new(config);
            Tree = new(this);
        }
    }
}
