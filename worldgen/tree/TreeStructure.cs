using System;
using Godot;
using ProceduralGeneration.chunk;

namespace ProceduralGeneration.worldgen.tree
{
    //public sealed class TreeStructure(Vector2 position)
    //{
    //    public Vector2 Position { get; } = position;
    //    public int Height { get; } = 10;
    //    public int CanopyRadius { get; } = 2;

    //    public Rect2 GetBounds()
    //    {
    //        // Assume the trunk is drawn at the tree's base and extends upward,
    //        // and the canopy is centered at the top of the trunk.
    //        // Here we assume the trunk is 1 tile wide.
    //        int minX = (int)Mathf.Round(Position.X) - CanopyRadius;
    //        int maxX = (int)Mathf.Round(Position.Y) + CanopyRadius;
    //        int topY = (int)Mathf.Round(Position.Y - Height); // canopy center y
    //        int minY = topY - CanopyRadius;
    //        int maxY = (int)Mathf.Round(Position.Y);
    //        return new Rect2(new Vector2(minX, minY), new Vector2(maxX - minX + 1, maxY - minY + 1));
    //    }
    //}

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
            return (x >= chunkWorldPos.X && x < chunkWorldPos.X + Chunk.Size.X &&
                y >= chunkWorldPos.Y && y < chunkWorldPos.Y + Chunk.Size.Y);
        }
    }
}
