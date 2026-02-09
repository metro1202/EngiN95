using EngiN95.Core.Rendering;
using FluentAssertions;

namespace EngiN95.Core.UnitTests.Rendering;

public class HandleTests
{
    [Fact]
    public void Value_ShouldInitializeProperly()
    {
        //Arrange
        const int value = 10;
        
        //Act
        var handle = new Handle
        {
            Value = value
        };
        
        //Assert
        handle.Value.Should().Be(value);
    }

    [Fact]
    public void Handle_ShouldImplicitlyCastToInt()
    {
        //Arrange
        const int value = 12;
        var handle = new Handle {Value = value};

        //Act
        int implicitCast = handle;

        //Assert
        implicitCast.Should().Be(value);
    }

    [Fact]
    public void Int_ShouldImplicitlyCastToHandle()
    {
        //Arrange
        const int value = 69;
        Handle handle;

        //Act
        handle = value;

        //Assert
        handle.Value.Should().Be(value);
    }

    [Fact]
    public void Equal_ShouldReturnFalse_WhenHandleIsDifferent()
    {
        //Arrange
        Handle h1 = 0;
        Handle h2 = 14;
        
        //Act
        bool isEqual = h1.Equals(h2);

        //Assert
        isEqual.Should().Be(false);
    }

    [Fact]
    public void Equal_ShouldReturnFalse_WhenIntIsDifferent()
    {
        //Arrange
        Handle handle = 123;
        const int integer = 444;
        
        //Act
        bool isEqual = handle.Equals(integer);

        //Assert
        isEqual.Should().Be(false);
    }

    [Fact]
    public void Equal_ShouldReturnTrue_WhenHandleIsEqual()
    {
        //Arrange
        Handle h1 = 808;
        Handle h2 = 808;

        //Act
        bool isEqual = h1.Equals(h2);

        //Assert
        isEqual.Should().Be(true);
    }

    [Fact]
    public void Equal_ShouldReturnTrue_WhenIntIsEqual()
    {
        //Arrange
        Handle handle = 8008;
        const int integer = 8008;
        
        //Act
        bool isEqual = handle.Equals(integer);
        
        //Assert
        isEqual.Should().Be(true);
    }
    
    [Fact]
    public void EqualOperator_ShouldReturnFalse_WhenHandleIsDifferent()
    {
        //Arrange
        Handle h1 = 0;
        Handle h2 = 14;
        
        //Act
        bool isEqual = h1 == h2;

        //Assert
        isEqual.Should().Be(false);
    }

    [Fact]
    public void EqualOperator_ShouldReturnFalse_WhenIntIsDifferent()
    {
        //Arrange
        Handle handle = 123;
        const int integer = 444;
        
        //Act
        bool isEqual = handle == integer;

        //Assert
        isEqual.Should().Be(false);
    }

    [Fact]
    public void EqualOperator_ShouldReturnTrue_WhenHandleIsEqual()
    {
        //Arrange
        Handle h1 = 808;
        Handle h2 = 808;

        //Act
        bool isEqual = h1 == h2;

        //Assert
        isEqual.Should().Be(true);
    }

    [Fact]
    public void EqualOperator_ShouldReturnTrue_WhenIntIsEqual()
    {
        //Arrange
        Handle handle = 8008;
        const int integer = 8008;
        
        //Act
        bool isEqual = handle == integer;
        
        //Assert
        isEqual.Should().Be(true);
    }

    [Fact]
    public void UnequalOperator_ShouldReturnTrue_WhenOtherHandleIsDifferent()
    {
        //Arrange
        Handle h1 = 123;
        Handle h2 = 456;

        //Act
        bool isUnequal = h1 != h2;

        //Assert
        isUnequal.Should().Be(true);
    }

    [Fact]
    public void UnequalOperator_ShouldReturnTrue_WhenOtherIntIsDifferent()
    {
        //Arrange
        Handle handle = 123;
        const int integer = 456;

        //Act
        bool isUnequal = handle != integer;

        //Assert
        isUnequal.Should().Be(true);
    }
    
    [Fact]
    public void UnequalOperator_ShouldReturnFalse_WhenOtherHandleIsEqual()
    {
        //Arrange
        Handle h1 = 123;
        Handle h2 = 123;

        //Act
        bool isUnequal = h1 != h2;

        //Assert
        isUnequal.Should().Be(false);
    }

    [Fact]
    public void UnequalOperator_ShouldReturnFalse_WhenOtherIntIsEqual()
    {
        //Arrange
        Handle handle = 123;
        const int integer = 123;

        //Act
        bool isUnequal = handle != integer;

        //Assert
        isUnequal.Should().Be(false);
    }

    [Fact]
    public void Equal_ShouldReturnFalse_WhenOtherIsObject()
    {
        //Arrange
        Handle handle = 8008;
        var obj = new object();
        
        //Act
        bool isEqual = handle.Equals(obj);
        
        //Assert
        isEqual.Should().Be(false);
    }

    [Fact]
    public void GetHashCode_ShouldReturnValue()
    {
        //Arrange
        const int value = 8008;
        Handle handle = value;
        
        //Act
        int hashCode = handle.GetHashCode();

        //Assert
        hashCode.Should().Be(value);
    }
}