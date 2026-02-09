using EngiN95.Core.IO;
using FluentAssertions;
using NSubstitute;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace EngiN95.Core.UnitTests.Input;

public class InputHandlerTests
{
    [Theory]
    [InlineData(0,0)]
    [InlineData(12,40)]
    [InlineData(float.MinValue, float.MaxValue)]
    public void MousePosition_ShouldReturnProvidedPosition(float x, float y)
    {
        //Arrange
        var keyboardInputHandler = Substitute.For<IKeyboardInputHandler>();
        var mouseInputHandler = Substitute.For<IMouseInputHandler>();
        IInputHandler sut = new InputHandler(mouseInputHandler, keyboardInputHandler);
        var mousePos = new Vector2(x, y);
        mouseInputHandler.Position.Returns(mousePos);

        //Act
        var result = sut.MousePosition;

        //Assert
        result.Should().Be(mousePos);
    }
    
    [Theory]
    [InlineData(0,0)]
    [InlineData(12,40)]
    [InlineData(float.MinValue, float.MaxValue)]
    public void PreviousMousePosition_ShouldReturnProvidedPosition(float x, float y)
    {
        //Arrange
        var keyboardInputHandler = Substitute.For<IKeyboardInputHandler>();
        var mouseInputHandler = Substitute.For<IMouseInputHandler>();
        IInputHandler sut = new InputHandler(mouseInputHandler, keyboardInputHandler);
        var previousPos = new Vector2(x, y);
        mouseInputHandler.PreviousPosition.Returns(previousPos);

        //Act
        var result = sut.PreviousMousePosition;

        //Assert
        result.Should().Be(previousPos);
    }
    
    [Theory]
    [InlineData(0,0)]
    [InlineData(12,40)]
    [InlineData(float.MinValue, float.MaxValue)]
    public void MousePositionDelta_ShouldReturnProvidedDelta(float x, float y)
    {
        //Arrange
        var keyboardInputHandler = Substitute.For<IKeyboardInputHandler>();
        var mouseInputHandler = Substitute.For<IMouseInputHandler>();
        IInputHandler sut = new InputHandler(mouseInputHandler, keyboardInputHandler);
        var posDelta = new Vector2(x, y);
        mouseInputHandler.PositionDelta.Returns(posDelta);

        //Act
        var result = sut.MousePositionDelta;

        //Assert
        result.Should().Be(posDelta);
    }
    
    [Theory]
    [InlineData(0,0)]
    [InlineData(12,40)]
    [InlineData(float.MinValue, float.MaxValue)]
    public void MouseScroll_ShouldReturnProvidedScroll(float x, float y)
    {
        //Arrange
        var keyboardInputHandler = Substitute.For<IKeyboardInputHandler>();
        var mouseInputHandler = Substitute.For<IMouseInputHandler>();
        IInputHandler sut = new InputHandler(mouseInputHandler, keyboardInputHandler);
        var scroll = new Vector2(x, y);
        mouseInputHandler.Scroll.Returns(scroll);

        //Act
        var result = sut.MouseScroll;

        //Assert
        result.Should().Be(scroll);
    }
    
    [Theory]
    [InlineData(0,0)]
    [InlineData(12,40)]
    [InlineData(float.MinValue, float.MaxValue)]
    public void PreviousMouseScroll_ShouldReturnProvidedScroll(float x, float y)
    {
        //Arrange
        var keyboardInputHandler = Substitute.For<IKeyboardInputHandler>();
        var mouseInputHandler = Substitute.For<IMouseInputHandler>();
        IInputHandler sut = new InputHandler(mouseInputHandler, keyboardInputHandler);
        var previousScroll = new Vector2(x, y);
        mouseInputHandler.PreviousScroll.Returns(previousScroll);

        //Act
        var result = sut.PreviousMouseScroll;

        //Assert
        result.Should().Be(previousScroll);
    }
    
    [Theory]
    [InlineData(0,0)]
    [InlineData(12,40)]
    [InlineData(float.MinValue, float.MaxValue)]
    public void MouseScrollDelta_ShouldReturnProvidedScrollDelta(float x, float y)
    {
        //Arrange
        var keyboardInputHandler = Substitute.For<IKeyboardInputHandler>();
        var mouseInputHandler = Substitute.For<IMouseInputHandler>();
        IInputHandler sut = new InputHandler(mouseInputHandler, keyboardInputHandler);
        var scrollDelta = new Vector2(x, y);
        mouseInputHandler.ScrollDelta.Returns(scrollDelta);

        //Act
        var result = sut.MouseScrollDelta;

        //Assert
        result.Should().Be(scrollDelta);
    }
    
    [Theory]
    [InlineData(0,0)]
    [InlineData(12,40)]
    [InlineData(float.MinValue, float.MaxValue)]
    public void MouseX_ShouldReturnProvidedXPosition(float x, float y)
    {
        //Arrange
        var keyboardInputHandler = Substitute.For<IKeyboardInputHandler>();
        var mouseInputHandler = Substitute.For<IMouseInputHandler>();
        IInputHandler sut = new InputHandler(mouseInputHandler, keyboardInputHandler);
        var position = new Vector2(x, y);
        mouseInputHandler.Position.Returns(position);

        //Act
        float result = sut.MouseX;

        //Assert
        result.Should().Be(position.X);
    }
    
    [Theory]
    [InlineData(0,0)]
    [InlineData(12,40)]
    [InlineData(float.MinValue, float.MaxValue)]
    public void MouseY_ShouldReturnProvidedYPosition(float x, float y)
    {
        //Arrange
        var keyboardInputHandler = Substitute.For<IKeyboardInputHandler>();
        var mouseInputHandler = Substitute.For<IMouseInputHandler>();
        IInputHandler sut = new InputHandler(mouseInputHandler, keyboardInputHandler);
        var position = new Vector2(x, y);
        mouseInputHandler.Position.Returns(position);

        //Act
        float result = sut.MouseY;

        //Assert
        result.Should().Be(position.Y);
    }
    
    [Theory]
    [InlineData(0,0)]
    [InlineData(12,40)]
    [InlineData(float.MinValue, float.MaxValue)]
    public void PreviousMouseX_ShouldReturnProvidedXPosition(float x, float y)
    {
        //Arrange
        var keyboardInputHandler = Substitute.For<IKeyboardInputHandler>();
        var mouseInputHandler = Substitute.For<IMouseInputHandler>();
        IInputHandler sut = new InputHandler(mouseInputHandler, keyboardInputHandler);
        var previousPos = new Vector2(x, y);
        mouseInputHandler.PreviousPosition.Returns(previousPos);

        //Act
        float result = sut.PreviousMouseX;

        //Assert
        result.Should().Be(previousPos.X);
    }
    
    [Theory]
    [InlineData(0,0)]
    [InlineData(12,40)]
    [InlineData(float.MinValue, float.MaxValue)]
    public void PreviousMouseY_ShouldReturnProvidedYPosition(float x, float y)
    {
        //Arrange
        var keyboardInputHandler = Substitute.For<IKeyboardInputHandler>();
        var mouseInputHandler = Substitute.For<IMouseInputHandler>();
        IInputHandler sut = new InputHandler(mouseInputHandler, keyboardInputHandler);
        var previousPos = new Vector2(x, y);
        mouseInputHandler.PreviousPosition.Returns(previousPos);

        //Act
        float result = sut.PreviousMouseY;

        //Assert
        result.Should().Be(previousPos.Y);
    }

    [Theory]
    [InlineData(true, MouseButton.Button1)]
    [InlineData(false, MouseButton.Button2)]
    public void IsMouseButtonDown_ShouldReturnIfMouseButtonIsDown(bool isDown, MouseButton button)
    {
        //Arrange
        var keyboardInputHandler = Substitute.For<IKeyboardInputHandler>();
        var mouseInputHandler = Substitute.For<IMouseInputHandler>();
        IInputHandler sut = new InputHandler(mouseInputHandler, keyboardInputHandler);
        mouseInputHandler.IsButtonDown(button).Returns(isDown);
        
        //Act
        bool result = sut.IsMouseButtonDown(button);
        
        //Assert
        result.Should().Be(isDown);
    }
    
    [Theory]
    [InlineData(true, MouseButton.Button1)]
    [InlineData(false, MouseButton.Button2)]
    public void WasMouseButtonDown_ShouldReturnIfMouseButtonWasDown(bool wasDown, MouseButton button)
    {
        //Arrange
        var keyboardInputHandler = Substitute.For<IKeyboardInputHandler>();
        var mouseInputHandler = Substitute.For<IMouseInputHandler>();
        IInputHandler sut = new InputHandler(mouseInputHandler, keyboardInputHandler);
        mouseInputHandler.WasButtonDown(button).Returns(wasDown);
        
        //Act
        bool result = sut.WasMouseButtonDown(button);
        
        //Assert
        result.Should().Be(wasDown);
    }
    
    [Theory]
    [InlineData(true, MouseButton.Button1)]
    [InlineData(false, MouseButton.Button2)]
    public void IsMouseButtonPressed_ShouldReturnIfMouseButtonIsPressed(bool isPressed, MouseButton button)
    {
        //Arrange
        var keyboardInputHandler = Substitute.For<IKeyboardInputHandler>();
        var mouseInputHandler = Substitute.For<IMouseInputHandler>();
        IInputHandler sut = new InputHandler(mouseInputHandler, keyboardInputHandler);
        mouseInputHandler.IsButtonPressed(button).Returns(isPressed);
        
        //Act
        bool result = sut.IsMouseButtonPressed(button);
        
        //Assert
        result.Should().Be(isPressed);
    }
    
    [Theory]
    [InlineData(true, MouseButton.Button1)]
    [InlineData(false, MouseButton.Button2)]
    public void IsMouseButtonReleased_ShouldReturnIfMouseButtonIsReleased(bool isReleased, MouseButton button)
    {
        //Arrange
        var keyboardInputHandler = Substitute.For<IKeyboardInputHandler>();
        var mouseInputHandler = Substitute.For<IMouseInputHandler>();
        IInputHandler sut = new InputHandler(mouseInputHandler, keyboardInputHandler);
        mouseInputHandler.IsButtonReleased(button).Returns(isReleased);
        
        //Act
        bool result = sut.IsMouseButtonReleased(button);
        
        //Assert
        result.Should().Be(isReleased);
    }
    
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void IsAnyMouseButtonDown_ShouldReturnIfAnyMouseButtonIsDown(bool isAnyDown)
    {
        //Arrange
        var keyboardInputHandler = Substitute.For<IKeyboardInputHandler>();
        var mouseInputHandler = Substitute.For<IMouseInputHandler>();
        IInputHandler sut = new InputHandler(mouseInputHandler, keyboardInputHandler);
        mouseInputHandler.IsAnyButtonDown().Returns(isAnyDown);
        
        //Act
        bool result = sut.IsAnyMouseButtonDown();
        
        //Assert
        result.Should().Be(isAnyDown);
    }
    
    [Theory]
    [InlineData(true, Keys.W)]
    [InlineData(false, Keys.Space)]
    public void IsKeyDown_ShouldReturnIfKeyIsDown(bool isDown, Keys key)
    {
        //Arrange
        var keyboardInputHandler = Substitute.For<IKeyboardInputHandler>();
        var mouseInputHandler = Substitute.For<IMouseInputHandler>();
        IInputHandler sut = new InputHandler(mouseInputHandler, keyboardInputHandler);
        keyboardInputHandler.IsKeyDown(key).Returns(isDown);
        
        //Act
        bool result = sut.IsKeyDown(key);
        
        //Assert
        result.Should().Be(isDown);
    }
    
    [Theory]
    [InlineData(true, Keys.W)]
    [InlineData(false, Keys.Space)]
    public void WasKeyDown_ShouldReturnIfKeyWasDown(bool wasDown, Keys key)
    {
        //Arrange
        var keyboardInputHandler = Substitute.For<IKeyboardInputHandler>();
        var mouseInputHandler = Substitute.For<IMouseInputHandler>();
        IInputHandler sut = new InputHandler(mouseInputHandler, keyboardInputHandler);
        keyboardInputHandler.WasKeyDown(key).Returns(wasDown);
        
        //Act
        bool result = sut.WasKeyDown(key);
        
        //Assert
        result.Should().Be(wasDown);
    }
    
    [Theory]
    [InlineData(true, Keys.W)]
    [InlineData(false, Keys.Space)]
    public void IsKeyPressed_ShouldReturnIfKeyIsPressed(bool isPressed, Keys key)
    {
        //Arrange
        var keyboardInputHandler = Substitute.For<IKeyboardInputHandler>();
        var mouseInputHandler = Substitute.For<IMouseInputHandler>();
        IInputHandler sut = new InputHandler(mouseInputHandler, keyboardInputHandler);
        keyboardInputHandler.IsKeyPressed(key).Returns(isPressed);
        
        //Act
        bool result = sut.IsKeyPressed(key);
        
        //Assert
        result.Should().Be(isPressed);
    }
    
    [Theory]
    [InlineData(true, Keys.W)]
    [InlineData(false, Keys.Space)]
    public void IsKeyReleased_ShouldReturnIfKeyIsReleased(bool isReleased, Keys key)
    {
        //Arrange
        var keyboardInputHandler = Substitute.For<IKeyboardInputHandler>();
        var mouseInputHandler = Substitute.For<IMouseInputHandler>();
        IInputHandler sut = new InputHandler(mouseInputHandler, keyboardInputHandler);
        keyboardInputHandler.IsKeyReleased(key).Returns(isReleased);
        
        //Act
        bool result = sut.IsKeyReleased(key);
        
        //Assert
        result.Should().Be(isReleased);
    }
    
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void IsAnyKeyDown_ShouldReturnIfAnyKeyIsDown(bool isAnyDown)
    {
        //Arrange
        var keyboardInputHandler = Substitute.For<IKeyboardInputHandler>();
        var mouseInputHandler = Substitute.For<IMouseInputHandler>();
        IInputHandler sut = new InputHandler(mouseInputHandler, keyboardInputHandler);
        keyboardInputHandler.IsAnyKeyDown().Returns(isAnyDown);
        
        //Act
        bool result = sut.IsAnyKeyDown();
        
        //Assert
        result.Should().Be(isAnyDown);
    }

    [Theory]
    [InlineData(true, true, true, true, 0, 0)]
    [InlineData(true, false, false, false, 0, 1)]
    [InlineData(false, true, true, false, -1, -1)]
    public void MovementDirection_ShouldCalculateAndReturnTheMovementDirection(
        bool wDown, bool aDown, bool sDown, bool dDown, float expectedX, float expectedY)

    {
        //Arrange
        var keyboardInputHandler = Substitute.For<IKeyboardInputHandler>();
        var mouseInputHandler = Substitute.For<IMouseInputHandler>();
        IInputHandler sut = new InputHandler(mouseInputHandler, keyboardInputHandler);
        keyboardInputHandler.IsKeyDown(Keys.W).Returns(wDown);
        keyboardInputHandler.IsKeyDown(Keys.A).Returns(aDown);
        keyboardInputHandler.IsKeyDown(Keys.S).Returns(sDown);
        keyboardInputHandler.IsKeyDown(Keys.D).Returns(dDown);
        
        //Act
        var result = sut.MovementDirection;

        //Assert
        result.Should().Be(new Vector2(expectedX, expectedY));
    }
}