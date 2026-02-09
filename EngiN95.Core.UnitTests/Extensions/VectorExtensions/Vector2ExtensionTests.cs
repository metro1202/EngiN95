using EngiN95.Core.Extensions;
using FluentAssertions;
using OpenTK.Mathematics;

namespace EngiN95.Core.UnitTests.Extensions.VectorExtensions;

public class Vector2ExtensionTests
{
    [Fact]
    public void ConvertToVec3_WithDefaultZ()
    {
        var vec2 = new Vector2(3, 4);

        var result = vec2.ToVector3();

        result.Xy.Should().Be(vec2);
        result.Z.Should().Be(0);
    }
    
    [Fact]
    public void ConvertToVec3_WithSpecificZ()
    {
        var vec2 = new Vector2(3, 4);

        var result = vec2.ToVector3(10);

        result.Xy.Should().Be(vec2);
        result.Z.Should().Be(10);
    }

    [Fact]
    public void ConvertToVec4_WithDefaultZW()
    {
        //Arrange
        var vec2 = new Vector2(3, 4);

        //Act
        var result = vec2.ToVector4();

        //Assert
        result.Xy.Should().Be(vec2);
        result.Zw.Should().Be(Vector2.Zero);
    }

    [Fact]
    public void ConvertToVec4_WithSpecificZW()
    {
        //Arrange
        var vec2 = new Vector2(3, 4);

        //Act
        var result = vec2.ToVector4(10,22);

        //Assert
        result.Xy.Should().Be(vec2);
        result.Zw.Should().Be(new Vector2(10,22));
    }
}