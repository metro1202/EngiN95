using OpenTK.Mathematics;

namespace EngiN95.Core;

public class Transform
{
    public Vector3 Position { get; set; }
    public Quaternion Rotation { get; set; }
    public Vector3 Scale { get; set; }

    public Transform()
    {
        Position = Vector3.Zero;
        Rotation = Quaternion.Identity;
        Scale = Vector3.One;
    }

    public Transform(Vector3 position, Quaternion rotation, Vector3 scale)
    {
        Position = position;
        Rotation = rotation;
        Scale = scale;
    }

    public Matrix4 GetTransformationMatrix()
    {
        var translationMatrix = Matrix4.CreateTranslation(Position);
        var rotationMatrix = Matrix4.CreateFromQuaternion(Rotation);
        var scaleMatrix = Matrix4.CreateScale(Scale);

        return scaleMatrix * rotationMatrix * translationMatrix;
    }

    public void Translate(Vector3 translation)
    {
        Position += translation;
    }

    public void Rotate(Quaternion rotation)
    {
        Rotation = Quaternion.Multiply(Rotation, rotation);
    }

    public void ScaleBy(Vector3 scaling)
    {
        Scale *= scaling;
    }

    //TODO keine ahnung ob funktioniert
    public void LookAt(Vector3 target, Vector3 up)
    {
        var forward = (target - Position).Normalized();
        var right = Vector3.Cross(up, forward).Normalized();
        var adjustedUp = Vector3.Cross(forward, right);

        var lookAtMatrix = new Matrix4(
            right.X, right.Y, right.Z, 0,
            adjustedUp.X, adjustedUp.Y, adjustedUp.Z, 0,
            forward.X, forward.Y, forward.Z, 0,
            0, 0, 0, 1);

        var rotationMatrix3 = new Matrix3(
            lookAtMatrix.Row0.Xyz,
            lookAtMatrix.Row1.Xyz,
            lookAtMatrix.Row2.Xyz);

        Rotation = Quaternion.FromMatrix(rotationMatrix3);
    }
    
    public Vector3 Forward => Vector3.Transform(Vector3.UnitZ, Rotation);
    public Vector3 Right => Vector3.Transform(Vector3.UnitX, Rotation);
    public Vector3 Up => Vector3.Transform(Vector3.UnitY, Rotation);

    public override string ToString()
    {
        return $"Position: {Position}, Rotation: {Rotation}, Scale: {Scale}";
    }
}