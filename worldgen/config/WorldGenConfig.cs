using System.IO;
using ProceduralGeneration.worldgen.terrain;
using ProceduralGeneration.worldgen.terrain.dirt;
using ProceduralGeneration.worldgen.config;

namespace ProceduralGeneration
{
    public class WorldGenConfig
    {
        public WorldConfig World { get; init; }
        public TerrainConfig Terrain { get; init; }
        public DirtConfig Dirt { get; init; }

        public static WorldGenConfig Load(string path)
        {
            var worldConfig = WorldConfig.Load(Path.Combine(path, "world.json"));
            var terrainConfig = TerrainConfig.Load(Path.Combine(path, "terrain.json"));
            var dirtConfig = DirtConfig.Load(Path.Combine(path, "dirt.json"));

            return new WorldGenConfig()
            {
                World = worldConfig,
                Terrain = terrainConfig,
                Dirt = dirtConfig,
            };
        }
    }
}






