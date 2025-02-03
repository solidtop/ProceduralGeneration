using System.IO;
using Newtonsoft.Json;
using ProceduralGeneration.tile;
using ProceduralGeneration.worldgen.config;

namespace ProceduralGeneration.worldgen.terrain
{
    public class TerrainConfig
    {
        public TileType DefaultTile {  get; set; } = TileType.Stone;
        public TileType DefaultFluid {  get; set; } = TileType.Water;
        public SplineNoiseConfig Height { get; set; }

        public static TerrainConfig Load(string filePath)
        {
            var json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<TerrainConfig>(json);
        }
    }
}
