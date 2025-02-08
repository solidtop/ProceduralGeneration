using System.Collections.Generic;
using Godot;
using ProceduralGeneration.worldgen.config;

namespace ProceduralGeneration.worldgen.definitions
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
