// Camera.cs
// Created by xiaojl Dec/27/2020
// 摄像机

using System;

namespace SoftRenderer.Core
{
    public class Camera
    {
        public Vector3 Position { get; set; }
        public readonly Vector3 Forward;
        public readonly Vector3 Up;
        public readonly Vector3 Right;
        public readonly float Fov;
        public readonly float ZNear;
        public readonly float ZFar;
        private float fovScale;

        public Camera(Vector3 position, Vector3 forward, Vector3 up, float fov, float zNear, float zFar)
        {
            // 左手坐标系
            Position = position;
            Forward = forward.Normalize();
            Right = up.Cross(Forward).Normalize();
            Up = Forward.Cross(Right).Normalize();

            Fov = fov;
            fovScale = (float)Math.Tan(Fov * 0.5 * Math.PI / 180) * 2;

            ZNear = zNear;
            ZFar = zFar;
        }
    }
}
