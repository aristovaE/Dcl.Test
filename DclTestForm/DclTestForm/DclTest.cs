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
                EnterShortcuts(VK_ALT,VK_L);             //ввод комбинаций клавиш для открытия меню
                EnterShortcuts(VK_D);             //ввод комбинаций клавиш для открытия меню
                EnterShortcuts(VK_RETURN);             //ввод комбинаций клавиш для открытия меню
                EnterShortcuts(VK_ESCAPE);             //ввод комбинаций клавиш для открытия меню
            }

            else if (howToOpenDT_cmb.SelectedIndex == 1)
            {
                OpenDCL();
                SendMessageAndClick(47, 30);    //наведение мыши через SendMessage "Документ"
                SendMessageAndClick(96, 76);    //"Открыть ДТ"
                SendMessageAndClick(1700, 900); //"Отмена"
                // MoveMouseAndClick(47, 30);    //наведение мыши через mouse_event
                // MoveMouseAndClick(96, 76);
                // MoveMouseAndClick(1700, 880);
            }
        }

        public const int WM_SETTEXT = 0x000C;

        private void enterKey_btn_Click(object sender, EventArgs e)
        {
            OpenDCLWithAttach();
            //byte[] byteToString = Encoding.GetEncoding(1251).GetBytes(enterKey_tb.Text);  //не работает для букв
            //foreach (byte key in byteToString)
            //    EnterKey(key);
            StringBuilder sb = new StringBuilder(enterKey_tb.Text);
            SendMessage(GetFocus(), WM_SETTEXT, 0, sb);
            //SendKeys.SendWait(enterKey_tb.Text);          //работает
            //SendKeys.Flush();

        }
        
        private void doAll_btn_Click(object sender, EventArgs e)
        {
            enterKey_btn_Click(sender, e);
            openDT_btn_Click(sender, e);
        }

        /// <summary>
        /// Открытие ВД
        /// </summary>
        private static IntPtr OpenDCL()
        {
            IntPtr hwnd = FindWindow(null, "ВЭД-Декларант");
            ////"ВЭД-Декларант (расширенная версия) 9.97 от 01.10.2020 (10000000/220719/0000004) - [ДТ (основной лист)]"

            //ПРИ ОБЪЕДИНЕНИИ ПОТОКОВ ТОРМОЗИТ - МБ ДОБАВИТЬ ОБЪЕДИНЕНИЕ ПОТОК ОТДЕЛЬНЫМ МЕТОДОВ ТОЛЬКО ДЛЯ ВВОДА?
            //uint ThreadID1 = GetWindowThreadProcessId(GetForegroundWindow(), out uint id);
            //uint ThreadID2 = GetWindowThreadProcessId(hwnd, out uint idd);
            //AttachThreadInput(ThreadID1, ThreadID2, true);
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
        /// <summary>
        /// Открытие ВД со слиянием потоков
        /// </summary>
        private static IntPtr OpenDCLWithAttach()
        {
            IntPtr hwnd = FindWindow(null, "ВЭД-Декларант");
            ////"ВЭД-Декларант (расширенная версия) 9.97 от 01.10.2020 (10000000/220719/0000004) - [ДТ (основной лист)]"

            //ПРИ ОБЪЕДИНЕНИИ ПОТОКОВ ТОРМОЗИТ - МБ ДОБАВИТЬ ОБЪЕДИНЕНИЕ ПОТОК ОТДЕЛЬНЫМ МЕТОДОВ ТОЛЬКО ДЛЯ ВВОДА?
            uint ThreadID1 = GetWindowThreadProcessId(GetForegroundWindow(), out uint id);
            uint ThreadID2 = GetWindowThreadProcessId(hwnd, out uint idd);
            AttachThreadInput(ThreadID1, ThreadID2, true);
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
        private static void AttachDCL(IntPtr first, IntPtr second)
        {
            uint ThreadID1 = GetWindowThreadProcessId(first, out uint id);
            uint ThreadID2 = GetWindowThreadProcessId(second, out uint idd);
            AttachThreadInput(ThreadID1, ThreadID2, true);
        }
         private static void DisAttachDCL(IntPtr first, IntPtr second)
        {
            uint ThreadID1 = GetWindowThreadProcessId(first, out uint id);
            uint ThreadID2 = GetWindowThreadProcessId(second, out uint idd);
            AttachThreadInput(ThreadID1, ThreadID2, false);
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
        /// (сочетание клавиш (keybd_event))
        /// </summary>
        private static void EnterShortcuts(byte keyButton1,byte keyButton2)
        {
            //ввод сочетания клавиш
                keybd_event(keyButton1, 0, 0, 0); //
                keybd_event(keyButton2, 0, 0, 0); //
                keybd_event(keyButton1, 0, KEYEVENTF_KEYUP, 0);
                keybd_event(keyButton2, 0, KEYEVENTF_KEYUP, 0);
            
            Thread.Sleep(1000);
        }
        /// <summary>
        /// (сочетание клавиш (keybd_event))
        /// </summary>
        private static void EnterShortcuts(byte keyButton)
        {
            //ввод клавиши
            keybd_event(keyButton, 0, 0, 0); //
            keybd_event(keyButton, 0, KEYEVENTF_KEYUP, 0);
            Thread.Sleep(1000);
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

        private void nextControl_btn_Click(object sender, EventArgs e)
        {
            OpenDCL();
            keybd_event(VK_TAB, 0, 0, 0); //клавиша Tab
            keybd_event(VK_TAB, 0, KEYEVENTF_KEYUP, 0);
            
            //TextBoxInfo currentControl = new TextBoxInfo(GetFocus(), GetControlText(GetFocus()));
            //propertyOfControl.SelectedObject = currentControl;
        }
        private void prevControlDT_btn_Click(object sender, EventArgs e)
        {
            OpenDCL();
            keybd_event(VK_SHIFT, 0, 0, 0); //клавиша Tab
            keybd_event(VK_TAB, 0, 0, 0);
            keybd_event(VK_SHIFT, 0, KEYEVENTF_KEYUP, 0);
            keybd_event(VK_TAB, 0, KEYEVENTF_KEYUP, 0);

            //TextBoxInfo currentControl = new TextBoxInfo(GetFocus(), GetControlText(GetFocus()));
            //propertyOfControl.SelectedObject = currentControl;

        }
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, IntPtr lpszWindow);

        public static void WhileNextWindow(IntPtr first,List<TextBoxInfo> collectionTextBox,string className)
        {

            IntPtr second = GetWindow(first, (uint)GetWindowType.GW_HWNDNEXT);
            if (second == IntPtr.Zero)
                return;
            int nRet;
            StringBuilder ClassName = new StringBuilder(256);
            nRet = GetClassName(second, ClassName, ClassName.Capacity);
            
            if (GetControlText(second) != null || GetControlText(second) != "")
            {
                if (ClassName.ToString() == className)
                { 
                    collectionTextBox.Add(new TextBoxInfo(second, GetControlText(second)));
                }
                WhileNextWindow(second, collectionTextBox,className); //переход на следующий контрол
            }
        }
       
        
        private void showAllTextBoxes_btn_Click(object sender, EventArgs e)
        {
            OpenDCL();
            controlList.Clear();
            IntPtr windowDCLMenu = WindowFromPoint(System.Windows.Forms.Cursor.Position = new Point(47, 30));//Меню - Документ
            IntPtr firstControl = findFirstTextBox(windowDCLMenu);
            List<TextBoxInfo> collectionTextBox = new List<TextBoxInfo>();
            WhileNextWindow(firstControl, collectionTextBox, "ThunderRT6TextBox");
            //List<TextBoxInfo> collectionTextBox = GetUrlFromIE(windowDCLMenu);
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
                OpenDCLWithAttach();
                IntPtr windowDCLMenu = WindowFromPoint(System.Windows.Forms.Cursor.Position = new Point(47, 30));//Меню - Документ
                IntPtr firstControl = findFirstTextBox(windowDCLMenu);
                List<TextBoxInfo> collectionTextBox = new List<TextBoxInfo>();
                WhileNextWindow(firstControl, collectionTextBox, "ThunderRT6TextBox");
                TextBoxInfo toFind = (TextBoxInfo)propertyOfControl.SelectedObject;
                foreach (TextBoxInfo textbox in collectionTextBox)
                {
                    if (toFind.handle == textbox.handle)
                    {
                        SetFocus(toFind.handle);
                    }
                }
            }
        }
        
        private void showOnPropGrid_btn_Click(object sender, EventArgs e)
        {
            OpenDCL();
            TextBoxInfo currentControl = new TextBoxInfo(GetFocus(), GetControlText(GetFocus()));
            propertyOfControl.SelectedObject = currentControl;
        }

        private IntPtr findFirstTextBox(IntPtr windowHandle)
        {
            IntPtr childHandle;
            List<TextBoxInfo> collectionTextBox = new List<TextBoxInfo>();
            childHandle = FindWindowEx(windowHandle, IntPtr.Zero, "MDIClient", IntPtr.Zero);
            if (childHandle != IntPtr.Zero)
            {
                childHandle = FindWindowEx(childHandle, IntPtr.Zero, "ThunderRT6FormDC", IntPtr.Zero);
                if (childHandle != IntPtr.Zero)
                {
                    childHandle = FindWindowEx(childHandle, IntPtr.Zero, "ThunderRT6Frame", IntPtr.Zero);
                    IntPtr childHandlee = FindWindowEx(childHandle, IntPtr.Zero, "ThunderRT6TextBox", IntPtr.Zero);
                    if (childHandlee != IntPtr.Zero)
                    {
                    }

                    else
                    {
                        IntPtr dlgHandle = GetWindow(childHandle, (uint)GetWindowType.GW_HWNDNEXT);
                        if (dlgHandle != IntPtr.Zero)
                        {
                            IntPtr dlgHandlee = FindWindowEx(dlgHandle, IntPtr.Zero, "ThunderRT6TextBox", IntPtr.Zero);
                            if (dlgHandlee != IntPtr.Zero)
                            {
                            }

                            else
                            {
                                dlgHandle = GetWindow(dlgHandle, (uint)GetWindowType.GW_HWNDNEXT);
                                if (childHandle != IntPtr.Zero)
                                {
                                    childHandle = FindWindowEx(dlgHandle, IntPtr.Zero, "ThunderRT6TextBox", IntPtr.Zero);
                                    if (childHandle != IntPtr.Zero)
                                    {
                                        return childHandle;
                                        //WhileNextWindow(childHandle, collectionTextBox);
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
            return childHandle;
        }
  
        private void propertyOfControl_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            OpenDCL();
            IntPtr windowDCLMenu = WindowFromPoint(System.Windows.Forms.Cursor.Position = new Point(47, 30));
            IntPtr firstControl = findFirstTextBox(windowDCLMenu);
            List<TextBoxInfo> collectionTextBox = new List<TextBoxInfo>();
            WhileNextWindow(firstControl, collectionTextBox, "ThunderRT6TextBox");
            TextBoxInfo toFind = (TextBoxInfo)propertyOfControl.SelectedObject;
            foreach (TextBoxInfo tbi in collectionTextBox)
            {
                if (toFind.handle == tbi.handle)
                {
                    SetFocus(toFind.handle);
                    SendMessage(toFind.handle, EM_SETSEL, 0, -1);
                    StringBuilder sb = new StringBuilder(toFind.caption);
                    SendMessage(GetFocus(), WM_SETTEXT, 0, sb);
                }
            }
        }
        private void findAndRenameNext_btn_Click(object sender, EventArgs e)
        {
            OpenDCL();
            IntPtr windowDCLMenu = WindowFromPoint(System.Windows.Forms.Cursor.Position = new Point(47, 30));//Меню - Документ
            IntPtr firstControl = findFirstTextBox(windowDCLMenu);
            List<TextBoxInfo> collectionTextBox = new List<TextBoxInfo>();
            WhileNextWindow(firstControl, collectionTextBox, "ThunderRT6TextBox");
            IntPtr prevHandle = IntPtr.Zero;
            foreach (TextBoxInfo tbi in collectionTextBox)
            {
                if (tbi.caption == "ООО \"СТМ\"")
                {
                    SetFocus(tbi.handle);
                    keybd_event(VK_TAB, 0, 0, 0); //клавиша Tab
                    keybd_event(VK_TAB, 0, KEYEVENTF_KEYUP, 0);
                    SendKeys.SendWait("ГОРОД");          //работает
                    SendKeys.Flush();
                    //SendMessage(GetFocus(), WM_SETTEXT, 0, new StringBuilder("ГОРОД")); //не работает
                    break;
                }
            }
        }

        private void getWindowRect_btn_Click(object sender, EventArgs e)
        {
            OpenDCL();
            IntPtr windowDCLMenu = WindowFromPoint(System.Windows.Forms.Cursor.Position = new Point(47, 30));//Меню - Документ
            RECT rct;

            if (!GetWindowRect(windowDCLMenu, out rct))
            {
                MessageBox.Show("ERROR");
                return;
            }

            int widthOfDCL = rct.xBottomRight - rct.xUpLeft + 1;
            int heightOfDCL = rct.yBottomRight - rct.yUpLeft + 1;
            label2.Text = $"Ширина: {widthOfDCL}; Высота: {heightOfDCL}. ({rct.xUpLeft},{rct.yUpLeft};{rct.xBottomRight},{rct.yBottomRight})";
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

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SendMessage(int hWnd, int Msg, int wparam, int lparam);

        [DllImport("User32.dll")]
        public static extern IntPtr GetWindow(IntPtr hwnd, uint uCmd);

        [DllImport("user32.dll")]
        static extern IntPtr GetFocus();

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        static extern bool AttachThreadInput(uint idAttach, uint idAttachTo, bool fAttach);

        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr SetFocus(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);
        
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int xUpLeft;        // x position of upper-left corner
            public int yUpLeft;         // y position of upper-left corner
            public int xBottomRight;       // x position of lower-right corner
            public int yBottomRight;      // y position of lower-right corner
        }

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
        const byte VK_B = 0x42;
        const byte VK_D = 0x44;
        const byte VK_P = 0x50;
        const byte VK_Y = 0x59;
        const byte VK_RETURN = 0x0D;
        const byte VK_ESCAPE = 0x1B;
        const byte VK_LEFT = 0x25;
        const byte VK_UP = 0x26;
        const byte VK_RIGHT = 0x27;
        const byte VK_DOWN = 0x28;
        const byte VK_F4 = 0x73;
        const byte VK_F6 = 0x75;
        const byte VK_F9 = 0x78;
        const byte VK_TAB = 0x9;
        const byte VK_SHIFT = 0x10;
        const int EM_SETSEL = 0x00B1;
        const int WM_CLEAR = 0x0303;
        public const UInt32 KEYEVENTF_EXTENDEDKEY = 1;
        public const UInt32 KEYEVENTF_KEYUP = 2;
        internal const UInt32 MF_BYCOMMAND = 0x00000000;
        internal const UInt32 MF_BYPOSITION = 0x00000400;

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
        #endregion

        private void startScript1_Click(object sender, EventArgs e)
        {
            IntPtr testWindow = GetFocus();
            OpenDCL();
            //OpenDCLWithAttach();
            IntPtr windowDCLMenu = WindowFromPoint(System.Windows.Forms.Cursor.Position = new Point(47, 30)); //Меню - Документ
            EnterShortcuts(VK_ALT, VK_L);
            EnterShortcuts(VK_L);
            EnterShortcuts(VK_RETURN);
            EnterShortcuts(VK_RETURN);
            EnterShortcuts(VK_TAB);
            Thread.Sleep(2000);
            EnterShortcuts(VK_RETURN);
            Thread.Sleep(2000);
            EnterShortcuts(VK_F6);
            RECT rct;
            if (!GetWindowRect(windowDCLMenu, out rct))
            {
                MessageBox.Show("ERROR");
                return;
            }
            int widthOfDCL = rct.xBottomRight - rct.xUpLeft + 1;
            int heightOfDCL = rct.yBottomRight - rct.yUpLeft + 1;
            IntPtr windowF6 = WindowFromPoint(Cursor.Position = new Point(widthOfDCL / 2, heightOfDCL / 4)); //ПРОВЕРИТЬ ЗНАЧЕНИЯ
            //SendMessage(windowDCLMenu, WM_MOUSEMOVE, (IntPtr)0, MakeParam(widthOfDCL / 2, heightOfDCL / 4));
            Thread.Sleep(2000);
            AttachDCL(windowF6, testWindow);
            SendMessage(GetFocus(), WM_SETTEXT, 0, new StringBuilder("2"));
            DisAttachDCL(windowF6, testWindow);
            //SendKeys.SendWait("2");         
            //SendKeys.Flush();
            Thread.Sleep(1000);
            //IntPtr mainF6 = GetWindow(windowF6, (uint)GetWindowType.GW_OWNER);

            EnterShortcuts(VK_RETURN);
            //РАЗБИТЬ ПОТОКИ А ПОТОМ СОЗДАВАТЬ НОВЫЕ ЗАНОВО?
            //SetFocus(windowDCLMenu);
            //Thread.Sleep(1000);
            EnterShortcuts(VK_ESCAPE);
            Thread.Sleep(1000);
            EnterShortcuts(VK_F4);
            //List<TextBoxInfo> collectionTextBox = new List<TextBoxInfo>();
            //IntPtr windowF4 = WindowFromPoint(Cursor.Position = new Point(widthOfDCL / 2, heightOfDCL / 4)); //ПРОВЕРИТЬ ЗНАЧЕНИЯ
            //StringBuilder ClassName = new StringBuilder(256);
            //int nRet = GetClassName(windowF4, ClassName, ClassName.Capacity);          
            //resultOf1.Text = ClassName.ToString();

            EnterShortcuts(VK_RETURN);
            Thread.Sleep(3000);
            EnterShortcuts(VK_ESCAPE);
            Thread.Sleep(1000);
            EnterShortcuts(VK_F6);
            Thread.Sleep(2000);
            //windowF6 = WindowFromPoint(Cursor.Position = new Point(widthOfDCL / 2, heightOfDCL / 4)); //ПРОВЕРИТЬ ЗНАЧЕНИЯ
            //AttachDCL(windowF6, FindWindow(null, "DclTest"));
            //SendMessage(GetFocus(), WM_SETTEXT, 0, new StringBuilder("11"));

            AttachDCL(windowF6, testWindow);
            SendMessage(GetFocus(), WM_SETTEXT, 0, new StringBuilder("11"));
            DisAttachDCL(windowF6, testWindow);
            Thread.Sleep(1000);
            EnterShortcuts(VK_RETURN);
            //EnterShortcuts(VK_ESCAPE);
            Thread.Sleep(1000);
            EnterShortcuts(VK_F9);
            Thread.Sleep(1000);
            EnterShortcuts(VK_F6);
            Thread.Sleep(2000);
            //windowF6 = WindowFromPoint(Cursor.Position = new Point(widthOfDCL / 2, heightOfDCL / 4)); //ПРОВЕРИТЬ ЗНАЧЕНИЯ
            //AttachDCL(windowF6, FindWindow(null, "DclTest"));
            //SendMessage(GetFocus(), WM_SETTEXT, 0, new StringBuilder("15"));

            //SendKeys.SendWait("15");
            //SendKeys.Flush();
            AttachDCL(windowF6, testWindow);
            SendMessage(GetFocus(), WM_SETTEXT, 0, new StringBuilder("15"));
            DisAttachDCL(windowF6, testWindow); 
            Thread.Sleep(1000);
            EnterShortcuts(VK_RETURN);
            //EnterShortcuts(VK_ESCAPE);
            Thread.Sleep(1000);
            EnterShortcuts(VK_F9);
            Thread.Sleep(1000);
            EnterShortcuts(VK_ALT, VK_L);
            Thread.Sleep(1000);
            EnterShortcuts(VK_P);
            Thread.Sleep(1000);
            EnterShortcuts(VK_RETURN); //записать на диск
            Thread.Sleep(1000);
            EnterShortcuts(VK_RETURN); //в формате XML
            Thread.Sleep(1000);
            EnterShortcuts(VK_RETURN); //да
            Thread.Sleep(1000);
            EnterShortcuts(VK_RETURN); //нет
            Thread.Sleep(1000);
            EnterShortcuts(VK_RETURN); //нет
            Thread.Sleep(3000);
            EnterShortcuts(VK_TAB);
            EnterShortcuts(VK_RETURN); //нет
            Thread.Sleep(1000);
            resultOf1.Text += " успешно";
        }

        private void startScript2_Click(object sender, EventArgs e)
        {
            OpenDCL();
            IntPtr windowDCLMenu = WindowFromPoint(System.Windows.Forms.Cursor.Position = new Point(47, 30)); //Меню - Документ
            EnterShortcuts(VK_ALT, VK_L);
            EnterShortcuts(VK_L);
            EnterShortcuts(VK_B);
            EnterShortcuts(VK_B);
            EnterShortcuts(VK_RETURN);
            RECT rct;
            if (!GetWindowRect(windowDCLMenu, out rct))
            {
                MessageBox.Show("ERROR");
                return;
            }
            int widthOfDCL = rct.xBottomRight - rct.xUpLeft + 1;
            int heightOfDCL = rct.yBottomRight - rct.yUpLeft + 1;
            SendMessage(windowDCLMenu, WM_MOUSEMOVE, (IntPtr)0, MakeParam(widthOfDCL / 2, heightOfDCL / 4));
            Thread.Sleep(1000);
            IntPtr windowChooseFile = WindowFromPoint(Cursor.Position = new Point(widthOfDCL / 2, heightOfDCL / 4)); //ПРОВЕРИТЬ ЗНАЧЕНИЯ
            //StringBuilder ClassName = new StringBuilder(256);
            //int nRet = GetClassName(windowChooseFile, ClassName, ClassName.Capacity);
            //while (!GetControlText(windowChooseFile).Contains("Прочитать данные из файла"))
            //{
            //    windowChooseFile = GetParent(windowChooseFile);
            //}
            //resultOf2.Text= ClassName.ToString() + "\n"+GetControlText(windowChooseFile); 
            //ClassName = new StringBuilder(256);
            //nRet = GetClassName(windowChooseFile, ClassName, ClassName.Capacity);
            while (WindowFromPoint(Cursor.Position = new Point(widthOfDCL / 2, heightOfDCL / 4))== windowChooseFile)
            {
                Thread.Sleep(2000);
                resultOf2.Text = "жду закрытия окна";
            }
            //ClassName = new StringBuilder(256);
            //nRet = GetClassName(GetFocus(), ClassName, ClassName.Capacity);
            resultOf2.Text = "дождался закрытия окна";
            //Thread.Sleep(10000);
            //nRet = GetClassName(GetFocus(), ClassName, ClassName.Capacity);
            //resultOf2.Text += "\n" + ClassName;
            EnterShortcuts(VK_RETURN); //ок
            Thread.Sleep(2000);
            EnterShortcuts(VK_TAB);
            EnterShortcuts(VK_RETURN); //открыть ДТ
            EnterShortcuts(VK_ALT, VK_L);
            EnterShortcuts(VK_P);
            EnterShortcuts(VK_RETURN); //записать на диск
            EnterShortcuts(VK_D);
            EnterShortcuts(VK_D);
            EnterShortcuts(VK_RETURN); //в формате СТМ
            EnterShortcuts(VK_RETURN); //записать
            EnterShortcuts(VK_RETURN); //да
            EnterShortcuts(VK_RETURN); //ок
            EnterShortcuts(VK_RETURN); //ок
            resultOf2.Text = "Результат: успешно";
        }


        private void startScript3_Click(object sender, EventArgs e)
        {
            OpenDCL();
            IntPtr windowDCLMenu = WindowFromPoint(System.Windows.Forms.Cursor.Position = new Point(47, 30)); //Меню - Документ
            EnterShortcuts(VK_ALT, VK_L);
            EnterShortcuts(VK_L);
            EnterShortcuts(VK_LEFT);
            EnterShortcuts(VK_DOWN);
            EnterShortcuts(VK_RETURN);

        }

        private void startScript4_btn_Click(object sender, EventArgs e)
        {
            //открытие "С чистого листа"
            //alt+l, y, l, 6 tab, arrowUp,enter, arrowDown, enter, arrowDown, enter, enter
            OpenDCL();
            IntPtr windowDCLMenu = WindowFromPoint(System.Windows.Forms.Cursor.Position = new Point(47, 30)); //Меню - Документ
            EnterShortcuts(VK_ALT, VK_L);
            EnterShortcuts(VK_Y);
            EnterShortcuts(VK_L);
            for(int i = 0; i < 6; i++)
            {
                EnterShortcuts(VK_TAB);
            }
            EnterShortcuts(VK_UP);
            EnterShortcuts(VK_RETURN);
            EnterShortcuts(VK_DOWN);
            EnterShortcuts(VK_RETURN);
            EnterShortcuts(VK_DOWN);
            EnterShortcuts(VK_RETURN);
            EnterShortcuts(VK_RETURN);
            // f6, 2, f4, ?enter?, 7, 8, 9, 14, 11, 15, 17, 18, 19, 20, 22, 24, 29, 30

            EnterShortcuts(VK_F6);
            RECT rct;
            if (!GetWindowRect(windowDCLMenu, out rct))
            {
                MessageBox.Show("ERROR");
                return;
            }
            int widthOfDCL = rct.xBottomRight - rct.xUpLeft + 1;
            int heightOfDCL = rct.yBottomRight - rct.yUpLeft + 1;
            IntPtr windowF6 = WindowFromPoint(Cursor.Position = new Point(widthOfDCL / 2, heightOfDCL / 4)); //ПРОВЕРИТЬ ЗНАЧЕНИЯ
            AttachDCL(windowF6, FindWindow(null, "DclTest"));
            SendMessage(GetFocus(), WM_SETTEXT, 0, new StringBuilder("2"));
            DisAttachDCL(windowF6, FindWindow(null, "DclTest"));
            EnterShortcuts(VK_RETURN);
            EnterShortcuts(VK_RETURN);
        }
    }
}
