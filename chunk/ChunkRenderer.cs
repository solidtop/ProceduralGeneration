using System.Collections.Generic;
using Godot;
using Terraria.chunk;

public partial class ChunkRenderer(ChunkController controller) : Node2D
{
    private readonly ChunkController _controller = controller;
    private readonly IList<Chunk> _chunkCache = [];

    public override void _Ready()
    {
        _controller.ChunkLoaded += OnChunkLoaded;
        _controller.ChunkUnloaded += OnChunkUnloaded;
    }

    private void OnChunkLoaded(Chunk chunk)
    {
        _chunkCache.Add(chunk);
        QueueRedraw();
    }

    private void OnChunkUnloaded(Chunk chunk)
    {
        _chunkCache.Remove(chunk);
        QueueRedraw();
    }

    public override void _Draw()
    {
        foreach (var chunk in _chunkCache)
        {
            var worldPos = chunk.Position * Chunk.PixelSize;
            var rect = new Rect2(worldPos, Chunk.PixelSize);

            DrawRect(rect, Colors.Red, false, 4);
            DrawString(ThemeDB.FallbackFont, worldPos + new Vector2(8, 32), $"Chunk {chunk.Position}");
        }
    }
}
