using Godot;
using ProceduralGeneration.chunk;
using ProceduralGeneration.worldgen;
using ProceduralGeneration.worldgen.terrain;
using ProceduralGeneration.worldgen.dirt;
using ProceduralGeneration.tile;
using ProceduralGeneration.worldgen.config;
using ProceduralGeneration.worldgen.biome;
using ProceduralGeneration.worldgen.cave;
using ProceduralGeneration.worldgen.tree;
using ProceduralGeneration.worldgen.surface;
using ProceduralGeneration.worldgen.plant;
using ProceduralGeneration.worldgen.definitions;

public partial class Main : Node
{
	public override void _Ready()
	{
        int seed = 12345;

        var worldGenConfig = WorldGenConfig.Load("./data/world/small/worldgen/");
        var definitions = Definitions.Load("./data/world/small/worldgen/definitions");

        WorldGenContext context = new(seed, worldGenConfig, definitions);

        WorldGenerator worldGenerator = new(
        [
            new BiomeGenerator(),
            new TerrainGenerator(),
            new DirtGenerator(),
            new SpaghettiCaveGenerator(),
            new CheeseCaveGenerator(),
            new SurfaceGenerator(),
            new TreeGenerator(),
            new PlantGenerator(),
        ], context);

        var chunkController = new ChunkController(definitions.World, worldGenerator);
        var chunkRenderer = new ChunkRenderer(chunkController);
        var tileRenderer = new TileRenderer(chunkController);

        AddChild(tileRenderer);
        AddChild(chunkRenderer);
        AddChild(chunkController);

        chunkRenderer.Visible = false;
    }
}
