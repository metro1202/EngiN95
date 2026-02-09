using OpenTK.Graphics.OpenGL4;

namespace EngiN95.Core.Rendering;

public class VertexBuffer : IVertexBuffer
{
    private readonly IGLWrapper glWrapper;
    public Handle Handle { get; }
    public int Elements { get; private set; }
    private bool disposed;

    /// <summary>
    /// Creates a new Dynamic VertexBuffer
    /// </summary>
    /// <param name="glWrapper">A Wrapper around OpenTKs GL API</param>
    /// <param name="bufferCapacity">How many Vertices can be stored in this buffer</param>
    public VertexBuffer(IGLWrapper glWrapper, int bufferCapacity = 1024)
    {
        this.glWrapper = glWrapper;
        Handle = this.glWrapper.GenBuffer();
        Bind();
        this.glWrapper.BufferData(BufferTarget.ArrayBuffer, Vertex.Size * bufferCapacity, IntPtr.Zero, BufferUsageHint.DynamicDraw);
    }

    public void BufferData(Vertex[] data)
    {
        if (data.Length == 0)
        {
            return;
        }

        Elements = data.Length;
        Bind();
        glWrapper.BufferSubData(BufferTarget.ArrayBuffer, IntPtr.Zero, data.Length * Vertex.Size, data);
    }

    public void Bind()
    {
        glWrapper.BindBuffer(BufferTarget.ArrayBuffer, Handle);
    }

    public void UnBind()
    {
        glWrapper.BindBuffer(BufferTarget.ArrayBuffer, 0);
    }
    
    ~VertexBuffer()
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