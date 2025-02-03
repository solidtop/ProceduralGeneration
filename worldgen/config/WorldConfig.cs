using System.IO;
using Godot;
using Godot.Collections;
using Newtonsoft.Json;

namespace ProceduralGeneration.worldgen.config
{
    public enum WorldLayer
    {
        Surface,
        Underground,
        Caverns,
        Underworld,
    }

    public class WorldConfig
    {
        public string Name { get; set; }
        public Vector2I Size { get; set; }
        public int SeaLevel { get; set; }
        public Dictionary<WorldLayer, int> Layers { get; set; }

        public static WorldConfig Load(string filePath)
        {
            var json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<WorldConfig>(json);
        }
    }
}


