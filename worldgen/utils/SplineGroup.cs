using ProceduralGeneration.worldgen.config;

namespace ProceduralGeneration.worldgen.utils
{
    public class SplineGroup(WorldGenConfig config)
    {
        public Spline Height { get; } = CreateSpline(config.Terrain.Height.Spline);
        public Spline Dirt { get; } = CreateSpline(config.Dirt.Spline);
        public Spline CheeseCave { get; } = CreateSpline(config.Cave.Cheese.Spline);

        private static Spline CreateSpline(SplineConfig config)
        {
            return new(config.ControlPoints);
        }
    }
}
