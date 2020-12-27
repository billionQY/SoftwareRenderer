using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftRenderer.Core
{
    public class Vector3
    {
        public static readonly Vector3 Zero = new Vector3(0, 0, 0);

        public static readonly Vector3 One = new Vector3(1, 1, 1);

        public static readonly Vector3 UnitX = new Vector3(1, 0, 0);

        public static readonly Vector3 UnitY = new Vector3(0, 1, 0);

        public static readonly Vector3 UnitZ = new Vector3(0, 0, 1);

        public float[] Values { get; }

        public Vector3(float x, float y, float z)
        {
            Values = new float[3];
            Values[0] = x;
            Values[1] = y;
            Values[2] = z;
        }

        public float X
        {
            get => Values[0];
            set => Values[0] = value;
        }

        public float Y
        {
            get => Values[1];
            set => Values[1] = value;
        }

        public float Z
        {
            get => Values[2];
            set => Values[2] = value;
        }

        public float Length => (float)Math.Sqrt(X * X + Y * Y + Z * Z);

        public float SqrLength => X * X + Y * Y + Z * Z;

        public Vector3 Normalize()
        {
            float length = Length;
            return new Vector3(X / length, Y / length, Z / length);
        }

        public static Vector3 operator -(Vector3 a, Vector3 b)
        {
            return new Vector3(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }

        public static Vector3 operator +(Vector3 a, Vector3 b)
        {
            return new Vector3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        public static Vector3 operator /(Vector3 a, float factor)
        {
            return new Vector3(a.X / factor, a.Y / factor, a.Z / factor);
        }

        public static Vector3 operator *(Vector3 a, float factor)
        {
            return new Vector3(a.X * factor, a.Y * factor, a.Z * factor);
        }

        public Vector3 Cross(Vector3 v)
        {
            return new Vector3(Y * v.Z - Z * v.Y, Z * v.X - X * v.Z, X * v.Y - Y * v.X);
        }

        public float Dot(Vector3 v)
        {
            return X * v.X + Y * v.Y + Z * v.Z;
        }

        public Vector3 Modulate(Vector3 v)
        {
            return new Vector3(X * v.X, Y * v.Y, Z * v.Z);
        }

        public override string ToString()
        {
            return "(" + X + ", " + Y + ", " + Z + ")";
        }
    }
}
