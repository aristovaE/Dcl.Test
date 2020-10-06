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
            //"ВЭД-Декларант (расширенная версия) 9.97 от 01.10.2020 (10000000/220719/0000005) - ТОЛЬКО ЧТЕНИЕ - [ДТ (основной лист)]"
            
            if (IsIconic(hwnd))
            {
                ShowWindow(hwnd, 9); //9 - restore
            }
            else
            {
                SetForegroundWindow(hwnd);
            }

            //var process = Process.GetProcessesByName("DCL").FirstOrDefault();
            Thread.Sleep(1000);
            // Получаем hwnd окна
            IntPtr hWnd = WindowFromPoint(System.Windows.Forms.Cursor.Position);// окно рабочей области БЕЗ меню

            //симуляция передвижения мыши 

            //MoveMouse(hWnd, SystemInformation.VirtualScreen.Width, SystemInformation.VirtualScreen.Height); //не работает - нет меню в области
            
            //Нажатие кнопок меню через сочетания клавиш
            SendKeys.SendWait("%д");
            Thread.Sleep(1000);
            SendKeys.SendWait("в");
            Thread.Sleep(1000);
            SendKeys.SendWait("~");
        }

        private static void MoveMouse(IntPtr hWnd,int screenWidth, int screenHeight)
        {
            Point p = new Point();
            
                p.X = Convert.ToInt16(17);
                p.Y = Convert.ToInt16(23); //координаты из inspect exe
                ClientToScreen(hWnd, ref p);
                SetCursorPos(p.X, p.Y);
                Thread.Sleep(1000);
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
        public static extern IntPtr WindowFromPoint(Point pt);

        [DllImport("user32.dll")]
        public static extern long SetCursorPos(int x, int y);

        [DllImport("user32.dll")]
        public static extern bool ClientToScreen(IntPtr hWnd, ref Point point);

       
        // [DllImport("user32.dll")]
        // public static extern IntPtr PostMessage(IntPtr hWnd, System.Messaging.Message msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        static extern IntPtr GetMenu(IntPtr hWnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool ShowWindow(IntPtr hWnd, int showWindowCommand);

        //[DllImport("user32", SetLastError = true, CharSet = CharSet.Auto)]
        //public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        //[DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
        //public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        #endregion

    }

}
