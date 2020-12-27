// Bresenham.cs
// Created by xiaojl Dec/26/2020
// 直线光栅化

using System;
using System.Drawing;

namespace SoftRenderer.Core
{
    public partial class Device
    {
        public void DrawLine(Vector3 v1, Vector3 v2, Color c)
        {
            int x1 = (int)v1.X, y1 = (int)v1.Y;
            int x2 = (int)v2.X, y2 = (int)v2.Y;

            int dx = x2 - x1, dy = y2 - y1;
            int ux = dx > 0 ? 1 : -1;
            int uy = dy > 0 ? 1 : -1;

            int x = x1, y = y1, eps = 0;
            dx = Math.Abs(dx); dy = Math.Abs(dy);
            if (dx > dy)
            {
                for (; x != x2 + ux; x += ux)
                {
                    //DrawPoint(new Point(x, y), c);
                    eps += dy;
                    if ((eps << 1) >= dx)
                    {
                        y += uy; eps -= dx;
                    }
                }
            }
            else
            {
                for (; y != y2 + uy; y += uy)
                {
                    //DrawPoint(new Point(x, y), c);
                    eps += dx;
                    if ((eps << 1) >= dy)
                    {
                        x += ux; eps -= dy;
                    }
                }
            }
        }
    }
}
