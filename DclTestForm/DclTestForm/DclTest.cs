using System;
using System.Activities;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
                SendMessageAndClick(47, 30);    //наведение мыши через SendMessage
                SendMessageAndClick(96, 76);
                SendMessageAndClick(1700, 900); //"Отмена"
                // MoveMouseAndClick(47, 30);    //наведение мыши через mouse_event
                // MoveMouseAndClick(96, 76);
                // MoveMouseAndClick(1700, 880);
            }
        }
        private void enterKey_btn_Click(object sender, EventArgs e)
        {
            OpenDCL();
            byte[] byteToString = Encoding.GetEncoding(1251).GetBytes(enterKey_tb.Text);
            
            foreach (byte key in byteToString)
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
            uint ThreadID1 = GetWindowThreadProcessId(GetForegroundWindow(),out uint id );
            //"ВЭД-Декларант (расширенная версия) 9.97 от 01.10.2020 (10000000/220719/0000004) - [ДТ (основной лист)]"
            if (IsIconic(hwnd))
            {
                ShowWindow(hwnd, 9); //9 - restore
            }
            else
            {
                SetForegroundWindow(hwnd);
            }
            uint ThreadID2 = GetWindowThreadProcessId(hwnd, out uint idd);
            AttachThreadInput(ThreadID1, ThreadID2, true);

        }
        private static ArrayList GetAllWindows(IntPtr hwnd)
        {
            var windowHandles = new ArrayList();
            EnumedWindow callBackPtr = GetWindowHandle;
            EnumWindows(callBackPtr, windowHandles);
            EnumChildWindows(hwnd, callBackPtr, windowHandles);
            return windowHandles;
        }
        public delegate bool EnumWindowsProc(IntPtr hwnd, IntPtr lParam);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnumChildWindows(IntPtr hwndParent, EnumWindowsProc lpEnumFunc, IntPtr lParam);
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
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

        [DllImport("user32.dll")]
        static extern IntPtr GetMenu(IntPtr hWnd);
        [DllImport("user32.dll")]
        static extern int GetMenuString(IntPtr hMenu, uint uIDItem, [Out] StringBuilder lpString, int nMaxCount, uint uFlag);
        [DllImport("user32.dll")]
        static extern uint GetMenuItemCount(IntPtr hMenu);
        /// <summary>
        /// Открытие меню - Документ (sendMessage)
        /// </summary>
        private static void SendMessageAndClick(int pX, int pY)
        {
            IntPtr windowDCLMenu = WindowFromPoint(System.Windows.Forms.Cursor.Position = new Point(pX, pY)); //Меню - Документ
            //if (GetControlText(windowDCLMenu) != null)
            //{
            //    IntPtr hMenu = GetMenu(windowDCLMenu);
            //    StringBuilder menuName = new StringBuilder(0x20);
            //    for (uint i = GetMenuItemCount(hMenu) - 1; i >= 0; i--)
            //    {
                   
            //        GetMenuString(hMenu, i, menuName, menuName.Capacity, MF_BYPOSITION);
            //    }
            //}
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
            keybd_event(key, 0, 0, 0); //цифра 
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

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        delegate bool EnumThreadDelegate(IntPtr hWnd, IntPtr lParam);

        [DllImport("user32.dll")]
        static extern bool EnumThreadWindows(int dwThreadId, EnumThreadDelegate lpfn, IntPtr lParam);

       

        private static void GetTreeViewOfChild(IntPtr hwnd) //попробовать сделать тривью процессов которые относятся к декларанту
        {
            
        }

        static string GetClassName(IntPtr hWnd)
        {
            StringBuilder className = new StringBuilder(256);
            int nRet = GetClassName(hWnd, className, className.Capacity);
            return nRet != 0 ? className.ToString() : null;
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

        /// <summary>
        /// Заголовок (caption) окна
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        public static string GetControlText(IntPtr hWnd)
        {

            // Get the size of the string required to hold the window title (including trailing null.) 
            Int32 titleSize = SendMessage((int)hWnd, WM_GETTEXTLENGTH, 0, 0).ToInt32();
            // If titleSize is 0, there is no title so return an empty string (or null)
            if (titleSize == 0)
                return String.Empty;
            StringBuilder title = new StringBuilder(titleSize + 1);
            SendMessage(hWnd, (int)WM_GETTEXT, title.Capacity, title);

            return title.ToString();
        }

        [DllImport("user32.dll")]
        static extern IntPtr ChildWindowFromPoint(IntPtr hWndParent, Point pt, uint uFlags);

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

        [DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        public static extern bool SendMessage(IntPtr hWnd, uint Msg, int wParam, StringBuilder lParam);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SendMessage(int hWnd, int Msg, int wparam, int lparam);

        [DllImport("User32.dll")]
        public static extern IntPtr GetWindow(IntPtr hwnd, uint uCmd);

        public const int MOUSEEVENTF_LEFTDOWN = 0x02;
        public const int MOUSEEVENTF_LEFTUP = 0x04;
        public const int WM_MOUSEMOVE = 0x0200;
        public const int WM_LBUTTONDOWN = 0x0201;
        public const int WM_LBUTTONUP = 0x0202;
        //const byte VK_3 = 0x33;
        const int WM_GETTEXT = 0x000D;
        const int WM_GETTEXTLENGTH = 0x000E;
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
        const byte VK_SHIFT = 0x10;
        public const UInt32 KEYEVENTF_EXTENDEDKEY = 1;
        public const UInt32 KEYEVENTF_KEYUP = 2;
        internal const UInt32 MF_BYCOMMAND = 0x00000000;
        internal const UInt32 MF_BYPOSITION = 0x00000400;
        #endregion

        private void nextControl_btn_Click(object sender, EventArgs e)
        {
            OpenDCL();
           
            keybd_event(VK_TAB, 0, 0, 0); //клавиша Tab
            keybd_event(VK_TAB, 0, KEYEVENTF_KEYUP, 0);
            
            TextBoxInfo currentControl = new TextBoxInfo(GetFocus(), GetControlText(GetFocus()));
            propertyOfControl.SelectedObject = currentControl;
        }

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, IntPtr lpszWindow);

        private List<TextBoxInfo> GetUrlFromIE(IntPtr windowHandle)
        {
            
            IntPtr childHandle;
            List<TextBoxInfo> collectionTextBox = new List<TextBoxInfo>();
            //try to get a handle to IE's toolbar container
            childHandle = FindWindowEx(windowHandle, IntPtr.Zero, "MDIClient", IntPtr.Zero);
            if (childHandle != IntPtr.Zero)
            {
                //get a handle to address bar
                childHandle = FindWindowEx(childHandle, IntPtr.Zero, "ThunderRT6FormDC", IntPtr.Zero);
                if (childHandle != IntPtr.Zero)
                {
                    
                    // get a handle to combo box
                    childHandle = FindWindowEx(childHandle, IntPtr.Zero, "ThunderRT6Frame", IntPtr.Zero);
                        
                            //get handle to edit
                    IntPtr childHandlee = FindWindowEx(childHandle, IntPtr.Zero, "ThunderRT6TextBox", IntPtr.Zero);
                    if (childHandlee != IntPtr.Zero)
                    {
                        //strUrlToReturn.Add(GetControlText(childHandle));
                    }

                    else
                    {
                        IntPtr dlgHandle = GetWindow(childHandle, (uint)GetWindowType.GW_HWNDNEXT);
                        if (dlgHandle != IntPtr.Zero)
                        {
                            //get handle to edit
                            IntPtr dlgHandlee = FindWindowEx(dlgHandle, IntPtr.Zero, "ThunderRT6TextBox", IntPtr.Zero);
                            if (dlgHandlee != IntPtr.Zero)
                            {
                                //strUrlToReturn.Add(GetControlText(dlgHandle));
                            }

                            else
                            {
                                dlgHandle = GetWindow(dlgHandle, (uint)GetWindowType.GW_HWNDNEXT);
                                if (childHandle != IntPtr.Zero)
                                {
                                    //get handle to edit
                                    childHandle = FindWindowEx(dlgHandle, IntPtr.Zero, "ThunderRT6TextBox", IntPtr.Zero);
                                    if (childHandle != IntPtr.Zero)
                                    {
                                        WhileNextWindow(childHandle, collectionTextBox);
                                    }
                                    else
                                    {

                                    }
                                }
                            }
                        }
                    }

                    
                }
            }
            return collectionTextBox;
        }
       
        public static void WhileNextWindow(IntPtr first,List<TextBoxInfo> collectionTextBox)
        {
            IntPtr second = GetWindow(first, (uint)GetWindowType.GW_HWNDNEXT);
            if (second == IntPtr.Zero)
                return;
            // childHandle = FindWindowEx(second, IntPtr.Zero, "ThunderRT6TextBox", IntPtr.Zero);
            int nRet;
            // Pre-allocate 256 characters, since this is the maximum class name length.
            StringBuilder ClassName = new StringBuilder(256);
            //Get the window class name
            nRet = GetClassName(second, ClassName, ClassName.Capacity);
            
            if (GetControlText(second) != null || GetControlText(second) != "")
            {
                if (ClassName.ToString() == "ThunderRT6TextBox")
                { 
                    collectionTextBox.Add(new TextBoxInfo(second, GetControlText(second)));
                }
                WhileNextWindow(second, collectionTextBox); //переход на следующий контрол
            }
        }
        public enum GetWindowType : uint
        {
            /// <summary>
            /// The retrieved handle identifies the window of the same type that is highest in the Z order.
            /// <para/>
            /// If the specified window is a topmost window, the handle identifies a topmost window.
            /// If the specified window is a top-level window, the handle identifies a top-level window.
            /// If the specified window is a child window, the handle identifies a sibling window.
            /// </summary>
            GW_HWNDFIRST = 0,
            /// <summary>
            /// The retrieved handle identifies the window of the same type that is lowest in the Z order.
            /// <para />
            /// If the specified window is a topmost window, the handle identifies a topmost window.
            /// If the specified window is a top-level window, the handle identifies a top-level window.
            /// If the specified window is a child window, the handle identifies a sibling window.
            /// </summary>
            GW_HWNDLAST = 1,
            /// <summary>
            /// The retrieved handle identifies the window below the specified window in the Z order.
            /// <para />
            /// If the specified window is a topmost window, the handle identifies a topmost window.
            /// If the specified window is a top-level window, the handle identifies a top-level window.
            /// If the specified window is a child window, the handle identifies a sibling window.
            /// </summary>
            GW_HWNDNEXT = 2,
            /// <summary>
            /// The retrieved handle identifies the window above the specified window in the Z order.
            /// <para />
            /// If the specified window is a topmost window, the handle identifies a topmost window.
            /// If the specified window is a top-level window, the handle identifies a top-level window.
            /// If the specified window is a child window, the handle identifies a sibling window.
            /// </summary>
            GW_HWNDPREV = 3,
            /// <summary>
            /// The retrieved handle identifies the specified window's owner window, if any.
            /// </summary>
            GW_OWNER = 4,
            /// <summary>
            /// The retrieved handle identifies the child window at the top of the Z order,
            /// if the specified window is a parent window; otherwise, the retrieved handle is NULL.
            /// The function examines only child windows of the specified window. It does not examine descendant windows.
            /// </summary>
            GW_CHILD = 5,
            /// <summary>
            /// The retrieved handle identifies the enabled popup window owned by the specified window (the
            /// search uses the first such window found using GW_HWNDNEXT); otherwise, if there are no enabled
            /// popup windows, the retrieved handle is that of the specified window.
            /// </summary>
            GW_ENABLEDPOPUP = 6
        }
        
        private void showAllTextBoxes_btn_Click(object sender, EventArgs e)
        {
            OpenDCL();
            controlList.Clear();
            IntPtr windowDCLMenu = WindowFromPoint(System.Windows.Forms.Cursor.Position = new Point(47, 30));//Меню - Документ
            List<TextBoxInfo> collectionTextBox = GetUrlFromIE(windowDCLMenu);
            foreach (TextBoxInfo tbi in collectionTextBox)
            {
                if (tbi.caption != "")
                {
                    controlList.Items.Add(tbi.caption);
                    controlList.Items[controlList.Items.Count - 1].Tag = tbi;
                }
            }
        }

        private void nextControlRight_btn_Click(object sender, EventArgs e)
        {
            OpenDCL();
            //keybd_event(VK_ALT, 0, 0, 0); //клавиша Alt
            //keybd_event(VK_L, 0, 0, 0); //буква Д
            //keybd_event(VK_ALT, 0, KEYEVENTF_KEYUP, 0);
            //keybd_event(VK_L, 0, KEYEVENTF_KEYUP, 0);
            keybd_event(VK_RIGHT, 0, 0, 0); //стрелка вправо
            keybd_event(VK_RIGHT, 0, KEYEVENTF_KEYUP, 0);
        }

        private void nextControlDown_btn_Click(object sender, EventArgs e)
        {
            OpenDCL();
            keybd_event(VK_ALT, 0, 0, 0); //клавиша Alt
            keybd_event(VK_L, 0, 0, 0); //буква Д
            keybd_event(VK_ALT, 0, KEYEVENTF_KEYUP, 0);
            keybd_event(VK_L, 0, KEYEVENTF_KEYUP, 0);
            keybd_event(VK_DOWN, 0, 0, 0); //стрелка вниз
            keybd_event(VK_DOWN, 0, KEYEVENTF_KEYUP, 0);
        }

        private void controlList_MouseClick(object sender, MouseEventArgs e)
        {
            if (controlList.SelectedItems.Count != 0)
            {
                TextBoxInfo tbi = (TextBoxInfo)controlList.SelectedItems[0].Tag;
                propertyOfControl.SelectedObject = tbi;
            }
        }

        [DllImport("user32.dll")]
        static extern IntPtr GetFocus();

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        static extern bool AttachThreadInput(uint idAttach, uint idAttachTo,
   bool fAttach);
        private void prevControlDT_btn_Click(object sender, EventArgs e)
        {
            OpenDCL();
           
            keybd_event(VK_SHIFT, 0, 0, 0); //клавиша Tab
            keybd_event(VK_TAB, 0, 0, 0);
            keybd_event(VK_SHIFT, 0, KEYEVENTF_KEYUP, 0);
            keybd_event(VK_TAB, 0, KEYEVENTF_KEYUP, 0);
            
            TextBoxInfo currentControl = new TextBoxInfo(GetFocus(), GetControlText(GetFocus()));
            propertyOfControl.SelectedObject = currentControl;

        }
        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr SetFocus(IntPtr hWnd);
        
        private void showOnPropGrid_btn_Click(object sender, EventArgs e)
        {
            OpenDCL();
            TextBoxInfo currentControl = new TextBoxInfo(GetFocus(), GetControlText(GetFocus()));
            propertyOfControl.SelectedObject = currentControl;
        }

        
    }
}
