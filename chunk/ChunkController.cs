using System;
using System.Collections.Generic;
using System.Linq;
using Godot;

namespace Terraria.chunk
{
    public partial class ChunkController : Node
    {
        private readonly Dictionary<Vector2I, Chunk> _activeChunks = [];

        private Vector2I _renderDistance = new(10, 5);
        private int _loadDistance;
        private int _unloadDistance;
        private const int UnloadBufferDistance = 2;

        private Camera2D _camera;

        public event Action<Chunk> ChunkLoaded;
        public event Action<Chunk> ChunkUnloaded;

        private Vector2I _lastCameraChunkPosition = Vector2I.Zero;

        public override void _Ready()
        {
            _camera = GetViewport().GetCamera2D();

            _loadDistance = _renderDistance.X * _renderDistance.X;
            _unloadDistance = (_renderDistance.X + UnloadBufferDistance) * (_renderDistance.X + UnloadBufferDistance);

            UpdateChunks(forceLoad: true);
        }

        public override void _Process(double delta)
        {
            UpdateChunks();
        }

        private void UpdateChunks(bool forceLoad = false)
        {
            var cameraPosition = _camera.GlobalPosition;

            var cameraChunkPosition = new Vector2I(
                Mathf.RoundToInt(cameraPosition.X / Chunk.PixelSize.X),
                Mathf.RoundToInt(cameraPosition.Y / Chunk.PixelSize.Y)
            );

            // Skip update if the camera position hasn't changed
            if (cameraChunkPosition == _lastCameraChunkPosition && !forceLoad)
                return;

            _lastCameraChunkPosition = cameraChunkPosition;

            for (int xOffset = -_renderDistance.X; xOffset < _renderDistance.X; xOffset++)
            {
                for (int yOffset = -_renderDistance.Y; yOffset < _renderDistance.Y; yOffset++)
                {
                    var chunkPosition = cameraChunkPosition + new Vector2I(xOffset, yOffset); 

                    if (!IsChunkWithinBounds(chunkPosition))
                        continue;

                    var chunkDelta = chunkPosition - cameraChunkPosition;
                    var distance = chunkDelta.X * chunkDelta.X + chunkDelta.Y * chunkDelta.Y;

                    if (distance > _loadDistance)
                        continue;

                    if (!IsChunkLoaded(chunkPosition))
                    {
                        LoadChunk(chunkPosition);
                    }
                }
            }

            foreach (var chunk in _activeChunks.Values.ToList())
            {
                var chunkDelta = chunk.Position - cameraChunkPosition;
                var distance = chunkDelta.X * chunkDelta.X + chunkDelta.Y * chunkDelta.Y;

                if (distance > _unloadDistance)
                {
                    UnloadChunk(chunk);
                }
            }
        }

        private bool IsChunkLoaded(Vector2I chunkPosition)
        {
            return _activeChunks.ContainsKey(chunkPosition);
        }

        private void LoadChunk(Vector2I chunkPosition)
        {
            Chunk chunk = new(chunkPosition);

            _activeChunks.Add(chunkPosition, chunk);

            ChunkLoaded?.Invoke(chunk);
        }

        private void UnloadChunk(Chunk chunk)
        {
            _activeChunks.Remove(chunk.Position);

            ChunkUnloaded?.Invoke(chunk);
        }

        private static bool IsChunkWithinBounds(Vector2 chunkPosition)
        {
            var maxChunksX = World.Width / Chunk.Size.X;
            var maxChunksY = World.Height / Chunk.Size.Y;

            return chunkPosition.X >= 0 && chunkPosition.X < maxChunksX &&
                   chunkPosition.Y >= 0 && chunkPosition.Y < maxChunksY;
        }
    }
}
