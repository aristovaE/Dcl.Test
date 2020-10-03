using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
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
            Console.WriteLine("вааау а ты и правда садистка");
            
            // находим бегущий notepad
            var notepadProcess = Process.GetProcessesByName("DCL").FirstOrDefault();
           
            var window = AutomationElement.FromHandle(notepadProcess.MainWindowHandle);

            //var transformPattern = (TransformPattern)window.GetCurrentPattern(TransformPattern.Pattern);
            //transformPattern.Resize(300, 300);
            //// сохраним изменённый файл под новым именем
            //// вызовем File -> Save as... (на русскоязычной системе понадобятся другие строки!)
            
 

            //Определяем текст
            StringBuilder builder = new StringBuilder(100);
            GetWindowText(hwnd, builder, builder.Capacity);
            string text = builder.ToString();

            //Определяем класс
            StringBuilder buffer = new StringBuilder(256);
            GetClassName(hwnd, buffer, buffer.Capacity);
            string className = buffer.ToString();

            var menuBar = window.FirstChildByType(ControlType.MenuBar);
            var fileMenu = menuBar.FirstDescendantByTypeAndName(ControlType.MenuItem, "File");
            // раскрыли меню File:
            fileMenu.GetPattern<ExpandCollapsePattern>().Expand();
            Thread.Sleep(100);

            //// нашли пункт Save As
            //var saveAsMenu = fileMenu.FirstDescendantByTypeAndName(ControlType.MenuItem, "Открыть ДТ");
            //// и выполнили его
            //saveAsMenu.GetPattern<InvokePattern>().Invoke();
            //Thread.Sleep(100);
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

    }
}
