using System;
using System.Numerics;

namespace ProceduralGeneration.worldgen.utils
{
    public class Spline
    {
        private readonly float[] _x;
        private readonly float[] _y;

        public Spline(Vector2[] points)
        {
            if (points == null || points.Length < 2)
                throw new ArgumentException("Spline requires at least two data points.", nameof(points));

            _x = new float[points.Length];
            _y = new float[points.Length];

            for (int i = 0; i < points.Length; i++)
            {
                _x[i] = points[i].X; 
                _y[i] = points[i].Y;
            }
        }

        public float Interpolate(float x)
        {
            if (x <= _x[0])
                return _y[0];
            if (x >= _x[^1])
                return _y[_x.Length - 1];

            var i = FindInterval(x);
            var t = (x - _x[i]) / (_x[i + 1] - _x[i]);
            return Utils.Lerp(_y[i], _y[i + 1], t);
        }

        public float Interpolate(int x)
        {
            return Interpolate((float)x);
        }
             
        private int FindInterval(float x)
        {
            for (int i = 0; i < _x.Length - 1; i++)
            {
                if (x >= _x[i] && x <= _x[i + 1])
                    return i;
            }

            return -1;
        }
    }
}
