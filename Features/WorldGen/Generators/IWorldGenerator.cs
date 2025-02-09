using ProceduralGeneration.Features.WorldGen.Chunks;
using ProceduralGeneration.Features.WorldGen.Contexts;

namespace ProceduralGeneration.Features.WorldGen.Generators
{
    public interface IWorldGenerator
    {
        void Generate(Chunk chunk, WorldGenContext context);
    }
}
