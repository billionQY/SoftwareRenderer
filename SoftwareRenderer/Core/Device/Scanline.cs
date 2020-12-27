// Scanline.cs
// Created by xiaojl Dec/27/2020
// 扫描线

using System.Collections.Generic;

namespace SoftRenderer.Core
{
    public partial class Device
    {
        //    v3
        //    |\
        //  vt|_\v2
        //    | /
        //    |/
        //    v1
        private List<Vector3> Triangle(Vector3 v1, Vector3 v2, Vector3 v3)
        {
            List<Vector3> lst = new List<Vector3>();

            // sort y1 <= y2 <= y3
            if (v1.Y > v2.Y) Util.Swap(ref v1, ref v2);
            if (v1.Y > v3.Y) Util.Swap(ref v1, ref v3);
            if (v2.Y > v3.Y) Util.Swap(ref v2, ref v3);

            int x1 = (int)v1.X, y1 = (int)v1.Y, z1 = (int)v1.Z;
            int x2 = (int)v2.X, y2 = (int)v2.Y, z2 = (int)v2.Z;
            int x3 = (int)v3.X, y3 = (int)v3.Y, z3 = (int)v3.Z;

            // total height
            int H = y3 - y1;

            // scan line from v1 to (vt, v2)
            for (int y = y1; y <= y2; y++)
            {
                int h = y2 - y1 + 1; // +1 avoid div by zero
                float a = (float)(y - y1) / H;
                float b = (float)(y - y1) / h;
                float sz = z1 + (z3 - z1) * a;
                float ez = z1 + (z2 - z1) * b;
                int sx = (int)(x1 + (x3 - x1) * a);
                int ex = (int)(x1 + (x2 - x1) * b);
                if (sx > ex) Util.Swap(ref sx, ref ex);
                for (int x = sx; x <= ex; x++)
                {
                    float z = sz + (ez - sz) * ((float)(x - sx) / (ex - sx));
                    lst.Add(new Vector3(x, y, z));
                }
            }

            // scan line from (vt, v2) to v3
            for (int y = y2; y <= y3; y++)
            {
                int h = y3 - y2 + 1; // +1 avoid div by zero
                float a = (float)(y - y1) / H;
                float b = (float)(y - y2) / h;
                float sz = z1 + (z3 - z1) * a;
                float ez = z1 + (z2 - z1) * b;
                int sx = (int)(x1 + (x3 - x1) * a);
                int ex = (int)(x2 + (x3 - x2) * b);
                if (sx > ex) Util.Swap(ref sx, ref ex);
                for (int x = sx; x <= ex; x++)
                {
                    float z = sz + (ez - sz) * ((float)(x - sx) / (ex - sx));
                    lst.Add(new Vector3(x, y, z));
                }
            }

            return lst;
        }
    }
}
