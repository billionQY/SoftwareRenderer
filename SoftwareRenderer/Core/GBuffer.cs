using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftRenderer.Core
{
    public class GBuffer
    {
        public Bitmap Current { get; private set; }
        public Bitmap Background { get; private set; }
        public Device CurrentGraphicDevice { get; private set; }
        public Device BackgroundGraphicDevice { get; private set; }

        public GBuffer(int width, int height)
        {
            Current = new Bitmap(width, height);
            Background = new Bitmap(width, height);
            CurrentGraphicDevice = new Device(Current);
            BackgroundGraphicDevice = new Device(Background);
        }

        public void SwapBuffers()
        {
            Bitmap t = Current;
            Current = Background;
            Background = t;

            Device g = CurrentGraphicDevice;
            CurrentGraphicDevice = BackgroundGraphicDevice;
            BackgroundGraphicDevice = g;
        }
    }
}
