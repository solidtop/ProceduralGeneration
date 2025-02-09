using Godot;

namespace ProceduralGeneration.Features.WorldGen.Tiles
{
    public readonly struct TileMetadata(Vector2I atlasCoords)
    {
        public Vector2I AtlasCoords { get; } = atlasCoords;
    }
}
