using EngiN95.Core.Rendering;

namespace EngiN95.Core;

public class GameObject
{
    public required Transform Transform { get; set; }
    public Texture? Texture { get; set; }
    public Shape? Shape { get; set; }
}