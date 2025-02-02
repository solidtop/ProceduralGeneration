using ProceduralGeneration.chunk;

namespace ProceduralGeneration.generation
{
    public interface IWorldGenerator
    {
        void Generate(Chunk chunk, WorldGeneratorContext context);
    }
}
