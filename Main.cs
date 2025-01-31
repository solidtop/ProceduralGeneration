using Godot;
using Terraria.chunk;
using Terraria.generation;
using Terraria.tile;

public partial class Main : Node
{
	public override void _Ready()
	{
		WorldGenerator worldGenerator = new(
        [
            new TerrainGenerator(),
		]);

        var chunkController = new ChunkController(worldGenerator);
        var chunkRenderer = new ChunkRenderer(chunkController);
        var tileRenderer = new TileRenderer(chunkController);

        AddChild(tileRenderer);
        AddChild(chunkRenderer);
        AddChild(chunkController);
    }
}
