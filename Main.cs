using Godot;
using ProceduralGeneration;
using ProceduralGeneration.chunk;
using ProceduralGeneration.generation;
using ProceduralGeneration.generation.terrain;
using ProceduralGeneration.tile;

public partial class Main : Node
{
	public override void _Ready()
	{
        int seed = 12345;

        var worldSettings = WorldSettings.Create(WorldSizeOption.Small);
        var terrainSettings = TerrainSettings.Load("config/terrainsettings.json");

        WorldGeneratorContext context = new(seed, worldSettings, terrainSettings);

        WorldGenerator worldGenerator = new(
        [
            new TerrainGenerator(),
        ], context);

        var chunkController = new ChunkController(worldSettings, worldGenerator);
        var chunkRenderer = new ChunkRenderer(chunkController);
        var tileRenderer = new TileRenderer(chunkController);

        AddChild(tileRenderer);
        AddChild(chunkRenderer);
        AddChild(chunkController);

        chunkRenderer.Visible = false;
    }
}
