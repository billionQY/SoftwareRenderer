// MVP.cs
// Created by xiaojl Dec/27/2020
// 矩阵变换

namespace SoftRenderer.Core
{
    public partial class Device
    {
        private Matrix MVP(Mesh mesh)
        {
            Matrix view = Matrix.LookAtLH(Camera.Position, Camera.Forward, Camera.Up);
            Matrix projection = Matrix.PerspectiveFovLH(0.78f, (float)Width / Height, 0.01f, 1.0f);

            Matrix rotation = Matrix.Rotation(mesh.Rotation);
            Matrix translation = Matrix.Translation(mesh.Position);

            Matrix world = rotation * translation;
            Matrix transform = world * view * projection;
            return transform;
        }

        private Vector3 Project(Vector3 coord, Matrix transMat)
        {
            Vector3 pos = transMat.Transform(coord);
            pos.X = pos.X * Width + Width / 2f;
            pos.Y = -pos.Y * Height + Height / 2f;
            return pos;
        }
    }
}
