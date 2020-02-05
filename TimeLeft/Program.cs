using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TimeLeft
{
    class Program
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetWindowSize(20, 1);
            DateTime myTime = DateTime.Now.AddHours(8);
            IntPtr ptr = GetConsoleWindow();
            
            MoveWindow(ptr, 0, 0, 190, 60, true);

            for (int i = 0; i < 28800; i++)
            {
                TimeSpan timeLeft = DateTime.Now.Subtract(myTime);
                Console.Write("TIME LEFT - " + "{0:hh\\:mm\\:s}", timeLeft);
                Thread.Sleep(1000);
                Console.Clear();
            }
        }
    }
}
