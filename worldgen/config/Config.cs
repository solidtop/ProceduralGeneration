using System.IO;
using Newtonsoft.Json;

namespace ProceduralGeneration.worldgen.config
{
    public abstract class ConfigLoader<T>
    {
        public static T Load(string filePath)
        {
            var json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}


