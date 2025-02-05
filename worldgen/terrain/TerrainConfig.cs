using ProceduralGeneration.tile;
using ProceduralGeneration.worldgen.config;

namespace ProceduralGeneration.worldgen.terrain
{
    public class TerrainConfig : ConfigLoader<TerrainConfig>
    {
        public TileType DefaultTile {  get; set; } = TileType.Stone;
        public TileType DefaultFluid {  get; set; } = TileType.Water;
        public SplineNoiseConfig Height { get; set; }
    }
}
