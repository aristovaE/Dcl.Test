using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DclTestConsolePy
{
    class Program
    {
        static void Main(string[] args)
        {
            ScriptEngine engine = Python.CreateEngine();
            //engine.ExecuteFile("D:/VirtualBox VMs/TEMP/python/first.py");
            ScriptScope scope = engine.CreateScope();
            engine.ExecuteFile(@"\\Vboxsvr\temp\python\first.py", scope);
            int first = scope.GetVariable("firstOp");
            int second = scope.GetVariable("secondOp");
            int third = scope.GetVariable("thirdOp");
            Console.WriteLine("hello\nOpen DCL, tab and open menu");
            Console.ReadLine();

            if (first == 1)
            {
                OpenDCL();
                Console.WriteLine("\n DCL opened");
            }
            if (second == 2)
            {
                EnterShortcut(VK_TAB);
            }
            //if (third == 3)
            //{
            //    EnterText(GetForegroundWindow(), str);
            //    Console.WriteLine("\n" + GetForegroundWindow().ToString() + " - " + second + " gf()-" + GetFocus().ToString() + " " + str);
            //}
            if (third == 3)
            {
                EnterShortcuts(VK_ALT, VK_L);
            }
            Console.ReadLine();
        }

        /// Открытие ВД
        /// </summary>
        private static IntPtr OpenDCL()
        {
            IntPtr hwnd = FindWindow(null, "ВЭД-Декларант");
            ////"ВЭД-Декларант (расширенная версия) 9.97 от 01.10.2020 (10000000/220719/0000004) - [ДТ (основной лист)]"
            if (IsIconic(hwnd))
            {
                ShowWindow(hwnd, 9); //9 - restore
            }
            else
            {
                SetForegroundWindow(hwnd);
            }
            return hwnd;
        }
        static void EnterText(IntPtr windowFocus, string strToEnter)
        {
            uint ThreadID1 = GetWindowThreadProcessId(FindWindow(null, "DclTestConsolePy"), out uint id);
            uint ThreadID2 = GetWindowThreadProcessId(windowFocus, out uint idd);
            AttachThreadInput(ThreadID1, ThreadID2, true);
            if (IsIconic(windowFocus))
            {
                ShowWindow(windowFocus, 9); //9 - restore
            }
            else
            {
                SetForegroundWindow(windowFocus);
            }
            SendMessage(GetFocus(), WM_SETTEXT, 0, new StringBuilder(strToEnter));
            AttachThreadInput(ThreadID1, ThreadID2, false);
        }

        /// <summary>
        /// нажатие клавиши (keybd_event)
        /// </summary>
        static void EnterShortcut(byte keyButton)
        {
            //ввод клавиши
            keybd_event(keyButton, 0, 0, 0); 
            keybd_event(keyButton, 0, KEYEVENTF_KEYUP, 0);
            Thread.Sleep(1000);
        }
        /// <summary>
        /// нажатие сочетания клавиш (keybd_event))
        /// </summary>
        private static void EnterShortcuts(byte keyButton1, byte keyButton2)
        {
            //ввод сочетания клавиш
            keybd_event(keyButton1, 0, 0, 0); 
            keybd_event(keyButton2, 0, 0, 0); 
            keybd_event(keyButton1, 0, KEYEVENTF_KEYUP, 0);
            keybd_event(keyButton2, 0, KEYEVENTF_KEYUP, 0);
            Thread.Sleep(1000);
        }

        #region native FindWindow, IsIconic, SetForegroundWindow, ShowWindow, WindowFromPoint, SetCursorPos, mouse_event, keybd_event, SendMessage, all const bytes and ints
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

        [DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        public static extern bool SendMessage(IntPtr hWnd, uint Msg, int wParam, StringBuilder lParam);

        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        [DllImport("user32.dll")]
        static extern IntPtr GetFocus();

        [DllImport("user32.dll")]
        static extern bool AttachThreadInput(uint idAttach, uint idAttachTo, bool fAttach);

        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, UInt32 dwFlags, int dwExtraInfo);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        public const int WM_SETTEXT = 0x000C;
        public const UInt32 KEYEVENTF_KEYUP = 2;

        const byte VK_TAB = 0x9;
        const byte VK_ALT = 0x12;

        const byte VK_L = 0x4C;
        #endregion
    }

}
