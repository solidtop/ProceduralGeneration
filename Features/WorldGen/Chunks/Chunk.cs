using Godot;
using ProceduralGeneration.Features.WorldGen.Tiles;

namespace ProceduralGeneration.Features.WorldGen.Chunks
{
    public sealed class Chunk(Vector2I position)
    {
        public static readonly Vector2I Size = new(16, 16);
        public static readonly Vector2I PixelSize = new(256, 256);

        public Vector2I Position { get; } = position;
        public TileType[,] Tiles { get; set; } = new TileType[Size.X, Size.Y];
    }
}
