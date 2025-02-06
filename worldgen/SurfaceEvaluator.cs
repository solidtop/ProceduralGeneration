using System;
using ProceduralGeneration.tile;
using ProceduralGeneration.worldgen.config;
using ProceduralGeneration.worldgen.utils;

namespace ProceduralGeneration.worldgen
{
    public struct SurfaceResult(TileType tile, int height)
    {
        public TileType Tile = tile;
        public int Height = height;
    }

    public class SurfaceEvaluator(WorldGenContext context)
    {
        private readonly WorldGenConfig _config = context.Config;
        private readonly NoiseGroup _noises = context.Noises;
        private readonly SplineGroup _splines = context.Splines;

        public SurfaceResult Evaluate(int worldX)
        {
            var heightNoise = _noises.Height.Sample1D(worldX);
            var height = (int)(_splines.Height.Interpolate(heightNoise));
            var surfaceY = height + 1;

            var isWater = surfaceY > context.Config.World.SeaLevel;

            var dirtNoise = _noises.Dirt.Sample2D(worldX, surfaceY);
            var dirtThreshold = _splines.Dirt.Interpolate(surfaceY);
            var isDirt = dirtNoise > dirtThreshold;

            var spaghettiNoise = Math.Abs(_noises.SpaghettiCave.Sample2D(worldX, surfaceY));
            var spaghettiThreshold = _config.Cave.SpaghettiNoise.Threshold;
            var isSpaghetti = spaghettiNoise < spaghettiThreshold;
            
            var cheeseNoise = Math.Abs(_noises.CheeseCave.Sample2D(worldX, surfaceY));
            var cheeseThreshold = _splines.CheeseCave.Interpolate(surfaceY);
            var isCheese = cheeseNoise > cheeseThreshold;

            var isAir = isSpaghetti || isCheese;

            var finalTile = TileType.Stone;

            if (isWater)
                finalTile = TileType.Water;
            else if (isAir)
                finalTile = TileType.Air;
            else if (isDirt)
                finalTile = TileType.Dirt;

            return new SurfaceResult(finalTile, height);
        }
    }
}
