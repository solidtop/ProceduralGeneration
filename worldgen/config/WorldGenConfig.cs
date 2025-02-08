using System.IO;
using ProceduralGeneration.worldgen.terrain;
using ProceduralGeneration.worldgen.biome;
using ProceduralGeneration.worldgen.cave;
using ProceduralGeneration.worldgen.dirt;
using ProceduralGeneration.worldgen.tree;

namespace ProceduralGeneration.worldgen.config
{
    public class WorldGenConfig
    {
        public BiomeConfig Biome { get; init; }
        public TerrainConfig Terrain { get; init; }
        public DirtConfig Dirt { get; init; }
        public CaveConfig Cave { get; init; }
        public TreeConfig Tree { get; init; }

        public static WorldGenConfig Load(string path)
        {
            var biomeConfig = BiomeConfig.Load(Path.Combine(path, "biome.json"));
            var terrainConfig = TerrainConfig.Load(Path.Combine(path, "terrain.json"));
            var dirtConfig = DirtConfig.Load(Path.Combine(path, "dirt.json"));
            var caveConfig = CaveConfig.Load(Path.Combine(path, "cave.json"));
            var treeConfig = TreeConfig.Load(Path.Combine(path, "tree.json"));

            return new WorldGenConfig()
            {
                Biome = biomeConfig,
                Terrain = terrainConfig,
                Dirt = dirtConfig,
                Cave = caveConfig,
                Tree = treeConfig,
            };
        }
    }
}






