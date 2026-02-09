using System.Runtime.InteropServices;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace EngiN95.Core.Rendering;

public interface IGLWrapper
{
    //Buffer
    int GenBuffer();
    void BindBuffer(BufferTarget target, int buffer);
    void BufferData(BufferTarget target, int size, IntPtr data, BufferUsageHint usage);
    void BufferData<T>(BufferTarget target, int size, [In, Out] T[] data, BufferUsageHint usage) where T : struct;
    void BufferSubData<T>(BufferTarget target, IntPtr offset, int size, [In, Out] T[] data) where T : struct;
    void DeleteBuffer(int buffer);

    //VA
    int GenVertexArray();
    void BindVertexArray(int array);
    void VertexAttribPointer(int index, int size, VertexAttribPointerType type, bool normalized, int stride, int offset);
    void EnableVertexAttribArray(int index);
    void DeleteVertexArray(int array);
    
    //Shader
    int CreateShader(ShaderType type);
    void ShaderSource(int shader, string source);
    void CompileShader(int shader);
    void GetShader(int shader, ShaderParameter pname, out int @params);
    string GetShaderInfoLog(int shader);
    void DetachShader(int program, int shader);
    void DeleteShader(int shader);

    //Program
    int CreateProgram();
    void AttachShader(int program, int shader);
    void LinkProgram(int program);
    void GetProgram(int program, GetProgramParameterName pname, out int @params);
    void UseProgram(int program);
    
    //Uniforms
    string GetActiveUniform(int program, int uniformIndex, out int size, out ActiveUniformType type);
    int GetUniformLocation(int program, string name);
    void Uniform1(int location, float value);
    void Uniform2(int location, Vector2 vector);
    void Uniform3(int location, Vector3 vector);
    void Uniform4(int location, Vector4 vector);
    void Uniform4(int location, Color4 color);
    void Uniform4(int location, Quaternion quaternion);
    void UniformMatrix2(int location, bool transpose, ref Matrix2 matrix);
    void UniformMatrix3(int location, bool transpose, ref Matrix3 matrix);
    void UniformMatrix4(int location, bool transpose, ref Matrix4 matrix);

    //Texture
    int GenTexture();
    void ActiveTexture(TextureUnit texture);
    void BindTexture(TextureTarget target, int texture);
    void TexImage2D(TextureTarget target, int level, PixelInternalFormat internalformat, int width, int height, int border, PixelFormat format, PixelType type, IntPtr pixels);
    void TexParameter(TextureTarget target, TextureParameterName pname, int param);
    void GenerateMipmap(GenerateMipmapTarget target);
    void DeleteTexture(int handle);

    //Render
    void Clear(ClearBufferMask mask);
    void ClearColor(Color4 color);
    void DrawElements(PrimitiveType mode, int count, DrawElementsType type, int indices);
    ErrorCode GetError();
}