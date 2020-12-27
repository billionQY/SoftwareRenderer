using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftRenderer.Core
{
    public class Canvas
    {
        public const int Width = 512;
        public const int Height = 512;

        private Form form;
        private GBuffer gBuffer;
        Mesh[] meshes = Util.BuildMeshes();

        public Canvas()
        {
            form = new Form
            {
                Size = new Size(Width, Height),
                StartPosition = FormStartPosition.CenterScreen,
                Text = "SoftRenderer"
            };

            gBuffer = new GBuffer(Width, Height);
        }

        public void Run()
        {
            form.Show();
            while (! form.IsDisposed)
            {
                Render();
                gBuffer.SwapBuffers();
                Present();
                Application.DoEvents();
            }
        }

        private void Render()
        {
            Device g = gBuffer.BackgroundGraphicDevice;
            g.Camera = new Camera(new Vector3(0, 0, 10), new Vector3(0, 0, -10), Vector3.UnitY, (float)Math.PI / 4, 0.1f, 1f); ;
            meshes[0].Rotation += new Vector3(0.01f, 0.01f, 0);

            g.Clear(Color.Black);
            g.Rasterize(meshes);
        }

        private void Present()
        {
            using (var g = form.CreateGraphics())
            {
                g.DrawImage(gBuffer.Current, Point.Empty);
            }
        }
    }
}
