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

namespace Test2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Process.Start();
            IntPtr hwnd = FindWindow(null, "ВЭД-Декларант");
            //"ВЭД-Декларант (незарегистрированная версия) 9.97 от 01.10.2020 (10000000/220719/0000005) - ТОЛЬКО ЧТЕНИЕ - [ДТ (основной лист)]"
            //Console.WriteLine("hwnd: " + hwnd);
            if (IsIconic(hwnd))
            {
                ShowWindow(hwnd, 9); //9 - restore
            }
            else
            {
                SetForegroundWindow(hwnd);

            }
            Thread.Sleep(1000);
           

            var process = Process.GetProcessesByName("DCL").FirstOrDefault();
           // IntPtr handle = process.MainWindowHandle;
            IntPtr HMENU = GetMenu(process.MainWindowHandle); //не работает
            //PostMessage(handle, WM_COMMAND, 2, 0); // File->New subtitle
            var window = AutomationElement.FromHandle(process.MainWindowHandle);

            //Thread.Sleep(5000);
            var menuBar = window.FirstChildByType(ControlType.MenuBar);
            var fileMenu = menuBar.FirstDescendantByTypeAndName(ControlType.MenuItem, "Документ");
            // раскрыли меню 
            fileMenu.GetPattern<ExpandCollapsePattern>().Expand();
            Thread.Sleep(100);

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

        [DllImport("user32", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        [DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll")]
        public static extern IntPtr PostMessage(IntPtr hWnd, Message msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        static extern IntPtr GetMenu(IntPtr hWnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]


        static extern bool ShowWindow(IntPtr hWnd, int showWindowCommand);
        #endregion

    }
    static class AutomationHelpers
    {
        static public T GetPattern<T>(this AutomationElement element)
            where T : BasePattern
        {
            var pattern = (AutomationPattern)typeof(T).GetField("Pattern").GetValue(null);
            return (T)element.GetCurrentPattern(pattern);
        }

        static public AutomationElement FirstChildByType(
            this AutomationElement element, ControlType ct)
        {
            return element.FindFirst(
                TreeScope.Children,
                new PropertyCondition(AutomationElement.ControlTypeProperty, ct));
        }

        static public AutomationElement FirstDescendantByTypeAndName(
            this AutomationElement element, ControlType ct, string name)
        {
            return element.FindFirst(
                TreeScope.Descendants,
                new AndCondition(
                    new PropertyCondition(AutomationElement.ControlTypeProperty, ct),
                    new PropertyCondition(AutomationElement.NameProperty, name)));
           
        }

        static public AutomationElement FindWindowFrom(AutomationElement control)
        {
            var walker = TreeWalker.ControlViewWalker;
            while (control.Current.ControlType != ControlType.Window)
                control = walker.GetParent(control);
            return control;
        }
        public static AutomationElement GetWindowByName(string name)
        {
            AutomationElement root = AutomationElement.RootElement;
            foreach (AutomationElement window in root.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Window)))
            {
                if (window.Current.Name.Contains(name) && window.Current.IsKeyboardFocusable)
                {
                    return window;
                }
            }
            return null;
        }
    }
}
