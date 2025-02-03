using ProceduralGeneration.chunk;
using ProceduralGeneration.worldgen.utils;

namespace ProceduralGeneration.worldgen
{
    public class WorldGenContext(int seed, WorldGenConfig config)
    {
        public int Seed { get; } = seed;

        public WorldGenConfig Config { get; } = config;
        public NoiseGroup Noises { get; } = new(seed, config);
        public SplineGroup Splines { get; } = new(config);

        public int[] HeightMap { get; set; } = new int[Chunk.Size.X];
    }
}
