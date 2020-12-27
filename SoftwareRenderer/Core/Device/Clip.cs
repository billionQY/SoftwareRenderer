// Clip.cs
// Created by xiaojl Dec/26/2020
// 裁剪

using System;
namespace SoftRenderer.Core
{
    public partial class Device
    {
        private bool Clip(Vector3 v)
        {
            int x = (int)v.X;
            if (x < 0 || x >= Width) 
                return true;

            int y = (int)v.Y;
            if (y < 0 || y >= Height)
                return true;

            return false;
        }
    }
}
