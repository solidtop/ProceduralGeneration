﻿using Godot;
using ProceduralGeneration.Features.WorldGen.Chunks;
using ProceduralGeneration.Features.WorldGen.Contexts;

namespace ProceduralGeneration.Features.WorldGen.Generators
{
    public class TreeGenerator : IWorldGenerator
    {
        public void Generate(Chunk chunk, WorldGenContext context)
        {
            var chunkWorldPos = chunk.Position * Chunk.Size;

            var chunkArea = new Rect2(chunkWorldPos, Chunk.Size);
            var queryArea = chunkArea.Grow(Chunk.PixelSize.X * 2);

            var trees = context.Tree.GetTreesInArea(queryArea);

            foreach (var tree in trees)
            {
                tree.Generate(chunk, chunkWorldPos);
            }
        }
    }
}
