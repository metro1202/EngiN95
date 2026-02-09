using OpenTK.Graphics.OpenGL4;

namespace EngiN95.Core.Rendering;

internal class GLStateHandler : IGLStateHandler
{
    private readonly IGLWrapper glWrapper;

    private Handle ActiveTexture { get; set; }
    private Handle ActiveVertexArray { get; set; }
    private Handle ActiveVertexBuffer { get; set; }
    private Handle ActiveIndexBuffer { get; set; }

    Handle IGLStateHandler.ActiveTexture
    {
        get => ActiveTexture;
        set => ActiveTexture = value;
    }
    Handle IGLStateHandler.ActiveVertexArray
    {
        get => ActiveVertexArray;
        set => ActiveVertexArray = value;
    }
    Handle IGLStateHandler.ActiveVertexBuffer
    {
        get => ActiveVertexBuffer;
        set => ActiveVertexBuffer = value;
    }
    Handle IGLStateHandler.ActiveIndexBuffer
    {
        get => ActiveIndexBuffer;
        set => ActiveIndexBuffer = value;
    }

    public GLStateHandler(IGLWrapper glWrapper)
    {
        this.glWrapper = glWrapper;
        ActiveTexture = new Handle();
        ActiveVertexArray = new Handle();
        ActiveVertexBuffer = new Handle();
        ActiveIndexBuffer = new Handle();
    }
    
    public void UseTexture(Handle handle)
    {
        if (ActiveTexture == handle)
        {
            return;
        }
        glWrapper.ActiveTexture(TextureUnit.Texture0);
        glWrapper.BindTexture(TextureTarget.Texture2D, handle);
        ActiveTexture = handle;
    }

    public void UseVertexArray(Handle handle)
    {
        if (ActiveVertexArray == handle)
        {
            return;
        }
        glWrapper.BindVertexArray(handle);
        ActiveVertexArray = handle;
    }

    public void UseVertexBuffer(Handle handle)
    {
        if (ActiveVertexBuffer == handle)
        {
            return;
        }
        glWrapper.BindBuffer(BufferTarget.ArrayBuffer, handle);
        ActiveVertexBuffer = handle;
    }

    public void UseIndexBuffer(Handle handle)
    {
        if (ActiveIndexBuffer == handle)
        {
            return;
        }
        glWrapper.BindBuffer(BufferTarget.ElementArrayBuffer, handle);
        ActiveIndexBuffer = handle;
    }
}