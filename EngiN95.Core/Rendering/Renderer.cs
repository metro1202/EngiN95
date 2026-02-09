using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace EngiN95.Core.Rendering;

public class Renderer
{
    public static Color4 BackgroundColor = Color4.CornflowerBlue;
    
    private readonly IShader shader;
    private readonly IGLWrapper glWrapper;
    
    private readonly List<RenderCommand> renderingQueue = new();
    private uint sequence;

    public Renderer(IShader shader, IGLWrapper glWrapper)
    {
        this.shader = shader;
        this.glWrapper = glWrapper;

        sequence = 0;
    }

    public void RenderObject(GameObject gameObject, float? depth = null)
    {
        if (gameObject.Shape is null || gameObject.Texture is null)
        {
            return;
        }
        
        var transformMatrix = gameObject.Transform.GetTransformationMatrix();

        renderingQueue.Add(new RenderCommand(
            gameObject.Shape,
            gameObject.Texture,
            transformMatrix,
            depth ?? transformMatrix.M43,
            sequence++));
    }

    public void Render()
    {
        glWrapper.Clear(ClearBufferMask.ColorBufferBit);
        glWrapper.ClearColor(BackgroundColor);
        
        shader.Use();
        shader.SetMatrix4("view", Camera.Instance.ToViewMatrix());

        foreach (var renderCommand in renderingQueue)
        {
            shader.SetMatrix4("transform", renderCommand.Transform);
            
            renderCommand.Texture.Use();
            renderCommand.Shape.Bind();
            
            glWrapper.DrawElements(PrimitiveType.Triangles, renderCommand.Shape.IndexBufferLength, DrawElementsType.UnsignedInt, 0);
            
            renderCommand.Shape.Unbind();
            
#if DEBUG
            var error = glWrapper.GetError();
            if (error != ErrorCode.NoError)
            {
                System.Diagnostics.Debug.WriteLine($"OpenGL error occurred: {error}");
            }
#endif
        }

        renderingQueue.Clear();
        sequence = 0;
    }
    
    private sealed class RenderCommand
    {
        public RenderCommand(Shape shape, Texture texture, Matrix4 transform, float depth, uint sequence)
        {
            Shape = shape;
            Texture = texture;
            Transform = transform;
            Depth = depth;
            Sequence = sequence;
        }

        public Shape Shape { get; set; }
        public Texture Texture { get; init; }
        public Matrix4 Transform { get; init; }
        public float Depth { get; init; }
        public uint Sequence { get; init; }
    }
}