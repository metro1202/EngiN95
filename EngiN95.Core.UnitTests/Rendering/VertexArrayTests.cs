using EngiN95.Core.Rendering;
using FluentAssertions;
using NSubstitute;
using OpenTK.Graphics.OpenGL4;

namespace EngiN95.Core.UnitTests.Rendering;

public class VertexArrayTests
{
    private const int Handle = 69;

    [Fact]
    public void TestVertexArrayCtor()
    {
        //Arrange
        var glWrapper = Substitute.For<IGLWrapper>();
        glWrapper.GenVertexArray().Returns(Handle);
        
        //Act
        var vArray = new VertexArray(glWrapper);
        
        //Assert
        vArray.Handle.Should().Be(Handle);
    }
}