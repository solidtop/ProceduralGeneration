using System.Collections.Generic;
using System.IO;
using ProceduralGeneration.worldgen.biome;

namespace ProceduralGeneration.worldgen.definitions
{
    public class Definitions
    {
        public WorldDefinition World { get; init; }
        public Dictionary<BiomeType, BiomeDefinition> Biomes { get; init; }

        public static Definitions Load(string path)
        {
            var world = WorldDefinition.Load(Path.Combine(path, "world.json"));
            var biomes = BiomeDefinition.Load(Path.Combine(path, "biome.json"));

            return new Definitions()
            {
                World = world,
                Biomes = biomes,
            };
        }
    }

    public record TreeSpawnConfig(string TreeType, float Weight);
}
