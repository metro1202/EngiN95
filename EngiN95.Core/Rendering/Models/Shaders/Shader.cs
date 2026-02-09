using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace EngiN95.Core.Rendering;

public class Shader : IShader
{
    public int ShaderHandle { get; private set; }
    public bool Compiled { get; private set; }
    
    private readonly IDictionary<string, int> uniformLocations;
    private ShaderProgramSource ShaderProgramSource { get; }
    
    public Shader(ShaderProgramSource shaderProgramSource, bool compile = true)
    {
        ShaderProgramSource = shaderProgramSource;
        uniformLocations = new Dictionary<string, int>();
        if (compile)
        {
            CompileShader();
        }
    }

    public int GetUniformLocation(string uniformName) => uniformLocations[uniformName];

    public bool CompileShader()
    {
        if (ShaderProgramSource == null)
        {
            throw new NullReferenceException($"'{nameof(ShaderProgramSource)}' cannot be null");
        }

        if (Compiled)
        {
            Console.WriteLine($"Shader '{this}' is already compiled");
            return false;
        }
        
        int vertexShaderId = GL.CreateShader(ShaderType.VertexShader);
        GL.ShaderSource(vertexShaderId, ShaderProgramSource.VertexShaderSource);
        GL.CompileShader(vertexShaderId);
        GL.GetShader(vertexShaderId, ShaderParameter.CompileStatus, out int vertexShaderCompCode);
        if (vertexShaderCompCode != (int) All.True)
        {
            Console.WriteLine(GL.GetShaderInfoLog(vertexShaderId));
            return false;
        }

        int fragmentShaderId = GL.CreateShader(ShaderType.FragmentShader);
        GL.ShaderSource(fragmentShaderId, ShaderProgramSource.FragmentShaderSource);
        GL.CompileShader(fragmentShaderId);
        GL.GetShader(fragmentShaderId, ShaderParameter.CompileStatus, out int fragmentShaderCompCode);
        if (fragmentShaderCompCode != (int) All.True)
        {
            Console.WriteLine(GL.GetShaderInfoLog(fragmentShaderId));
            return false;
        }

        ShaderHandle = GL.CreateProgram();
        GL.AttachShader(ShaderHandle, vertexShaderId);
        GL.AttachShader(ShaderHandle, fragmentShaderId);
        GL.LinkProgram(ShaderHandle);
        
        GL.DetachShader(ShaderHandle, vertexShaderId);
        GL.DetachShader(ShaderHandle, fragmentShaderId);
        GL.DeleteShader(vertexShaderId);
        GL.DeleteShader(fragmentShaderId);

        GL.GetProgram(ShaderHandle, GetProgramParameterName.ActiveUniforms, out int uniformCount);
        for (var i = 0; i < uniformCount; i++)
        {
            string key = GL.GetActiveUniform(ShaderHandle, i, out _, out _);
            int location = GL.GetUniformLocation(ShaderHandle, key);
            uniformLocations.Add(key, location);
        }
        
        Compiled = true;
        return true;
    }

    public void Use()
    {
        if (Compiled)
        {
            GL.UseProgram(ShaderHandle);
            return;
        }
        Console.WriteLine($"Shader '{this}' has not been Compiled yet");
    }
    
    public void SetInt(string name, int data)
    {
        GL.UseProgram(ShaderHandle);
        GL.Uniform1(uniformLocations[name], data);
    }

    public void SetFloat(string name, float data)
    {
        GL.UseProgram(ShaderHandle);
        GL.Uniform1(uniformLocations[name], data);
    }

    public void SetMatrix4(string name, Matrix4 data)
    {
        GL.UseProgram(ShaderHandle);
        GL.UniformMatrix4(uniformLocations[name], true, ref data);
    }

    public void SetVector3(string name, Vector3 data)
    {
        GL.UseProgram(ShaderHandle);
        GL.Uniform3(uniformLocations[name], data);
    }
}