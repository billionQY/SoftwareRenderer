using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftRenderer.Core
{
    public class Util
    {
        public static void Swap<T>(ref T a, ref T b)
        {
            T t = a;
            a = b;
            b = t;
        }

        public static float Clamp(float value, float min = 0, float max = 1)
        {
            return Math.Max(min, Math.Min(value, max));
        }

        public static float Interpolate(float min, float max, float gradient)
        {
            return min + (max - min) * Clamp(gradient);
        }

        public static Mesh[] BuildMeshes()
        {
            var mesh = new Mesh("Cube", 8, 1);
            mesh.Vertices[0] = new Vector3(-1, 1, 1);
            mesh.Vertices[1] = new Vector3(1, 1, 1);
            mesh.Vertices[2] = new Vector3(-1, -1, 1);
            mesh.Vertices[3] = new Vector3(1, -1, 1);
            mesh.Vertices[4] = new Vector3(-1, 1, -1);
            mesh.Vertices[5] = new Vector3(1, 1, -1);
            mesh.Vertices[6] = new Vector3(1, -1, -1);
            mesh.Vertices[7] = new Vector3(-1, -1, -1);

            mesh.Surfaces[0] = new Surface{ A = 0, B = 1, C = 2 };
            //mesh.Surfaces[1] = new Surface{ A = 1, B = 2, C = 3 };
            //mesh.Surfaces[2] = new Surface{ A = 1, B = 3, C = 6 };
            //mesh.Surfaces[3] = new Surface{ A = 1, B = 5, C = 6 };
            //mesh.Surfaces[4] = new Surface{ A = 0, B = 1, C = 4 };
            //mesh.Surfaces[5] = new Surface{ A = 1, B = 4, C = 5 };

            //mesh.Surfaces[6] = new Surface{ A = 2, B = 3, C = 7 };
            //mesh.Surfaces[7] = new Surface{ A = 3, B = 6, C = 7 };
            //mesh.Surfaces[8] = new Surface{ A = 0, B = 2, C = 7 };
            //mesh.Surfaces[9] = new Surface{ A = 0, B = 4, C = 7 };
            //mesh.Surfaces[10] = new Surface { A = 4, B = 5, C = 6 };
            //mesh.Surfaces[11] = new Surface { A = 4, B = 6, C = 7 };

            mesh.Position = new Vector3(0, 0, -10);
            mesh.Rotation = new Vector3(0, 0, 0);

            return new Mesh[1] { mesh };
        }
    }
}
