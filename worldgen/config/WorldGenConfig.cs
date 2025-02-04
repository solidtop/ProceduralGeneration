using System.IO;
using ProceduralGeneration.worldgen.terrain;
using ProceduralGeneration.worldgen.terrain.dirt;
using ProceduralGeneration.worldgen.biome;

namespace ProceduralGeneration.worldgen.config
{
    public class WorldGenConfig
    {
        public WorldConfig World { get; init; }
        public BiomeConfig Biome { get; init; }
        public TerrainConfig Terrain { get; init; }
        public DirtConfig Dirt { get; init; }

        public static WorldGenConfig Load(string path)
        {
            var worldConfig = WorldConfig.Load(Path.Combine(path, "world.json"));
            var biomeConfig = BiomeConfig.Load(Path.Combine(path, "biome.json"));
            var terrainConfig = TerrainConfig.Load(Path.Combine(path, "terrain.json"));
            var dirtConfig = DirtConfig.Load(Path.Combine(path, "dirt.json"));

            return new WorldGenConfig()
            {
                World = worldConfig,
                Biome = biomeConfig,
                Terrain = terrainConfig,
                Dirt = dirtConfig,
            };
        }
    }
}






