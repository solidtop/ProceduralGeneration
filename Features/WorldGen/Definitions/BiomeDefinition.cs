using System.Collections.Generic;
using System.Drawing;
using ProceduralGeneration.Common.Utilities;
using ProceduralGeneration.Features.WorldGen.Biomes;

namespace ProceduralGeneration.Features.WorldGen.Definitions
{
    public class BiomeDefinition : ConfigLoader<Dictionary<BiomeType, BiomeDefinition>>
    {
        public Color Color { get; set; }
        public List<TreeSpawnConfig> TreeSpawns { get; set; }
    }
}
