using System.Collections.Generic;
using System.Linq;
using ProceduralGeneration.chunk;

namespace ProceduralGeneration.generation
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
