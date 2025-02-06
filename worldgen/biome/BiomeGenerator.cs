using ProceduralGeneration.chunk;

namespace ProceduralGeneration.worldgen.biome
{
    public class BiomeGenerator : IWorldGenerator
    {
        public void Generate(Chunk chunk, WorldGenContext context)
        {
            var chunkWorldPos = chunk.Position * Chunk.Size;

            for (int x = 0; x < Chunk.Size.X; x++)
            {
                var worldX = chunkWorldPos.X + x;

                var temperature = (context.Noises.Temperature.Sample1D(worldX) + 1) * 0.5f;
                var humidity = (context.Noises.Humidity.Sample1D(worldX) + 1) * 0.5f;

                context.BiomeMap[x] = GetBiome(temperature, humidity);
            }
        }

        private static BiomeType GetBiome(float temperature, float humidity)
        {
            if (temperature < 0.3f) // Cold
            {
                if (humidity > 0.7f)
                    return BiomeType.Glacier;
                if (humidity > 0.4f)
                    return BiomeType.SnowyTaiga;

                return BiomeType.Tundra;
            }
            if (temperature < 0.7f) // Temperate
            {
                if (humidity > 0.7f)
                    return BiomeType.Swamp;
                if (humidity > 0.4f)
                    return BiomeType.Forest;

                return BiomeType.Grassland;
            }
            // Hot
            if (humidity > 0.7f)
                return BiomeType.Jungle;
            if (humidity > 0.4f)
                return BiomeType.Savanna;

            return BiomeType.Desert;
        }
    }
}
