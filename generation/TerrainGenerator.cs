using System;
using Godot;
using Terraria.chunk;

namespace Terraria.generation
{
    public class TerrainGenerator : IWorldGenerator
    {
        public void Generate(Chunk chunk)
        {
            GD.Print("Generate");
        }
    }
}
