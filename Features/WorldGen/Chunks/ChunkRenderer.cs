using System.Collections.Generic;
using Godot;

namespace ProceduralGeneration.Features.WorldGen.Chunks
{
    public partial class ChunkRenderer(ChunkManager manager) : Node2D
    {
        private readonly ChunkManager _manager = manager;
        private readonly IList<Chunk> _chunkCache = [];

        public override void _Ready()
        {
            _manager.ChunkLoaded += OnChunkLoaded;
            _manager.ChunkUnloaded += OnChunkUnloaded;
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
}