using Godot;
using Godot.Collections;

namespace ProceduralGeneration.worldgen.config
{
    public enum WorldLayer
    {
        Surface,
        Underground,
        Caverns,
        Underworld,
    }

    public class WorldConfig : ConfigLoader<WorldConfig>
    {
        public string Name { get; set; }
        public Vector2I Size { get; set; }
        public int SeaLevel { get; set; }
        public Dictionary<WorldLayer, int> Layers { get; set; }
    }
}


