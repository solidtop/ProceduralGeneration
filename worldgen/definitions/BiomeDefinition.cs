using System.Collections.Generic;
using System.Drawing;
using ProceduralGeneration.worldgen.biome;
using ProceduralGeneration.worldgen.config;
using ProceduralGeneration.worldgen.tree;

namespace ProceduralGeneration.worldgen.definitions
{
    public class BiomeDefinition : ConfigLoader<Dictionary<BiomeType, BiomeDefinition>>
    {
        public Color Color { get; set; }
        public List<TreeSpawnConfig> TreeSpawns { get; set; }
    }
}
