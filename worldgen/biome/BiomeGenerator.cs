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

        public static BiomeType GetBiome(float temperature, float humidity)
        {
            if (temperature < 0.3f)
            {
                return BiomeType.Tundra;
            }
            else if (temperature < 0.7)
            {
                return BiomeType.Forest;
            }
            else
            {
                return BiomeType.Desert;
            }
        }
    }
}
