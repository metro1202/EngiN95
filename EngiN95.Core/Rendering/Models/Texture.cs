using System.Runtime.InteropServices;
using OpenTK.Graphics.OpenGL4;

namespace EngiN95.Core.Rendering;

public class Texture : IDisposable
{
    public Handle Handle { get; }
    public int Width { get; }
    public int Height { get; }
    
    private bool disposed;
    private readonly IGLWrapper glWrapper;

    public Texture(int handle, IGLWrapper glWrapper)
    {
        Handle = handle;
        this.glWrapper = glWrapper;
    }

    public Texture(int handle, int width, int height, IGLWrapper glWrapper) : this(handle, glWrapper)
    {
        Width = width;
        Height = height;
    }
    
    public void Use()
    {
        glWrapper.ActiveTexture(TextureUnit.Texture0);
        glWrapper.BindTexture(TextureTarget.Texture2D, Handle);
    }

    public static Texture Load(string texturePath, IGLWrapper glWrapper)
    {
        int handle = glWrapper.GenTexture();

        glWrapper.ActiveTexture(TextureUnit.Texture0);
        glWrapper.BindTexture(TextureTarget.Texture2D, handle);
        
        
        using var texture = SixLabors.ImageSharp.Image.Load<Rgba32>(texturePath);
        texture.Mutate(x => x.Flip(FlipMode.Vertical)); 
        
        var pixelData = new byte[4 * texture.Width * texture.Height];
        Span<byte> span = stackalloc byte[4 * texture.Width * texture.Height];
        texture.CopyPixelDataTo(span);
        MemoryMarshal.AsBytes(span).CopyTo(pixelData);
        
        var pinnedArray = GCHandle.Alloc(pixelData, GCHandleType.Pinned);
        try
        {
            IntPtr pointer = pinnedArray.AddrOfPinnedObject();

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, texture.Width, texture.Height, 0,
                OpenTK.Graphics.OpenGL4.PixelFormat.Rgba, PixelType.UnsignedByte, pointer);
            
            glWrapper.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter,
                (int) TextureMinFilter.Nearest);
            glWrapper.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter,
                (int) TextureMinFilter.Nearest);
            glWrapper.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS,
                (int) TextureWrapMode.Repeat);
            glWrapper.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT,
                (int) TextureWrapMode.Repeat);
        }
        finally
        {
            pinnedArray.Free();
        }
        
        glWrapper.GenerateMipmap(GenerateMipmapTarget.Texture2D);
        
        glWrapper.BindTexture(TextureTarget.Texture2D, 0);
        
        return new Texture(handle, texture.Width, texture.Height, glWrapper);
    }

    ~Texture()
    {
        Dispose();
    }
    
    public void Dispose()
    {
        if (disposed)
        {
            return;
        }
        
        disposed = true;
        glWrapper.DeleteTexture(Handle);
        GC.SuppressFinalize(this);
    }
}