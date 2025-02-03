using ProceduralGeneration.chunk;

namespace ProceduralGeneration.worldgen
{
    public interface IWorldGenerator
    {
        void Generate(Chunk chunk, WorldGenContext context);
    }
}
