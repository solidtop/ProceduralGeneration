using Godot;

namespace ProceduralGeneration
{
    public enum WorldSizeOption
    {
        Small,
        Medium,
        Large,
        Infinite,
    }

    public class WorldSettings(WorldSizeOption sizeOption)
    {
        public WorldSizeOption SizeOption { get; } = sizeOption;
        public Vector2I Size { get; } = sizeOption switch
        {
            WorldSizeOption.Small => new(1750, 900),
            WorldSizeOption.Medium => new(4200, 1200),
            WorldSizeOption.Large => new(8400, 2400),
            WorldSizeOption.Infinite => new(int.MaxValue, 2400),
            _ => throw new System.NotImplementedException(),
        };

        public static WorldSettings Create(WorldSizeOption sizeOption)
        {
            return new(sizeOption);
        }
    }
}
