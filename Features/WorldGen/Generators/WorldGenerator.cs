using System.Collections.Generic;
using System.Linq;
using ProceduralGeneration.Features.WorldGen.Chunks;
using ProceduralGeneration.Features.WorldGen.Contexts;

namespace ProceduralGeneration.Features.WorldGen.Generators
{
    public class WorldGenerator(IEnumerable<IWorldGenerator> generators, WorldGenContext context)
    {
        private readonly List<IWorldGenerator> _generators = generators.ToList();
        private readonly WorldGenContext _context = context;

        public void Generate(Chunk chunk)
        {
            foreach (var generator in _generators)
            {
                generator.Generate(chunk, _context);
            }
        }
    }
}
