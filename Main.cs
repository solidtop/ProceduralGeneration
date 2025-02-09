using Godot;
using ProceduralGeneration.Features.WorldGen.Chunks;
using ProceduralGeneration.Features.WorldGen.Configurations;
using ProceduralGeneration.Features.WorldGen.Contexts;
using ProceduralGeneration.Features.WorldGen.Definitions;
using ProceduralGeneration.Features.WorldGen.Generators;
using ProceduralGeneration.Features.WorldGen.Tiles;

namespace ProceduralGeneration
{
    public partial class Main : Node
    {
        public override void _Ready()
        {
            int seed = 12345;

            var worldGenConfig = WorldGenConfig.Load("./Data/Worlds/TestWorld/WorldGen/");
            var worldDefinitions = WorldDefinitions.Load("./Data/Worlds/TestWorld/WorldGen/Definitions");

            WorldGenContext context = new(seed, worldGenConfig, worldDefinitions);

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

            var chunkManager = new ChunkManager(worldDefinitions.World, worldGenerator);
            var chunkRenderer = new ChunkRenderer(chunkManager);
            var tileRenderer = new TileRenderer(chunkManager);

            AddChild(tileRenderer);
            AddChild(chunkRenderer);
            AddChild(chunkManager);

            chunkRenderer.Visible = false;
        }
    }
}