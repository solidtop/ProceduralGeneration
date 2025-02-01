﻿using System;
using System.Collections.Generic;
using Terraria;

namespace ProceduralGeneration
{
    public class Spline
    {
        private readonly float[] _x;
        private readonly float[] _y;

        public Spline((float x, float y)[] points)
        {
            if (points == null || points.Length < 2)
                throw new ArgumentException("Spline requires at least two data points.", nameof(points));

            _x = new float[points.Length];
            _y = new float[points.Length];

            for (int i = 0; i < points.Length; i++)
            {
                _x[i] = points[i].x; 
                _y[i] = points[i].y;
            }
        }

        public float Interpolate(float x)
        {
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
