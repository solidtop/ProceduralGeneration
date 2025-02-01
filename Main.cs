using Godot;
using Terraria.chunk;
using Terraria.generation;
using Terraria.generation.terrain;
using Terraria.tile;

public partial class Main : Node
{
	public override void _Ready()
	{
        WorldGeneratorContext context = new(seed: 12345);

        WorldGenerator worldGenerator = new(
        [
            new TerrainGenerator(),
		], context);

        var chunkController = new ChunkController(worldGenerator);
        var chunkRenderer = new ChunkRenderer(chunkController);
        var tileRenderer = new TileRenderer(chunkController);

        AddChild(tileRenderer);
        AddChild(chunkRenderer);
        AddChild(chunkController);

        chunkRenderer.Visible = false;
    }
}
