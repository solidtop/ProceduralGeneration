using System;
using System.Collections.Generic;
using System.Linq;
using Godot;
using ProceduralGeneration.tile;
using ProceduralGeneration.worldgen.utils;

namespace ProceduralGeneration.worldgen.tree
{
    public class TreeManager(WorldGenContext context)
    {
        private readonly int _seed = context.Seed;
        private readonly SurfaceEvaluator _surfaceEvaluator = new(context);

        private readonly Dictionary<Vector2I, List<TreeStructure>> _regionTrees = [];
        private readonly List<TreeStructure> _globalTrees = [];

        public const int RegionSize = 128;

        private readonly PerlinNoise _densityNoise = new(context.Seed, 4, 1f);

        public List<TreeStructure> GetTreesInArea(Rect2 area)
        {
            var trees = new List<TreeStructure>();

            int regionXStart = Mathf.FloorToInt(area.Position.X / RegionSize);
            int regionYStart = Mathf.FloorToInt(area.Position.Y / RegionSize);
            int regionXEnd = Mathf.FloorToInt((area.Position.X + area.Size.Y) / RegionSize);
            int regionYEnd = Mathf.FloorToInt((area.Position.Y + area.Size.X) / RegionSize);

            for (int rx = regionXStart; rx <= regionXEnd; rx++)
            {
                for (int ry = regionYStart; ry <= regionYEnd; ry++)
                {
                    var regionCoord = new Vector2I(rx, ry);

                    if (!_regionTrees.TryGetValue(regionCoord, out var treesInRegion))
                    {
                        treesInRegion = GenerateRegionTrees(regionCoord);
                        _regionTrees.Add(regionCoord, treesInRegion);
                    }

                    trees.AddRange(treesInRegion);
                }
            }

            return trees;
        }

        private List<TreeStructure> GenerateRegionTrees(Vector2I regionCoord)
        {
            int regionSeed = _seed ^ regionCoord.X ^ regionCoord.Y;
            var random = new Random(regionSeed);

            var trees = new List<TreeStructure>();
            int treeCount = random.Next(4, 10);

            for (int i = 0; i < treeCount; i++)
            {
                // Determine a tree’s world position inside the region.
                var treeX = Mathf.FloorToInt(random.NextSingle() * RegionSize + regionCoord.X * RegionSize);

                var surface = _surfaceEvaluator.Evaluate(treeX);

                if (surface.Tile != TileType.Dirt)
                    continue;

                var treePos = new Vector2I(treeX, surface.Height);

                var tooClose = _globalTrees.Any(existing => existing.Position.DistanceSquaredTo(treePos) < 32);

                if (tooClose) continue;

                var density = _densityNoise.Sample1D(treeX);

                if (density > 0.1f)
                    continue;

                var tree = new OakTree(treePos, random);
                trees.Add(tree);
                _globalTrees.Add(tree);
            }

            return trees;
        }
    }
}
