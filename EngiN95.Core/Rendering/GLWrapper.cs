using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace EngiN95.Core.Rendering;

public class GLWrapper : IGLWrapper
{
    //Buffer
    public int GenBuffer() => GL.GenBuffer();
    
    public void BindBuffer(BufferTarget target, int buffer) => GL.BindBuffer(target, buffer);
    
    public void BufferData(BufferTarget target, int size, IntPtr data, BufferUsageHint usage) =>
        GL.BufferData(target, size, data, usage);

    public void BufferData<T>(BufferTarget target, int size, T[] data, BufferUsageHint usage) where T : struct =>
        GL.BufferData(target, size, data, usage);

    public void BufferSubData<T>(BufferTarget target, IntPtr offset, int size, T[] data) where T : struct =>
        GL.BufferSubData(target, offset, size, data);
    
    public void DeleteBuffer(int buffer) => GL.DeleteBuffer(buffer);
    
    
    //Vertex Array
    public int GenVertexArray() => GL.GenVertexArray();
    
    public void BindVertexArray(int array) => GL.BindVertexArray(array);
    
    public void VertexAttribPointer(int index, int size, VertexAttribPointerType type, bool normalized, int stride,
        int offset) => GL.VertexAttribPointer(index, size, type, normalized, stride, offset);
    
    public void EnableVertexAttribArray(int index) => GL.EnableVertexAttribArray(index);
    
    public void DeleteVertexArray(int array) => GL.DeleteVertexArray(array);

    
    //Shader
    public int CreateShader(ShaderType type) => GL.CreateShader(type);

    public void ShaderSource(int shader, string source) => GL.ShaderSource(shader, source);

    public void CompileShader(int shader) => GL.CompileShader(shader);

    public void GetShader(int shader, ShaderParameter pname, out int @params) =>
        GL.GetShader(shader, pname, out @params);

    public string GetShaderInfoLog(int shader) => GL.GetShaderInfoLog(shader);

    public void DetachShader(int program, int shader) => GL.DetachShader(program, shader);

    public void DeleteShader(int shader) => GL.DeleteShader(shader);

    
    //Program
    public int CreateProgram() => GL.CreateProgram();

    public void AttachShader(int program, int shader) => GL.AttachShader(program, shader);

    public void LinkProgram(int program) => GL.LinkProgram(program);

    public void GetProgram(int program, GetProgramParameterName pname, out int @params) =>
        GL.GetProgram(program, pname, out @params);

    public void UseProgram(int program) => GL.UseProgram(program);

    
    //Uniforms
    public string GetActiveUniform(int program, int uniformIndex, out int size, out ActiveUniformType type) =>
        GL.GetActiveUniform(program, uniformIndex, out size, out type);

    public int GetUniformLocation(int program, string name) => GL.GetUniformLocation(program, name);

    public void Uniform1(int location, float value) => GL.Uniform1(location, value);

    public void Uniform2(int location, Vector2 vector) => GL.Uniform2(location, vector);

    public void Uniform3(int location, Vector3 vector) => GL.Uniform3(location, vector);

    public void Uniform4(int location, Vector4 vector) => GL.Uniform4(location, vector);

    public void Uniform4(int location, Color4 color) => GL.Uniform4(location, color);

    public void Uniform4(int location, Quaternion quaternion) => GL.Uniform4(location, quaternion);

    public void UniformMatrix2(int location, bool transpose, ref Matrix2 matrix) =>
        GL.UniformMatrix2(location, transpose, ref matrix);

    public void UniformMatrix3(int location, bool transpose, ref Matrix3 matrix) =>
        GL.UniformMatrix3(location, transpose, ref matrix);

    public void UniformMatrix4(int location, bool transpose, ref Matrix4 matrix) =>
        GL.UniformMatrix4(location, transpose, ref matrix);

    
    //Texture
    public int GenTexture() => GL.GenTexture();

    public void ActiveTexture(TextureUnit texture) => GL.ActiveTexture(texture);

    public void BindTexture(TextureTarget target, int texture) => GL.BindTexture(target, texture);

    public void TexImage2D(TextureTarget target, int level, PixelInternalFormat internalformat, int width, int height,
        int border, PixelFormat format, PixelType type, IntPtr pixels) => 
        GL.TexImage2D(target, level, internalformat, width, height, border, format, type, pixels);

    public void TexParameter(TextureTarget target, TextureParameterName pname, int param) =>
        GL.TexParameter(target, pname, param);

    public void GenerateMipmap(GenerateMipmapTarget target) => GL.GenerateMipmap(target);

    public void DeleteTexture(int handle) => GL.DeleteTexture(handle);
    
    
    //Render
    public void Clear(ClearBufferMask mask) =>  GL.Clear(mask);
    public void ClearColor(Color4 color) => GL.ClearColor(color);
    public void DrawElements(PrimitiveType mode, int count, DrawElementsType type, int indices) =>  GL.DrawElements(mode, count, type, indices);
    public ErrorCode GetError() => GL.GetError();
}