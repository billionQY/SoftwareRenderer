// Device.cs
// Created by xiaojl Dec/26/2020
// 渲染设备

using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace SoftRenderer.Core
{
    public partial class Device
    {
        public Camera Camera { get; set; }
        public readonly Bitmap canvas;
        private readonly Graphics canvasGraphics;
        private float[] zBuffer;
        private byte[] bg;

        public int Width => canvas.Width;
        public int Height => canvas.Height;

        public Device(Bitmap bitmap)
        {
            canvas = bitmap;
            canvasGraphics = Graphics.FromImage(canvas);
            bg = new byte[canvas.Width * canvas.Height * 4];
            zBuffer = new float[canvas.Width * canvas.Height];
        }

        public void Clear(Color color)
        {
            // Windows is BGRA
            for (int i = 0; i < bg.Length; i += 4)
            {
                bg[i] = color.B;
                bg[i + 1] = color.G;
                bg[i + 2] = color.R;
                bg[i + 3] = color.A;
            }

            var bits = canvas.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.WriteOnly, canvas.PixelFormat);
            Marshal.Copy(bg, 0, bits.Scan0, bg.Length);
            canvas.UnlockBits(bits);

            for (int i = 0; i < zBuffer.Length; i++)
            {
                zBuffer[i] = float.MaxValue;
            }
        }

        // 光栅化
        public void Rasterize(Mesh[] meshes)
        {
            foreach (Mesh mesh in meshes)
            {
                Matrix transform = MVP(mesh);
                foreach (Surface surface in mesh.Surfaces)
                {
                    Vector3 v1 = Project(mesh.Vertices[surface.A], transform);
                    Vector3 v2 = Project(mesh.Vertices[surface.B], transform);
                    Vector3 v3 = Project(mesh.Vertices[surface.C], transform);
                    List<Vector3> pixels = Triangle(v1, v2, v3);
                    foreach (Vector3 pixel in pixels)
                    {
                        if (Clip(pixel))
                            continue;

                        if (!ZTest(pixel))
                            return;
                        
                        ZWrite(pixel);
                        canvas.SetPixel((int)pixel.X, (int)pixel.Y, Color.Cyan);
                    }
                }
            }
        }
    }
}
