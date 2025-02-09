using Godot;
using ProceduralGeneration.Features.WorldGen.Chunks;

namespace ProceduralGeneration.Features.WorldGen.Trees
{
    public abstract class TreeStructure(Vector2I position)
    {
        public Vector2I Position { get; protected set; } = position;

        public abstract int TrunkHeight { get; }
        public abstract int CanopyRadius { get; }

        public void Generate(Chunk chunk, Vector2I chunkWorldPos)
        {
            GenerateTrunk(chunk, chunkWorldPos);
            GenerateCanopy(chunk, chunkWorldPos);
        }

        protected abstract void GenerateTrunk(Chunk chunk, Vector2I chunkWorldPos);
        protected abstract void GenerateCanopy(Chunk chunk, Vector2I chunkWorldPos);

        protected static bool IsWithinChunk(int x, int y, Vector2I chunkWorldPos)
        {
            return x >= chunkWorldPos.X && x < chunkWorldPos.X + Chunk.Size.X &&
                y >= chunkWorldPos.Y && y < chunkWorldPos.Y + Chunk.Size.Y;
        }
    }
}
