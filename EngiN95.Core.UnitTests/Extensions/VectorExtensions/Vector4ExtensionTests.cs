using EngiN95.Core.Extensions;
using FluentAssertions;
using OpenTK.Mathematics;

namespace EngiN95.Core.UnitTests.Extensions.VectorExtensions;

public class Vector4ExtensionTests
{
    [Fact]
    public void ConvertToVec2()
    {
        var vec4 = new Vector4(1, 2, 3, 4);

        var result = vec4.ToVector2();

        result.Should().Be(vec4.Xy);
    }

    [Fact]
    public void ConvertToVec3()
    {
        var vec4 = new Vector4(1, 2, 3, 4);

        var result = vec4.ToVector3();

        result.Should().Be(vec4.Xyz);
    }
}