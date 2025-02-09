using ProceduralGeneration.Common.Utilities;
using ProceduralGeneration.Features.WorldGen.Configurations;

namespace ProceduralGeneration.Features.WorldGen.Contexts
{
    public class SplineGroup(WorldGenConfig config)
    {
        public CubicSpline Height { get; } = CreateSpline(config.Terrain.HeightSpline);
        public CubicSpline Dirt { get; } = CreateSpline(config.Dirt.Spline);
        public CubicSpline CheeseCave { get; } = CreateSpline(config.Cave.CheeseSpline);

        private static CubicSpline CreateSpline(SplineConfig config)
        {
            return new(config.ControlPoints);
        }
    }
}
