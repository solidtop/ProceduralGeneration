using Godot;
using ProceduralGeneration.chunk;
using ProceduralGeneration.worldgen;
using ProceduralGeneration.worldgen.terrain;
using ProceduralGeneration.worldgen.terrain.dirt;
using ProceduralGeneration.tile;
using ProceduralGeneration.worldgen.config;
using ProceduralGeneration.worldgen.biome;
using ProceduralGeneration.worldgen.cave;
using ProceduralGeneration.worldgen.tree;

public partial class Main : Node
{
	public override void _Ready()
	{
        int seed = 12345;

        var worldGenConfig = WorldGenConfig.Load("./data/world/small/worldgen/");

        WorldGenContext context = new(seed, worldGenConfig);

        WorldGenerator worldGenerator = new(
        [
            new BiomeGenerator(),
            new TerrainGenerator(),
            new DirtGenerator(),
            new SpaghettiCaveGenerator(),
            new CheeseCaveGenerator(),
            new TreeGenerator(),
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
