using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace EngiN95.Core.Rendering;

public class Renderer
{
    public static Color4 BackgroundColor = Color4.CornflowerBlue;
    
    private readonly IShader shader;
    private readonly IGLWrapper glWrapper;
    
    private IndexBuffer IndexBuffer { get; }
    private  VertexBuffer VertexBuffer { get; }
    private  VertexArray VertexArray { get; }
    private  uint[] Indices { get; }
    private  Vertex[] Vertices { get; }
    

    private readonly List<RenderObjectInfo> renderingQueue = new();

    public Renderer(IShader shader, IGLWrapper glWrapper)
    {
        this.shader = shader;
        this.glWrapper = glWrapper;
        
        Vertices = new[]
        {
            new Vertex(new Vector3(1, 1, 0.0f), new Vector2(1.0f, 1.0f), Color4.White),
            new Vertex(new Vector3(1, 0, 0.0f), new Vector2(1.0f, 0.0f), Color4.White),
            new Vertex(new Vector3(0, 0, 0.0f), new Vector2(0.0f, 0.0f), Color4.White),
            new Vertex(new Vector3(0, 1, 0.0f), new Vector2(0.0f, 1.0f), Color4.White)
        };
        Indices = new uint[]
        {
            0, 1, 3, 1, 2, 3
        };
        
        VertexBuffer = new VertexBuffer(glWrapper);
        VertexBuffer.BufferData(Vertices);
        VertexArray = new VertexArray(glWrapper);
        IndexBuffer = new IndexBuffer(glWrapper, Indices);
        
        VertexArray.Bind();
        IndexBuffer.Bind();
        VertexBuffer.Bind();
    }

    public void RenderObject(Texture texture, Matrix4 transform)
    {
        renderingQueue.Add(new RenderObjectInfo
        {
            Texture = texture,
            Transform = transform
        });
    }

    public void Render()
    {
        GL.Clear(ClearBufferMask.ColorBufferBit);
        GL.ClearColor(Renderer.BackgroundColor);
        
        shader.Use();
        shader.SetMatrix4("view", Camera.Instance.ToViewMatrix());

        foreach (var obj in renderingQueue)
        {
            shader.SetMatrix4("transform", obj.Transform);
            
            obj.Texture.Use();
            
            GL.DrawElements(PrimitiveType.Triangles, Indices.Length, DrawElementsType.UnsignedInt, 0);
            
#if DEBUG
            var error = GL.GetError();
            if (error != ErrorCode.NoError)
            {
                System.Diagnostics.Debug.WriteLine($"OpenGL error occurred: {error}");
            }
#endif
        }
        
        renderingQueue.Clear();
    }
    
    private struct RenderObjectInfo
    {
        internal Texture Texture { get; init; }
        internal Matrix4 Transform { get; init; }
    }
}