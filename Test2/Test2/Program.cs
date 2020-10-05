using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Test2
{
    class Program
    {
        static void Main(string[] args)
        {
           
            IntPtr hwnd = FindWindow(null, "ВЭД-Декларант");
            //"ВЭД-Декларант (расширенная версия) 9.97 от 01.10.2020 (10000000/220719/0000005) - ТОЛЬКО ЧТЕНИЕ - [ДТ (основной лист)]"
         
            if (IsIconic(hwnd))
            {
                ShowWindow(hwnd, 9); //9 - restore
            }
            else
            {
                SetForegroundWindow(hwnd);

            }
            Console.ReadKey();

        }

        #region native FindWindow, IsIconic, SetForegroundWindow, ShowWindow
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(String lpClassName, String windowName);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool IsIconic(IntPtr hWnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool ShowWindow(IntPtr hWnd, int showWindowCommand);
        #endregion

    }
}
