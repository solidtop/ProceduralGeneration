using System.IO;

namespace ProceduralGeneration.Features.WorldGen.Configurations
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
            var biomeConfig = BiomeConfig.Load(Path.Combine(path, "Biome.json"));
            var terrainConfig = TerrainConfig.Load(Path.Combine(path, "Terrain.json"));
            var dirtConfig = DirtConfig.Load(Path.Combine(path, "Dirt.json"));
            var caveConfig = CaveConfig.Load(Path.Combine(path, "Cave.json"));
            var treeConfig = TreeConfig.Load(Path.Combine(path, "Tree.json"));

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






