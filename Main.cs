using Godot;
using ProceduralGeneration;
using ProceduralGeneration.chunk;
using ProceduralGeneration.worldgen;
using ProceduralGeneration.worldgen.terrain;
using ProceduralGeneration.worldgen.terrain.dirt;
using ProceduralGeneration.tile;

public partial class Main : Node
{
	public override void _Ready()
	{
        int seed = 12345;

        var worldGenConfig = WorldGenConfig.Load("./data/world/small/worldgen/");

        WorldGenContext context = new(seed, worldGenConfig);

        WorldGenerator worldGenerator = new(
        [
            new TerrainGenerator(),
            new DirtGenerator(),
        ], context);

        var chunkController = new ChunkController(worldGenConfig.World, worldGenerator);
        var chunkRenderer = new ChunkRenderer(chunkController);
        var tileRenderer = new TileRenderer(chunkController);

        AddChild(tileRenderer);
        AddChild(chunkRenderer);
        AddChild(chunkController);

        chunkRenderer.Visible = false;
    }
}
