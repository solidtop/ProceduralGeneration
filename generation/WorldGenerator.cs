using System.Collections.Generic;
using System.Linq;
using Terraria.chunk;

namespace Terraria.generation
{
    public class WorldGenerator(IEnumerable<IWorldGenerator> generators) : IWorldGenerator
    {
        private readonly List<IWorldGenerator> _generators = generators.ToList();

        public void Generate(Chunk chunk)
        {
            foreach (var generator in _generators)
            {
                generator.Generate(chunk);
            }
        }
    }
}
