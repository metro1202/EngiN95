using EngiN95.Core;
using EngiN95.Core.Rendering;
using FluentAssertions;
using FluentAssertions.Primitives;
using OpenTK.Mathematics;

namespace EngineTests.Rendering;

public class TransformTests
{
    [Fact]
    public void DefaultConstructor_ShouldInitializeToIdentity()
    {
        // Arrange
        var transform = new Transform();

        // Act & Assert
        transform.Position.Should().Be(Vector3.Zero);
        transform.Rotation.Should().Be(Quaternion.Identity);
        transform.Scale.Should().Be(Vector3.One);
    }

    [Fact]
    public void ParameterizedConstructor_ShouldInitializeWithGivenValues()
    {
        // Arrange
        var position = new Vector3(1, 2, 3);
        var rotation = Quaternion.FromEulerAngles(0.5f, 0.5f, 0.5f);
        var scale = new Vector3(2, 2, 2);
        var transform = new Transform(position, rotation, scale);

        // Act & Assert
        transform.Position.Should().Be(position);
        transform.Rotation.Should().Be(rotation);
        transform.Scale.Should().Be(scale);
    }

    [Fact]
    public void Translate_ShouldAdjustPosition()
    {
        // Arrange
        var transform = new Transform();
        var translation = new Vector3(1, 1, 1);

        // Act
        transform.Translate(translation);

        // Assert
        transform.Position.Should().Be(translation);
    }

    [Fact]
    public void Rotate_ShouldAdjustRotation()
    {
        // Arrange
        var transform = new Transform();
        var rotation = Quaternion.FromEulerAngles(0.5f, 0, 0);

        // Act
        transform.Rotate(rotation);

        // Assert
        transform.Rotation.Should().Be(rotation);
    }

    [Fact]
    public void ScaleBy_ShouldAdjustScale()
    {
        // Arrange
        var transform = new Transform();
        var scaling = new Vector3(2, 2, 2);

        // Act
        transform.ScaleBy(scaling);

        // Assert
        transform.Scale.Should().Be(new Vector3(2, 2, 2));
    }

    [Fact]
    public void GetTransformationMatrix_ShouldReturnCorrectMatrix()
    {
        // Arrange
        var position = new Vector3(1, 2, 3);
        var rotation = Quaternion.FromEulerAngles(0.5f, 0.5f, 0.5f);
        var scale = new Vector3(2, 2, 2);
        var transform = new Transform(position, rotation, scale);

        // Act
        var matrix = transform.GetTransformationMatrix();

        // Assert
        var expectedMatrix = Matrix4.CreateScale(scale) *
                             Matrix4.CreateFromQuaternion(rotation) *
                             Matrix4.CreateTranslation(position);

        matrix.Should().Be(expectedMatrix);
    }

    [Fact]
    public void LookAt_ShouldAdjustRotation()
    {
        // Arrange
        var transform = new Transform();
        var target = new Vector3(0, 0, -1);
        var up = Vector3.UnitY;

        // Act
        transform.LookAt(target, up);

        // Assert
        var expectedForward = (target - transform.Position).Normalized();
        transform.Forward.Should().BeApproximately(expectedForward, 0.0001f);
    }

    [Fact]
    public void Forward_ShouldReturnCorrectForwardVector()
    {
        // Arrange
        var transform = new Transform();
        var rotation = Quaternion.FromEulerAngles(0, MathHelper.PiOver2, 0);
        transform.Rotate(rotation);

        // Act
        var forward = transform.Forward;

        // Assert
        forward.Should().BeApproximately(Vector3.UnitX, 0.0001f);
    }

    [Fact]
    public void Right_ShouldReturnCorrectRightVector()
    {
        // Arrange
        var transform = new Transform();
        var rotation = Quaternion.FromEulerAngles(0, MathHelper.PiOver2, 0);
        transform.Rotate(rotation);

        // Act
        var right = transform.Right;

        // Assert
        right.Should().BeApproximately(-Vector3.UnitZ, 0.0001f);
    }

    [Fact]
    public void Up_ShouldReturnCorrectUpVector()
    {
        // Arrange
        var transform = new Transform();
        var rotation = Quaternion.FromEulerAngles(MathHelper.PiOver2, 0, 0);
        transform.Rotate(rotation);

        // Act
        var up = transform.Up;

        // Assert
        up.Should().BeApproximately(Vector3.UnitZ, 0.0001f);
    }
}

public static class VectorExtensions
{
    public static AndConstraint<ObjectAssertions> BeApproximately(this ObjectAssertions assertions, Vector3 expected, float precision)
    {
        if (assertions.Subject is not Vector3 actual)
        {
            throw new InvalidOperationException("This Assertion is only valid for Vector3 objects");
        }
        
        actual.X.Should().BeApproximately(expected.X, precision);
        actual.Y.Should().BeApproximately(expected.Y, precision);
        actual.Z.Should().BeApproximately(expected.Z, precision);

        return new AndConstraint<ObjectAssertions>(assertions);
    }
}