using SoftRenderer.Core;
using System;

namespace SoftRenderer
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            new Canvas().Run();
        }
    }
}
