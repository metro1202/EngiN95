using EngiN95.Core.Rendering;

namespace EngiN95.Core.Management;

public sealed class ResourceManager
{
    public static ResourceManager Instance { get; } = new();
    private readonly IGLWrapper glWrapper;
    private ResourceManager()
    {
        glWrapper = new GLWrapper();
    }
    
    private readonly Dictionary<string, Texture> textureCache = new();
    
    public Texture GetTexture(string textureName)
    {
        textureCache.TryGetValue(textureName, out var texture);
        {
            if (texture is not null)
            {
                return texture;
            }
        }
        texture = Texture.Load(textureName, glWrapper);
        textureCache.Add(textureName, texture);
        return texture;
    }
}