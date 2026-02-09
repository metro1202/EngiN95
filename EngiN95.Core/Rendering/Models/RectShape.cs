using OpenTK.Mathematics;

namespace EngiN95.Core.Rendering;

public class RectShape : Shape
{
    private static readonly Vertex[] Vertices = [
        new Vertex(new Vector3(1.0f, 1.0f, 0.0f), new Vector2(1.0f, 1.0f), Color4.White),
        new Vertex(new Vector3(1.0f, 0.0f, 0.0f), new Vector2(1.0f, 0.0f), Color4.White),
        new Vertex(new Vector3(0.0f, 0.0f, 0.0f), new Vector2(0.0f, 0.0f), Color4.White),
        new Vertex(new Vector3(0.0f, 1.0f, 0.0f), new Vector2(0.0f, 1.0f), Color4.White)
    ];
    
    private static readonly uint[] Indices =
    [
        0, 1, 3, 1, 2, 3
    ];
    
    public RectShape(IGLWrapper glWrapper) : base(glWrapper, null, null)
    {
        Init(Vertices, Indices);
    }
    
    public RectShape(IGLWrapper glWrapper, float height, float width, Color4 color) : base(glWrapper, null, null)
    {
        var vertices = new Vertex[Vertices.Length];
        Vertices.CopyTo(vertices);
        
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i].Color = color;
        }
        vertices[0].Position = new Vector3(width, height, 0.0f);
        vertices[1].Position = new Vector3(width, 0.0f, 0.0f);
        vertices[3].Position = new Vector3(0.0f, height, 0.0f);
        
        Init(vertices, Indices);
    }
}