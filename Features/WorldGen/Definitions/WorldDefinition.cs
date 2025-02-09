using System.Collections.Generic;
using Godot;
using ProceduralGeneration.Common.Utilities;

namespace ProceduralGeneration.Features.WorldGen.Definitions
{
    public enum WorldLayer
    {
        Surface,
        Underground,
        Caverns,
        Underworld,
    }

    public class WorldDefinition : ConfigLoader<WorldDefinition>
    {
        public string Name { get; set; }
        public Vector2I Size { get; set; }
        public int SeaLevel { get; set; }
        public Dictionary<WorldLayer, int> Layers { get; set; }
    }
}
