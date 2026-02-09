using EngiN95.Core.Rendering;
using FluentAssertions;
using NSubstitute;
using OpenTK.Graphics.OpenGL4;
using Buffer = System.Buffer;

namespace EngiN95.Core.UnitTests.Rendering;

public class IndexBufferTests
{
    private const int Handle = 69;
    
    [Fact]
    public void IndexBufferCtorTest()
    {
        //Arrange
        var glWrapper = Substitute.For<IGLWrapper>();
        var data = new uint[32];
        glWrapper.GenBuffer().Returns(Handle);

        //Act
        var iBuffer = new IndexBuffer(glWrapper, data);
        
        //Assert
        iBuffer.Handle.Should().Be(Handle);
    }
}