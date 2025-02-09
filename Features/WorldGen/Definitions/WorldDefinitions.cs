using System.Collections.Generic;
using System.IO;
using ProceduralGeneration.Features.WorldGen.Biomes;
using ProceduralGeneration.Features.WorldGen.Trees;

namespace ProceduralGeneration.Features.WorldGen.Definitions
{
    public class WorldDefinitions
    {
        public WorldDefinition World { get; init; }
        public Dictionary<BiomeType, BiomeDefinition> Biomes { get; init; }

        public static WorldDefinitions Load(string path)
        {
            var world = WorldDefinition.Load(Path.Combine(path, "World.json"));
            var biomes = BiomeDefinition.Load(Path.Combine(path, "Biome.json"));

            return new WorldDefinitions()
            {
                World = world,
                Biomes = biomes,
            };
        }
    }

    public record TreeSpawnConfig(TreeType TreeType, float Weight);
}
