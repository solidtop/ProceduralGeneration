using Terraria.chunk;

namespace Terraria.generation
{
    public interface IWorldGenerator
    {
        void Generate(Chunk chunk, WorldGeneratorContext context);
    }
}
