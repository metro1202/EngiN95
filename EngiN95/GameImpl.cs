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
    
    private GameObject gameObject;
    private GameObject gameObject2;
    private GameObject gameObject3;

    protected override void Init()
    {
        
    }
    
    protected override void OnLoad()
    {
        var src = ShaderProgramSource.LoadFromFiles("Resources/Shaders/vertex.glsl", "Resources/Shaders/fragment.glsl");
        var shader = new Shader(src);

        IGLWrapper glWrapper = new GLWrapper();

        renderer = new Renderer(shader, glWrapper);
        Renderer.BackgroundColor = Color4.Black;
        
        var rm = ResourceManager.Instance;
        
        texture = rm.GetTexture("Resources/Sprites/travisfish.png");
        texture.Use();

        shader.SetMatrix4("projection", 
            Matrix4.CreateOrthographic(GameWindow.Size.X, GameWindow.Size.Y, -1, 100));

        GL.Enable(EnableCap.Blend);
        GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
        
        InitTestObjects();
    }

    private void InitTestObjects()
    {
        Matrix4.CreateScale(200f, out var scale);
        Matrix4.CreateRotationZ(0, out var rotation);
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

        gameObject = new GameObject
        {
            Shape = new RectShape(new GLWrapper()),
            Transform = new Transform(transform.ExtractTranslation(), transform.ExtractRotation(),
                transform.ExtractScale()),
            Texture = texture,
        };
        gameObject2 = new GameObject
        {
            Shape = new RectShape(new GLWrapper()),
            Transform = new Transform(transform1.ExtractTranslation(), transform1.ExtractRotation(),
                transform1.ExtractScale()),
            Texture = texture,
        };
        gameObject3 = new GameObject
        {
            Shape = new RectShape(new GLWrapper()),
            Transform = new Transform(transform2.ExtractTranslation(), transform2.ExtractRotation(),
                transform2.ExtractScale()),
            Texture = texture,
        };
    }

    protected override void OnUpdate()
    {
        var movementDirection = InputHandler.MovementDirection;
        const float speed = 800f; // pixel/s
        //Console.WriteLine(movementDirection);
        Camera.Instance.Move(movementDirection * speed * Time.DeltaTime);

        lastFrameTime += Time.DeltaTimeSpan;
        if (lastFrameTime > TimeSpan.FromSeconds(1))
        {
            lastFrameTime -=  TimeSpan.FromSeconds(1);
            Console.WriteLine(frameCounter);
            frameCounter = 0;
        }
    }

    private int frameCounter = 0;
    private TimeSpan lastFrameTime = TimeSpan.Zero;
    
    protected override void OnRender()
    {
        Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(180f * Time.TotalGameTime), out var rotation);

        gameObject.Transform.Rotation = rotation.ExtractRotation();
        gameObject2.Transform.Rotation = rotation.ExtractRotation();
        gameObject3.Transform.Rotation = rotation.ExtractRotation();

        renderer.RenderObject(gameObject, 2.0f);
        renderer.RenderObject(gameObject2, 1.0f);
        renderer.RenderObject(gameObject3, 3.0f);
        renderer.Render();
        
        frameCounter++;
    }
}