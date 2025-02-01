using System.Collections.Generic;
using System.Linq;
using Terraria.chunk;

namespace Terraria.generation
{
    public class WorldGenerator(IEnumerable<IWorldGenerator> generators, WorldGeneratorContext context)
    {
        private readonly List<IWorldGenerator> _generators = generators.ToList();
        private readonly WorldGeneratorContext _context = context;

        public void Generate(Chunk chunk)
        {
            foreach (var generator in _generators)
            {
                generator.Generate(chunk, _context);
            }
        }
    }
}
