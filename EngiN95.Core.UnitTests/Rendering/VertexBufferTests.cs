using EngiN95.Core.Rendering;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ReceivedExtensions;
using OpenTK.Graphics.OpenGL4;

namespace EngiN95.Core.UnitTests.Rendering;

public class DynamicVertexBufferTests
{
    private const int BufferHandle = 123;
    
    [Fact]
    public void CreateVertexBufferTest()
    {
        //Arrange
        var glWrapper = Substitute.For<IGLWrapper>();
        glWrapper.GenBuffer().Returns(BufferHandle);
        
        //Act
        var vBuffer = new VertexBuffer(glWrapper, 128);
        
        //Assert
        vBuffer.Handle.Should().Be(BufferHandle);
    }

    [Fact]
    public void BufferData_ShouldReturnIfDataIsEmpty()
    {
        //Arrange
        var glWrapper = Substitute.For<IGLWrapper>();
        glWrapper.GenBuffer().Returns(BufferHandle);
        var vBuffer = new VertexBuffer(glWrapper);
        Vertex[] data = [];
        
        //Act
        vBuffer.BufferData(data);
        
        //Assert
        glWrapper.Received(Quantity.None()).BufferSubData(BufferTarget.ArrayBuffer, Arg.Any<IntPtr>(), Arg.Any<int>(), data);
    }
}