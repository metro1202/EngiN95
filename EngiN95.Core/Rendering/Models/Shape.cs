namespace EngiN95.Core.Rendering;

public class Shape
{
    private readonly IGLWrapper glWrapper;

    internal int IndexBufferLength => IndexBuffer.BufferLength;
    private IndexBuffer IndexBuffer { get; set; }
    private  VertexBuffer VertexBuffer { get; set;  }
    private  VertexArray VertexArray { get; set;  }

    public Shape(IGLWrapper glWrapper, Vertex[]? vertices, uint[]? indices)
    {
        this.glWrapper = glWrapper;

        if (vertices is not null && indices is not null)
        {
            Init(vertices,  indices);
        }
    }
    
    protected void Init(Vertex[] vertices, uint[] indices)
    {
        VertexBuffer = new VertexBuffer(glWrapper, bufferCapacity: vertices.Length);
        VertexBuffer.BufferData(vertices);
        VertexArray = new VertexArray(glWrapper);
        IndexBuffer = new IndexBuffer(glWrapper, indices);
    }

    internal void Bind()
    {
        VertexArray.Bind();
        IndexBuffer.Bind();
        VertexBuffer.Bind();
    }

    internal void Unbind()
    {
        VertexArray.UnBind();
        IndexBuffer.UnBind();
        VertexBuffer.UnBind();
    }
}