using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftRenderer.Core
{
    public class Mesh
    {
        public string Name        { get; set; }
        public Vector3[] Vertices { get; set; }
        public Surface[] Surfaces { get; set; }
        public Vector3 Rotation   { get; set; }
        public Vector3 Position   { get; set; }
        public Texture Texture    { get; set; }

        public Mesh(string name, int vertCnt, int faceCnt)
        {
            Name = name;
            Vertices = new Vector3[vertCnt];
            Surfaces = new Surface[faceCnt];
        }
    }

    public class Vertex
    {
        public Vector3 Pos;
    }

    public struct Surface
    {
        public int A;
        public int B;
        public int C;

        public Surface(int a, int b, int c)
        {
            A = a;
            B = b;
            C = c;
        }
    }

    public class Texture
    {
        private Bitmap texture;

        public int Width => texture.Width;
        public int Height => texture.Height;

        public Texture(Bitmap texture)
        {
            this.texture = texture;
        }

        public Color Map(int u, int v)
        {
            if (texture == null) return Color.White;
            return texture.GetPixel(u, v);
        }
    }

    public struct Material
    {
        public string Name;

        public string ID;

        public string DiffuseTextureName;
    }
}
