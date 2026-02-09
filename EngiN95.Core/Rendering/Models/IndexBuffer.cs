using OpenTK.Graphics.OpenGL4;

namespace EngiN95.Core.Rendering;

public class IndexBuffer : IIndexBuffer
{
    private readonly IGLWrapper glWrapper;
    
    public Handle Handle { get; }
    private bool disposed;

    internal int BufferLength { get; }

    public IndexBuffer(IGLWrapper glWrapper, uint[] indices)
    {
        this.glWrapper = glWrapper;
        
        disposed = false;
        Handle = this.glWrapper.GenBuffer();
        
        this.glWrapper.BindBuffer(BufferTarget.ElementArrayBuffer, Handle);
        this.glWrapper.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(uint), indices, BufferUsageHint.StaticDraw);
        
        BufferLength = indices.Length;
    }

    public void Bind()
    {
        glWrapper.BindBuffer(BufferTarget.ElementArrayBuffer, Handle);
    }

    public void UnBind()
    {
        glWrapper.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
    }

    ~IndexBuffer()
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
        glWrapper.DeleteBuffer(Handle);
        GC.SuppressFinalize(this);
    }
}