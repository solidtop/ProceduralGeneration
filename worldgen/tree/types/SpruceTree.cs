using Godot;
using ProceduralGeneration.chunk;
using ProceduralGeneration.tile;
using System;

namespace ProceduralGeneration.worldgen.tree.types
{
    public class SpruceTree(Vector2I position, Random random) : TreeStructure(position)
    {
        private const int MinTrunkHeight = 10;
        private const int MaxTrunkHeight = 15;
        private readonly int _trunkHeight = random.Next(MinTrunkHeight, MaxTrunkHeight + 1);

        public override int TrunkHeight => _trunkHeight;
        public override int CanopyRadius => 3;

        protected override void GenerateTrunk(Chunk chunk, Vector2I chunkWorldPos)
        {
            int trunkX = Position.X;
            int trunkBaseY = Position.Y;

            for (int y = trunkBaseY; y > trunkBaseY - TrunkHeight; y--)
            {
                if (IsWithinChunk(trunkX, y, chunkWorldPos))
                {
                    int localX = trunkX - chunkWorldPos.X;
                    int localY = y - chunkWorldPos.Y;
                    chunk.Tiles[localX, localY] = TileType.SpruceLog;
                }
            }
        }

        protected override void GenerateCanopy(Chunk chunk, Vector2I chunkWorldPos)
        {
            int canopyCenterX = Position.X;
            int canopyCenterY = Position.Y - TrunkHeight;

            for (int x = canopyCenterX - CanopyRadius; x <= canopyCenterX + CanopyRadius; x++)
            {
                for (int y = canopyCenterY - CanopyRadius; y <= canopyCenterY + CanopyRadius; y++)
                {
                    int dx = x - canopyCenterX;
                    int dy = y - canopyCenterY;

                    if (dx * dx + dy * dy <= CanopyRadius * CanopyRadius)
                    {
                        if (IsWithinChunk(x, y, chunkWorldPos))
                        {
                            int localX = x - chunkWorldPos.X;
                            int localY = y - chunkWorldPos.Y;

                            if (chunk.Tiles[localX, localY] == TileType.Air)
                            {
                                chunk.Tiles[localX, localY] = TileType.SpruceLeaves;
                            }
                        }
                    }
                }
            }
        }
    }
}
