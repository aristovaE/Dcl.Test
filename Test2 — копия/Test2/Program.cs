#define WM_COMMAND                      0x0111;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Messaging;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Automation;
using System.Windows.Forms;
using static System.Windows.Forms.Control;

namespace Test2
{
    class Program
    {
        static void Main(string[] args)
        {
            IntPtr hwnd = FindWindow(null, "ВЭД-Декларант");
            //"ВЭД-Декларант (незарегистрированная версия) 9.97 от 01.10.2020 (10000000/220719/0000005) - ТОЛЬКО ЧТЕНИЕ - [ДТ (основной лист)]"
            
            if (IsIconic(hwnd))
            {
                ShowWindow(hwnd, 9); //9 - restore
            }
            else
            {
                SetForegroundWindow(hwnd);
            }

            //var process = Process.GetProcessesByName("DCL").FirstOrDefault();
            Thread.Sleep(5000);
            // Получаем hwnd окна
            IntPtr hWnd = WindowFromPoint(System.Windows.Forms.Cursor.Position);

            //Определяем текст
            StringBuilder builder = new StringBuilder(100);
            GetWindowText(hWnd, builder, builder.Capacity);
            string text = builder.ToString();

            //Определяем класс
            StringBuilder buffer = new StringBuilder(256);
            GetClassName(hWnd, buffer, buffer.Capacity);
            string className = buffer.ToString();
            //  PostMessage(hwnd, WM_COMMAND, 2, 0); // WM_COMMAND??? https://stackoverflow.com/questions/9397700/c-sharp-winapi-clicking-on-menu-items

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

        [DllImport("user32.dll")] public static extern IntPtr WindowFromPoint(Point pt);

        [DllImport("user32.dll")]
        public static extern IntPtr PostMessage(IntPtr hWnd, System.Messaging.Message msg, int wParam, int lParam);
       
        [DllImport("user32.dll")]
        static extern IntPtr GetMenu(IntPtr hWnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool ShowWindow(IntPtr hWnd, int showWindowCommand);

        [DllImport("user32", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        [DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        #endregion

    }

}
