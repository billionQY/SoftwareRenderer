// ZTest.cs
// Created by xiaojl Dec/26/2020
// 深度测试&深度写入

namespace SoftRenderer.Core
{
    public partial class Device
    {
        // 深度测试
        public bool ZTest(Vector3 v)
        {
            int x = (int)v.X;
            int y = (int)v.Y;
            int z = (int)v.Z;
            int index = x + y * Width;
            return zBuffer[index] >= z;
        }

        // 深度写入
        public void ZWrite(Vector3 v)
        {
            int x = (int)v.X;
            int y = (int)v.Y;
            int z = (int)v.Z;
            int index = x + y * Width;
            zBuffer[index] = z;
        }
    }
}
