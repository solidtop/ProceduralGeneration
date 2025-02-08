using ProceduralGeneration.chunk;
using ProceduralGeneration.tile;
using ProceduralGeneration.worldgen.biome;
using ProceduralGeneration.worldgen.config;
using ProceduralGeneration.worldgen.definitions;
using ProceduralGeneration.worldgen.tree;
using ProceduralGeneration.worldgen.utils;

namespace ProceduralGeneration.worldgen
{
    public class WorldGenContext
    {
        public int Seed { get; }

        public WorldGenConfig Config { get; }
        public Definitions Definitions { get; }
        public NoiseGroup Noises { get; }
        public SplineGroup Splines { get; }

        public BiomeType[] BiomeMap { get; set; } = new BiomeType[Chunk.Size.X];
        public int[] HeightMap { get; set; } = new int[Chunk.Size.X];
        public TileType[] SurfaceTileMap { get; set; } = new TileType[Chunk.Size.X];

        public TreeManager Tree { get; }

        public WorldGenContext(int seed, WorldGenConfig config, Definitions definitions)
        {
            Seed = seed;
            Config = config;
            Noises = new(seed, config);
            Splines = new(config);
            Tree = new(this);
            Definitions = definitions;
        }
    }
}
