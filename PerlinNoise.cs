using System;
using Godot;

namespace Terraria
{
    public class PerlinNoise(int octaves, float frequency, float amplitude)
    {
        private const float AmplitudeScale = 1f;
        private const float FrequencyScale = 0.01f;

        private readonly int _octaves = octaves;
        private readonly float _amplitude = amplitude * AmplitudeScale;
        private readonly float _frequency = frequency * FrequencyScale;

        private static readonly int[] gradients1D = [-1, 1];

        private static readonly int[][] gradients2D = [
            [1, 1], [-1, 1], [1, -1], [-1, -1], // Diagonal directions
            [1, 0], [-1, 0], [0, 1], [0, -1] // Cardinal directions
        ];

        private static int seed = 0;
        private static int[] permutation = GeneratePermutation();

        public PerlinNoise(int octaves, float frequency) : this(octaves, frequency, 1) { }

        public static int Seed
        {
            get => seed;
            set
            {
                seed = value;
                permutation = GeneratePermutation();
            }
        }

        public float Sample1D(float x)
        {
            float value = 0;
            var amplitude = _amplitude;
            var frequency = _frequency;
            var persistence = 0.5f;
            var lacunarity = 2;

            for (int i = 0; i < _octaves; i++)
            {
                value += Noise(x * frequency) * amplitude;
                amplitude *= persistence;
                frequency *= lacunarity;
            }

            return value;
        }

        public float Sample2D(float x, float y)
        {
            float value = 0;
            var amplitude = _amplitude;
            var frequency = _frequency;
            var persistence = 0.5f;
            var lacunarity = 2;

            for (int i = 0; i < _octaves; i++)
            {
                value += Noise(x * frequency, y * frequency) * amplitude;
                amplitude *= persistence;
                frequency *= lacunarity;
            }

            return value;
        }

        public static float Noise(float x)
        {
            var x0 = (int)MathF.Floor(x);
            var x1 = x0 + 1;

            // Relative position inside the grid cell
            var sx = x - x0;

            // Hash values for gradient selection
            var g0 = gradients1D[Hash(x0)];
            var g1 = gradients1D[Hash(x1)];

            // Compute dot products
            var n0 = g0 * sx;
            var n1 = g1 * (sx - 1);

            var u = Smoothstep(sx);

            return Utils.Lerp(n0, n1, u);
        }

        public static float Noise(float x, float y)
        {
            var x0 = (int)Mathf.Floor(x);
            var y0 = (int)Mathf.Floor(y);
            var x1 = x0 + 1;
            var y1 = y0 + 1;

            // Relative position inside the grid cell
            var sx = x - x0;
            var sy = y - y0;

            var g00 = gradients2D[Hash(x0, y0)];
            var g10 = gradients2D[Hash(x1, y0)];
            var g01 = gradients2D[Hash(x0, y1)];
            var g11 = gradients2D[Hash(x1, y1)];

            // Compute dot products
            var n00 = Dot(g00[0], g00[1], sx, sy);
            var n10 = Dot(g10[0], g10[1], sx - 1, sy);
            var n01 = Dot(g01[0], g01[1], sx, sy - 1);
            var n11 = Dot(g11[0], g11[1], sx - 1, sy - 1);

            // Interpolate along x
            var u = Smoothstep(sx);
            var nx0 = Utils.Lerp(n00, n10, u);
            var nx1 = Utils.Lerp(n01, n11, u);

            // Interpolate along y
            var v = Smoothstep(sy);

            return Utils.Lerp(nx0, nx1, v);
        }

        private static int Hash(int x)
        {
            return permutation[x & 255] % 2;
        }

        private static int Hash(int x, int y)
        {
            return permutation[permutation[x & 255] + y & 255] % 8;
        }

        private static float Dot(float x1, float y1, float x2, float y2)
        {
            return x1 * x2 + y1 * y2;
        }

        private static float Smoothstep(float t)
        {
            return t * t * t * (t * (t * 6 - 15) + 10);
        }

        private static int[] GeneratePermutation()
        {
            var random = new Random(seed);
            int[] perm = new int[256];

            for (int i = 0; i < 256; i++)
            {
                perm[i] = random.Next();
            }

            // Shuffle 
            for (int i = 255; i > 0; i--)
            {
                int swapIndex = random.Next(i + 1);
                (perm[i], perm[swapIndex]) = (perm[swapIndex], perm[i]);
            }

            // Duplicate array to avoid overflow when hashing
            var permutation = new int[512];

            for (int i = 0; i < 512; i++)
            {
                permutation[i] = perm[i % 256];
            }

            return permutation;
        }
    }
}
