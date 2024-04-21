using EngiN95.Core;
using EngiN95.Core.Management;
using EngiN95.Core.Rendering;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace EngiN95;

#pragma warning disable CS8618

internal class GameImpl : Game
{
    public GameImpl(string windowTitle, int initialWindowWidth, int initialWindowHeight) 
        : base(windowTitle, initialWindowWidth, initialWindowHeight)
    {
        
    }

    private Renderer renderer;
    private Texture texture;

    protected override void Init()
    {
        
    }
    
    protected override void OnLoad()
    {
        var src = ShaderProgramSource.LoadFromFiles("Resources/Shaders/vertex.glsl", "Resources/Shaders/fragment.glsl");
        var shader = new Shader(src);

        IGLWrapper glWrapper = new GLWrapper();

        renderer = new Renderer(shader, glWrapper);

        var rm = new ResourceManager(glWrapper);
        
        texture = rm.GetTexture("Resources/Sprites/travisfish.png");
        texture.Use();

        shader.SetMatrix4("projection", 
            Matrix4.CreateOrthographic(GameWindow.Size.X, GameWindow.Size.Y, -1, 100));

        GL.Enable(EnableCap.Blend);
        GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
    }

    protected override void OnUpdate()
    {
        var movementDirection = InputHandler.MovementDirection;
        const float speed = 800f; // pixel/s
        //Console.WriteLine(movementDirection);
        Camera.Instance.Move(movementDirection * speed * Time.DeltaTime);
    }

    protected override void OnRender()
    {
        Matrix4.CreateScale(200f, out var scale);
        Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(180f * Time.TotalGameTime), out var rotation);
        Matrix4.CreateTranslation(400, 0, 0, out var translation);
        Matrix4.CreateTranslation(300, 0, 0, out var translation1);
        Matrix4.CreateTranslation(200, 0, 0, out var translation2);
        
        var transform = Matrix4.Identity;
        transform *= scale;
        transform *= rotation;
        transform *= translation;
        
        var transform1 = Matrix4.Identity;
        transform1 *= scale;
        transform1 *= rotation;
        transform1 *= translation1;
        
        var transform2 = Matrix4.Identity;
        transform2 *= scale;
        transform2 *= rotation;
        transform2 *= translation2;
        
        renderer.RenderObject(texture, transform);
        renderer.RenderObject(texture, transform1);
        renderer.RenderObject(texture, transform2);
        renderer.Render();
    }
}