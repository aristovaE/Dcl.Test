using System;
using System.Activities;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace DclTestForm
{
    public partial class DclTestForm : Form
    {
        public DclTestForm()
        {
            InitializeComponent();
        }

        private void openDT_btn_Click(object sender, EventArgs e)
        {
            if (howToOpenDT_cmb.SelectedIndex == 0)
            {
                OpenDCL();
                EnterShortcuts();             //ввод комбинаций клавиш для открытия меню
            }

            else if (howToOpenDT_cmb.SelectedIndex == 1)
            {
                OpenDCL();
                //SendMessageAndClick(47, 30);    //наведение мыши через SendMessage
                //SendMessageAndClick(96, 76);
                //SendMessageAndClick(1700, 880); //"Отмена"
              //  CheckIsIt(47, 30);
                MoveMouseAndClick(47, 30);    //наведение мыши через mouse_event
               // CheckIsIt(96, 76);
                MoveMouseAndClick(96, 76);
                //CheckIsIt(1700, 880);
                MoveMouseAndClick(1700, 880);
            }
        }
        private void enterKey_btn_Click(object sender, EventArgs e)
        {
            OpenDCL();
            byte[] byteToString = System.Text.Encoding.UTF8.GetBytes(enterKey_tb.Text);
            foreach(byte key in byteToString)
                EnterKey(key);
        }

        private void doAll_btn_Click(object sender, EventArgs e)
        {
            enterKey_btn_Click(sender, e);
            openDT_btn_Click(sender, e);
        }

        /// <summary>
        /// Открытие меню - Документ (sendMessage)
        /// </summary>
        private static void OpenDCL()
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
            var DCLHandles = GetAllWindows(hwnd); // все окна?
            List<IntPtr> listcw = new List<IntPtr>(GetChildWindows(hwnd)); //выдает только одно окно
            GetTreeViewOfChild(hwnd);
        }
        private static ArrayList GetAllWindows(IntPtr hwnd)
        {
            var windowHandles = new ArrayList();
            EnumedWindow callBackPtr = GetWindowHandle;
            EnumWindows(callBackPtr, windowHandles);
            EnumChildWindows(hwnd, callBackPtr, windowHandles);
            return windowHandles;
        }

        private delegate bool EnumedWindow(IntPtr handleWindow, ArrayList handles);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool EnumWindows(EnumedWindow lpEnumFunc, ArrayList lParam);

        [DllImport("user32")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool EnumChildWindows(IntPtr window, EnumedWindow callback, ArrayList lParam);

        private static bool GetWindowHandle(IntPtr windowHandle, ArrayList windowHandles)
        {
            windowHandles.Add(windowHandle);
            return true;
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////
        [DllImport("user32")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumChildWindows(IntPtr window, EnumWindowProc callback, IntPtr i);

        /// <summary>
        /// Returns a list of child windows
        /// </summary>
        /// <param name="parent">Parent of the windows to return</param>
        /// <returns>List of child windows</returns>
        public static List<IntPtr> GetChildWindows(IntPtr parent)
        {
            List<IntPtr> result = new List<IntPtr>();
            GCHandle listHandle = GCHandle.Alloc(result);
            try
            {
                EnumWindowProc childProc = new EnumWindowProc(EnumWindow);
                EnumChildWindows(parent, childProc, GCHandle.ToIntPtr(listHandle));
            }
            finally
            {
                if (listHandle.IsAllocated)
                    listHandle.Free();
            }
            return result;
        }

        /// <summary>
        /// Callback method to be used when enumerating windows.
        /// </summary>
        /// <param name="handle">Handle of the next window</param>
        /// <param name="pointer">Pointer to a GCHandle that holds a reference to the list to fill</param>
        /// <returns>True to continue the enumeration, false to bail</returns>
        private static bool EnumWindow(IntPtr handle, IntPtr pointer)
        {
            GCHandle gch = GCHandle.FromIntPtr(pointer);
            List<IntPtr> list = gch.Target as List<IntPtr>;
            if (list == null)
            {
                throw new InvalidCastException("GCHandle Target could not be cast as List<IntPtr>");
            }
            list.Add(handle);
            //  You can modify this to check to see if you want to cancel the operation, then return a null here
            return true;
        }

        /// <summary>
        /// Delegate for the EnumChildWindows method
        /// </summary>
        /// <param name="hWnd">Window handle</param>
        /// <param name="parameter">Caller-defined variable; we use it for a pointer to our list</param>
        /// <returns>True to continue enumerating, false to bail.</returns>
        public delegate bool EnumWindowProc(IntPtr hWnd, IntPtr parameter);


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
        private static void EnterKey(byte key)
        {
            //ввод в поле, где находится фокус с открытой ДТ (ИНН)
            keybd_event(key, 0, 0, 0); //цифра 3
            keybd_event(key, 0, KEYEVENTF_KEYUP, 0);
            Thread.Sleep(500);
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
            Thread.Sleep(2000);
            keybd_event(VK_ESCAPE, 0, 0, 0); // Escape
            keybd_event(VK_ESCAPE, 0, KEYEVENTF_KEYUP, 0);
            
        }

        /// <summary>
        /// симуляция передвижения мыши
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="screenWidth"></param>
        /// <param name="screenHeight"></param>
        private static void MoveMouseAndClick(int pX, int pY)
        {
            IntPtr windowDCLMenu = WindowFromPoint(System.Windows.Forms.Cursor.Position = new Point(pX, pY));//Меню - Документ
            IntPtr windowDCLChild = ChildWindowFromPoint(windowDCLMenu,System.Windows.Forms.Cursor.Position = new Point(pX, pY),0);  //child??
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

        private static void GetTreeViewOfChild(IntPtr hwnd) //попробовать сделать тривью процессов которые относятся к декларанту
        {
            var listcw = new List<IntPtr>();
           //while(GetWindow(hwnd, 5)!=null)
           // {
           //     listcw.Add(GetWindow(hwnd, 5));
           //     hwnd = GetWindow(hwnd, 5);
           // }

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
        
       

        [DllImport("user32.dll")]
        static extern IntPtr ChildWindowFromPoint(IntPtr hWndParent, Point pt, uint uFlags);

        public delegate bool EnumWindowsProc(IntPtr hwnd, IntPtr lParam);

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

        [DllImport("user32.dll")]
        public static extern IntPtr WindowFromPoint(Point pt);

        [DllImport("user32.dll")]
        public static extern long SetCursorPos(int x, int y);

        [DllImport("user32.dll")]
        public static extern void mouse_event(int dsFlags, int dx, int dy, int cButtins, int dsExtraInfo);

        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, UInt32 dwFlags, int dwExtraInfo);


        [DllImport("User32.dll")]
        public static extern Int32 SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("User32.dll")]
        public static extern IntPtr GetWindow(IntPtr hwnd, uint uCmd);

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
        const byte VK_ESCAPE = 0x1B;
        const byte VK_LEFT = 0x25;
        const byte VK_UP = 0x26;
        const byte VK_RIGHT = 0x27;
        const byte VK_DOWN = 0x28;
        const byte VK_TAB = 0x9;
        public const UInt32 KEYEVENTF_EXTENDEDKEY = 1;
        public const UInt32 KEYEVENTF_KEYUP = 2;
        public const UInt32 MF_BYPOSITION = 0x00000400;
        #endregion

        private void nextControl_btn_Click(object sender, EventArgs e)
        {
            OpenDCL();
            keybd_event(VK_TAB, 0, 0, 0); //клавиша Tab
        }
    }
}
