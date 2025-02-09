using System;
using System.Collections.Generic;
using System.Linq;
using Godot;
using ProceduralGeneration.Common.Utilities;
using ProceduralGeneration.Features.WorldGen.Biomes;
using ProceduralGeneration.Features.WorldGen.Configurations;
using ProceduralGeneration.Features.WorldGen.Contexts;
using ProceduralGeneration.Features.WorldGen.Generators;
using ProceduralGeneration.Features.WorldGen.Tiles;
using ProceduralGeneration.Features.WorldGen.Utilities;

namespace ProceduralGeneration.Features.WorldGen.Trees
{
    public class TreeManager(WorldGenContext context)
    {
        private readonly int _seed = context.Seed;
        private readonly TreeConfig _config = context.Config.Tree;
        private readonly PerlinNoise _densityNoise = context.Noises.TreeDensity;
        private readonly SurfaceEvaluator _surfaceEvaluator = new(context);

        private readonly int _regionSize = context.Config.Tree.RegionSize;
        private readonly Dictionary<Vector2I, List<TreeStructure>> _regionTrees = [];
        private readonly List<TreeStructure> _globalTrees = [];

        public List<TreeStructure> GetTreesInArea(Rect2 area)
        {
            var trees = new List<TreeStructure>();

            int regionXStart = Mathf.FloorToInt(area.Position.X / _regionSize);
            int regionYStart = Mathf.FloorToInt(area.Position.Y / _regionSize);
            int regionXEnd = Mathf.FloorToInt((area.Position.X + area.Size.Y) / _regionSize);
            int regionYEnd = Mathf.FloorToInt((area.Position.Y + area.Size.X) / _regionSize);

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
            int treeCount = random.Next(_config.MinTreeCount, _config.MaxTreeCount);

            for (int i = 0; i < treeCount; i++)
            {
                // Determine a tree’s world position inside the region.
                var treeX = Mathf.FloorToInt(random.NextSingle() * _regionSize + regionCoord.X * _regionSize);

                var temperature = (context.Noises.Temperature.Sample1D(treeX) + 1) * 0.5f;
                var humidity = (context.Noises.Humidity.Sample1D(treeX) + 1) * 0.5f;

                var biome = BiomeGenerator.GetBiome(temperature, humidity);

                var surface = _surfaceEvaluator.Evaluate(treeX);

                if (surface.Tile != TileType.Dirt)
                    continue;

                var treePos = new Vector2I(treeX, surface.Height - 1);

                var tree = CreateTree(treePos, random, biome);

                if (tree is null)
                    continue;

                var tooClose = _globalTrees.Any(existing => existing.Position.DistanceSquaredTo(treePos) < 32);

                if (tooClose)
                    continue;

                var density = _densityNoise.Sample1D(treeX);
                var threshold = _config.DensityNoise.Threshold;

                if (density > threshold)
                    continue;

                trees.Add(tree);
                _globalTrees.Add(tree);
            }

            return trees;
        }

        private TreeStructure CreateTree(Vector2I position, Random random, BiomeType biomeType)
        {
            if (!context.Definitions.Biomes.TryGetValue(biomeType, out var definition))
            {
                return null;
            }

            var totalWeight = definition.TreeSpawns.Sum(spawn => spawn.Weight);
            var randomValue = random.NextSingle() * totalWeight;

            foreach (var spawn in definition.TreeSpawns)
            {
                randomValue -= spawn.Weight;

                if (randomValue <= 0)
                {
                    return spawn.TreeType switch
                    {
                        TreeType.Oak => new OakTree(position, random),
                        TreeType.Spruce => new SpruceTree(position, random),
                        TreeType.Birch => new BirchTree(position, random),
                        _ => null,
                    };
                }
            }

            return null;
        }
    }
}
