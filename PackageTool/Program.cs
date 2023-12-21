using System;
using System.Windows.Forms;

namespace PackageTool
{
    internal static class Program
    {
        private static PackageTool packageTool;

        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            packageTool = new PackageTool();

            Application.Run(packageTool);
        }
    }
}
