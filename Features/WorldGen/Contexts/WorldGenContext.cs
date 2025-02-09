using ProceduralGeneration.Features.WorldGen.Biomes;
using ProceduralGeneration.Features.WorldGen.Chunks;
using ProceduralGeneration.Features.WorldGen.Configurations;
using ProceduralGeneration.Features.WorldGen.Definitions;
using ProceduralGeneration.Features.WorldGen.Tiles;
using ProceduralGeneration.Features.WorldGen.Trees;

namespace ProceduralGeneration.Features.WorldGen.Contexts
{
    public class WorldGenContext
    {
        public int Seed { get; }

        public WorldGenConfig Config { get; }
        public WorldDefinitions Definitions { get; }
        public NoiseGroup Noises { get; }
        public SplineGroup Splines { get; }

        public BiomeType[] BiomeMap { get; set; } = new BiomeType[Chunk.Size.X];
        public int[] HeightMap { get; set; } = new int[Chunk.Size.X];
        public TileType[] SurfaceTileMap { get; set; } = new TileType[Chunk.Size.X];

        public TreeManager Tree { get; }

        public WorldGenContext(int seed, WorldGenConfig config, WorldDefinitions definitions)
        {
            Seed = seed;
            Config = config;
            Definitions = definitions;
            Noises = new(seed, config);
            Splines = new(config);
            Tree = new(this);
        }
    }
}
