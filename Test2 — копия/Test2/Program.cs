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
        internal const UInt32 MF_BYCOMMAND = 0x00000000;
        public const int MOUSEEVENTF_LEFTDOWN = 0x02;
        public const int MOUSEEVENTF_LEFTUP = 0x04;
        public const int WM_MOUSEMOVE = 0x0200;
        public const int WM_LBUTTONDOWN = 0x0201;
        public const int WM_LBUTTONUP = 0x0202;
        const byte VK_3 = 0x33; 
        const byte VK_ALT = 0x12;
        const byte VK_L = 0x4C;
        const byte VK_D = 0x44;
        const byte VK_RETURN = 0x0D;
        public const UInt32 KEYEVENTF_EXTENDEDKEY = 1;
        public const UInt32 KEYEVENTF_KEYUP = 2;
        public const UInt32 MF_BYPOSITION = 0x00000400;

        static void Main(string[] args)
        {
            IntPtr hwnd = FindWindow(null, "ВЭД-Декларант");
            //"ВЭД-Декларант (расширенная версия) 9.97 от 01.10.2020 (10000000/220719/0000004) - [ДТ (основной лист)]"
            
            if (IsIconic(hwnd))
            {
                ShowWindow(hwnd, 9); //9 - restore
            }
            else
            {
                SetForegroundWindow(hwnd);
            }

            //var process = Process.GetProcessesByName("DCL").FirstOrDefault();
            //IntPtr windowDCL = WindowFromPoint(System.Windows.Forms.Cursor.Position);   // окно области где сейчас находится курсор (= new Point(500, 30) - верхнее меню)

            //SendMessageAndClick(47, 30);    //наведение мыши через SendMessage
            //SendMessageAndClick(96, 76);
            //MoveMouseAndClick(47, 30);    //наведение мыши через mouse_event
            //MoveMouseAndClick(96, 76);
            //EnterShortcuts();             //ввод комбинаций клавиш для открытия меню
            EnterKey();                   //ввод значений в активное поле
        }

        /// <summary>
        /// Открытие меню - Документ (sendMessage)
        /// </summary>
        private static void SendMessageAndClick(int pX, int pY)
        {
            IntPtr windowDCLMenu = WindowFromPoint(System.Windows.Forms.Cursor.Position = new Point(pX, pY)); //Меню - Документ
            SendMessage(windowDCLMenu, WM_MOUSEMOVE, (IntPtr)0, MakeParam(pX, pY));
            DoMouseLeftClick(pX, pY);
            Thread.Sleep(1000);
        }

        /// <summary>
        /// Ввод цифр в поля ДТ
        /// </summary>
        private static void EnterKey()
        {
            //ввод в поле, где находится фокус с открытой ДТ (ИНН)
            keybd_event(VK_3, 0, 0, 0); //цифра 3
            keybd_event(VK_3, 0, KEYEVENTF_KEYUP, 0);
            Thread.Sleep(200);
            keybd_event(VK_3, 0, 0, 0); //цифра 3
            keybd_event(VK_3, 0, KEYEVENTF_KEYUP, 0);
            Thread.Sleep(200);
            keybd_event(VK_3, 0, 0, 0); //цифра 3
            keybd_event(VK_3, 0, KEYEVENTF_KEYUP, 0);
        }
        /// <summary>
        /// Открытие меню - Документ (сочетание клавиш (keybd_event))
        /// </summary>
        private static void EnterShortcuts()
        {
            //Ввод комбинации Alt+д для открытия меню - Документ
            keybd_event(VK_ALT, 0, 0, 0); //клавиша Alt
            keybd_event(VK_L, 0, 0, 0); //буква Д
            keybd_event(VK_ALT, 0, KEYEVENTF_KEYUP, 0);
            keybd_event(VK_L, 0, KEYEVENTF_KEYUP, 0);
            Thread.Sleep(1000);
            keybd_event(VK_D, 0, 0, 0); //буква В
            keybd_event(VK_D, 0, KEYEVENTF_KEYUP, 0);
            Thread.Sleep(1000);
            keybd_event(VK_RETURN, 0, 0, 0); // Enter
            keybd_event(VK_RETURN, 0, KEYEVENTF_KEYUP, 0);
        }

        /// <summary>
        /// Нажатие кнопок меню через сочетания клавиш (заранее переключиться на русскую раскладку)
        /// </summary>
        private static void UseShortcuts()
        {
            SendKeys.SendWait("%д"); // Меню - Документ
            Thread.Sleep(1000);
            SendKeys.SendWait("в"); // Открыть ДТ
            Thread.Sleep(1000);
            SendKeys.SendWait("~"); // Enter
            Thread.Sleep(2000);
            SendKeys.SendWait("{ESC}"); //Выход
        }

        /// <summary>
        /// симуляция передвижения мыши
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="screenWidth"></param>
        /// <param name="screenHeight"></param>
        private static void MoveMouseAndClick(int pX, int pY)
        {
            IntPtr windowDCLMenu = WindowFromPoint(System.Windows.Forms.Cursor.Position = new Point(pX, pY));
            Point p = new Point();
            p.X = Convert.ToInt16(pX);  //координаты из inspect exe
            p.Y = Convert.ToInt16(pY);  //поле How found : Mouse Move(47,30) при наведении мышкой на нужное поле
            //ClientToScreen(windowDCLMenu, ref p);
            SetCursorPos(p.X, p.Y);
            Thread.Sleep(1000);
            DoMouseLeftClick(p.X, p.Y);
            Thread.Sleep(1000);
        }
        /// <summary>
        /// Нажатие ЛКМ
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private static void DoMouseLeftClick(int x, int y)
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, x, y, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, x, y, 0, 0);
        }


        /// <summary>
        /// "помещение разных значений в старшие и в младшие биты"
        /// </summary>
        /// <param name="low"></param>
        /// <param name="hight"></param>
        /// <returns></returns>
        public static IntPtr MakeParam(int low, int hight)
        {
            return (IntPtr)((low & 0xFFFF) | (hight << 16));
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

        [DllImport("user32.dll")] 
        public static extern IntPtr WindowFromPoint(Point pt);

        [DllImport("user32.dll")]
        public static extern long SetCursorPos(int x, int y);

        [DllImport("user32.dll")]
        public static extern bool ClientToScreen(IntPtr hWnd, ref Point point);

        [DllImport("user32.dll")]
        public static extern void mouse_event(int dsFlags, int dx, int dy, int cButtins, int dsExtraInfo);

        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, UInt32 dwFlags, int dwExtraInfo);

        // [DllImport("user32.dll")]
        // public static extern IntPtr PostMessage(IntPtr hWnd, System.Messaging.Message msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        static extern IntPtr GetMenu(IntPtr hWnd);

        //[DllImport("user32", SetLastError = true, CharSet = CharSet.Auto)]
        //public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        //[DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
        //public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll")]
        static extern int GetMenuString(IntPtr hMenu, uint uIDItem, [Out] StringBuilder lpString, int nMaxCount, uint uFlag);
        

        [DllImport("user32.dll")]
        static extern int GetMenuItemCount(IntPtr hMenu);
        [DllImport("user32.dll")]
        static extern bool IsMenu(IntPtr hMenu);    
        [DllImport("User32.dll")]
        public static extern Int32 SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        #endregion

    }

}
