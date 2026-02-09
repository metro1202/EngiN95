using OpenTK.Graphics.OpenGL4;

namespace EngiN95.Core.Rendering;

public class VertexArray : IVertexArray
{
    private readonly IGLWrapper glWrapper;
    public Handle Handle { get; }

    private bool disposed;

    public VertexArray(IGLWrapper glWrapper)
    {
        this.glWrapper = glWrapper;
        Handle = this.glWrapper.GenVertexArray();
        Bind();
        
        //Position
        this.glWrapper.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, Vertex.Size, 0);
        this.glWrapper.EnableVertexAttribArray(0);
        
        //TexCoords
        this.glWrapper.VertexAttribPointer(1, 2, VertexAttribPointerType.Float, false, Vertex.Size, 3 * sizeof(float));
        this.glWrapper.EnableVertexAttribArray(1);
        
        //Color
        this.glWrapper.VertexAttribPointer(2, 4, VertexAttribPointerType.Float, false, Vertex.Size, 5 * sizeof(float));
        this.glWrapper.EnableVertexAttribArray(2);
    }

    public void Bind()
    {
        glWrapper.BindVertexArray(Handle);
    }

    public void UnBind()
    {
        glWrapper.BindVertexArray(0);
    }

    ~VertexArray()
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
        glWrapper.DeleteVertexArray(Handle);
        GC.SuppressFinalize(this);
    }
}