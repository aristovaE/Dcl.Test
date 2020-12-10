using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace DclTestFormWPy
{
    /// <summary>
    ////Часть кода (winAPI взаимодейтсвие)
    /// </summary>
    public partial class DclTestFormWPy
    {
        /// <summary>
        /// Открытие ВД
        /// </summary>
        private static IntPtr OpenDCL()
        {
            IntPtr hwnd = FindWindow(null, "ВЭД-Декларант");
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
        private void FindField(string numberOfField)
        {
            EnterShortcut(VK_F6);
            Thread.Sleep(2000);
            IntPtr windowF6 = GetForegroundWindow();
            //проверка на то что фокус уже в нужном поле?
            EnterText(windowF6, numberOfField);
            Thread.Sleep(1000);
            EnterShortcut(VK_RETURN);
        }

        private void EnterText(IntPtr windowFocus, string strToEnter)
        {
            uint ThreadID1 = GetWindowThreadProcessId(FindWindow(null, "DclTest"), out _);
            uint ThreadID2 = GetWindowThreadProcessId(windowFocus, out uint _);
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
        /// Ввод сочетания клавиш (keybd_event)
        /// </summary>
        private static void EnterShortcuts(byte keyButton1, byte keyButton2)
        {
            //ввод сочетания клавиш
            keybd_event(keyButton1, 0, 0, 0); //
            keybd_event(keyButton2, 0, 0, 0); //
            keybd_event(keyButton2, 0, KEYEVENTF_KEYUP, 0);
            keybd_event(keyButton1, 0, KEYEVENTF_KEYUP, 0);

            Thread.Sleep(1000);
        }
        /// <summary>
        /// Ввод клавиши (keybd_event)
        /// </summary>
        private static void EnterShortcut(byte keyButton)
        {
            //ввод клавиши
            keybd_event(keyButton, 0, 0, 0); //
            keybd_event(keyButton, 0, KEYEVENTF_KEYUP, 0);
            Thread.Sleep(1000);
        }

        ///// <summary>
        ///// Нажатие ЛКМ
        ///// </summary>
        ///// <param name="x"></param>
        ///// <param name="y"></param>
        //private static void DoMouseLeftClick(int x, int y)
        //{
        //    mouse_event(MOUSEEVENTF_LEFTDOWN, x, y, 0, 0);
        //    mouse_event(MOUSEEVENTF_LEFTUP, x, y, 0, 0);
        //}

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


        private void StartScript_btn_Click(object sender, EventArgs e)
        {
            TestEachCommand();
        }

        private void TestEachCommand()
        {
            List<string> commands = new List<string>();
            for (int i = 0; i < TableScript_dgv.Rows.Count; i++)
            {
                commands.Add(TableScript_dgv.Rows[i].Cells[1].Value.ToString());
            }
            int numOfCommand = 0;
            int column = 1, row = 1;
            IntPtr windowFocus = IntPtr.Zero;
            bool IsStop = false;
            try
            {
                foreach (string command in commands)
                {
                    switch (command)
                    {
                        case "открыть окно ВД":
                            OpenDCL();
                            windowFocus = GetForegroundWindow();
                            break;

                        case "открыть меню Документ":
                            EnterShortcuts(VK_ALT, VK_L);
                            break;

                        case "открыть меню Прочитать с диска":
                            EnterShortcut(VK_L);
                            break;

                        case "проверка":
                            var result = MessageBox.Show("Сценарий выполнен корректно?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result != DialogResult.Yes)
                            {
                                IsStop = true;
                            }
                            break;

                        case "нажать":
                            switch (TableScript_dgv.Rows[numOfCommand].Cells[2].Value.ToString())
                            {
                                case "ENTER":
                                    EnterShortcut(VK_RETURN);
                                    break;
                                case "ESC":
                                    EnterShortcut(VK_ESCAPE);
                                    break;
                                case "SPACE":
                                    EnterShortcut(VK_SPACE);
                                    break;
                                case "F3":
                                    EnterShortcut(VK_F3);
                                    break;
                                case "F5":
                                    EnterShortcut(VK_F5);
                                    break;
                                case "стрелку влево":
                                    EnterShortcut(VK_LEFT);
                                    break;
                                case "стрелку вправо":
                                    EnterShortcut(VK_RIGHT);
                                    break;
                                case "стрелку вверх":
                                    EnterShortcut(VK_UP);
                                    break;
                                case "стрелку вниз":
                                    EnterShortcut(VK_DOWN);
                                    break;
                            }
                            break;

                        case "перейти вперед":
                            EnterShortcut(VK_TAB);
                            break;

                        case "перейти назад":
                            EnterShortcuts(VK_SHIFT, VK_TAB);
                            break;

                        case "выделить все":
                            EnterShortcuts(VK_CTRL, VK_A);
                            break;

                        case "открыть классификатор":
                            EnterShortcut(VK_F4);
                            break;

                        case "выполнить автозаполнение":
                            EnterShortcut(VK_F9);
                            break;

                        case "открыть меню Записать на диск":
                            EnterShortcut(VK_P);
                            break;

                        case "перейти к графе номер":
                            string numberField = TableScript_dgv.Rows[numOfCommand].Cells[2].Value.ToString();
                            FindField(numberField);
                            break;

                        case "подождать секунд":
                            int secondsToSleep = Int32.Parse(TableScript_dgv.Rows[numOfCommand].Cells[2].Value.ToString());
                            Thread.Sleep(1000 * secondsToSleep);
                            break;

                        case "в столбце":
                            for (int i = column; i < Int32.Parse(TableScript_dgv.Rows[numOfCommand].Cells[2].Value.ToString()); i++)
                            {
                                EnterShortcut(VK_RIGHT);
                            }
                            column = Int32.Parse(TableScript_dgv.Rows[numOfCommand].Cells[2].Value.ToString());
                            break;
                        case "в строке":
                            for (int i = row; i < Int32.Parse(TableScript_dgv.Rows[numOfCommand].Cells[2].Value.ToString()); i++)
                            {
                                EnterShortcut(VK_DOWN);
                            }
                            column = Int32.Parse(TableScript_dgv.Rows[numOfCommand].Cells[2].Value.ToString());
                            break;
                        case "найти значение":
                            EnterShortcut(VK_F4);
                            EnterShortcut(VK_F3);
                            EnterText(GetForegroundWindow(), TableScript_dgv.Rows[numOfCommand].Cells[2].Value.ToString());
                            EnterShortcut(VK_RETURN);
                            EnterShortcut(VK_ESCAPE);
                            EnterShortcut(VK_RETURN);
                            break;

                        case "ввести значение":
                            EnterText(GetForegroundWindow(), TableScript_dgv.Rows[numOfCommand].Cells[2].Value.ToString());
                            break;

                        case "ждать закрытия окна":
                            while (GetForegroundWindow() != windowFocus)
                            {
                                Thread.Sleep(5000);
                            }
                            break;

                        case "добавить товар":
                            EnterShortcuts(VK_CTRL, VK_E);
                            break;

                        case "перейти к первому товару":
                            EnterShortcuts(VK_CTRL, VK_F);
                            break;

                    }
                    if (IsStop != false)
                    {
                        break;
                    }
                    TableScript_dgv.Rows[numOfCommand].Cells[4].Value = "успешно";
                    numOfCommand++;
                }
            }
            catch (Exception ex)
            {
                TableScript_dgv.Rows[numOfCommand].Cells[4].Value = $"неудачно({ex.Message})";
            }
    }
        /// <summary>
        /// Попытка в ориентировку в ВД по объектам
        /// </summary>
        /// <param name="windowHandle"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        //private IntPtr findFirstTextBox(IntPtr windowHandle, string title)
        //{
        //    IntPtr childHandle = IntPtr.Zero;
        //    if (windowHandle != IntPtr.Zero)
        //    {
        //        if (GetControlText(windowHandle) != title)
        //            childHandle = GetWindow(windowHandle, (uint)GetWindowType.GW_CHILD);
        //        if (GetControlText(childHandle) != title)
        //            childHandle = GetWindow(childHandle, (uint)GetWindowType.GW_CHILD);
        //        if (GetControlText(childHandle) != title)
        //            childHandle = GetWindow(childHandle, (uint)GetWindowType.GW_CHILD);
        //        while (GetControlText(childHandle) != title)
        //            childHandle = GetWindow(childHandle, (uint)GetWindowType.GW_HWNDNEXT);
        //    }
        //    return childHandle;
        //}
        /// <summary>
        /// Попытка в закрытие всплывающего окна (после ввода кода товара)
        /// </summary>
        /// <param name="lpClassName"></param>
        /// <param name="windowName"></param>
        /// <returns></returns>
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    OpenDCL();
        //    IntPtr dclWindow = GetForegroundWindow();
        //    EnterShortcuts(VK_ALT, VK_L);
        //    EnterShortcut(VK_Y);
        //    EnterShortcut(VK_L);
        //    for (int i = 0; i < 6; i++)
        //    {
        //        EnterShortcut(VK_TAB);
        //    }
        //    EnterShortcut(VK_UP);
        //    EnterShortcut(VK_RETURN);
        //    Thread.Sleep(1000);
        //    IntPtr hwnd = GetForegroundWindow();
        //    IntPtr findWindow = findFirstTextBox(hwnd, "Экспорт");
        //    ////SendMessage(findWindow, BM_CLICK, 0, 0);
        //    if (!GetWindowRect(findWindow, out RECT rct))
        //    {
        //        MessageBox.Show("ERROR");
        //        return;
        //    }

        //    int xseredina = (rct.xBottomRight + rct.xUpLeft) / 2;
        //    int yseredina = (rct.yBottomRight + rct.yUpLeft) / 2;
        //    SendMessage(dclWindow, WM_MOUSEMOVE, (IntPtr)0, MakeParam(xseredina, yseredina));
        //    DoMouseLeftClick(xseredina, yseredina);
        //}
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
        public static extern void keybd_event(byte bVk, byte bScan, UInt32 dwFlags, int dwExtraInfo);

        [DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        public static extern bool SendMessage(IntPtr hWnd, uint Msg, int wParam, StringBuilder lParam);

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
        //const int EM_SETSEL = 0x00B1;
        //const int WM_CLEAR = 0x0303;
        //const uint WM_CLOSE = 0x10;
        const byte VK_TAB = 0x9;
        const byte VK_SHIFT = 0x10;
        const byte VK_ALT = 0x12;
        const byte VK_SPACE = 0x20;
        const byte VK_CTRL = 0x11;
        const byte VK_A = 0x41;
        const byte VK_L = 0x4C;
        //const byte VK_B = 0x42;
        //const byte VK_C = 0x43;
        const byte VK_E = 0x45;
        const byte VK_F = 0x46;
        const byte VK_P = 0x50;
        //const byte VK_Y = 0x59;
        const byte VK_RETURN = 0x0D;
        const byte VK_ESCAPE = 0x1B;
        const byte VK_LEFT = 0x25;
        const byte VK_UP = 0x26;
        const byte VK_RIGHT = 0x27;
        const byte VK_DOWN = 0x28;
        const byte VK_F3 = 0x72;
        const byte VK_F4 = 0x73;
        const byte VK_F5 = 0x74;
        const byte VK_F6 = 0x75;
        const byte VK_F9 = 0x78;
        public const int WM_SETTEXT = 0x000C;
        public const int BM_CLICK = 0x00F5;
        public const UInt32 KEYEVENTF_EXTENDEDKEY = 1;
        public const UInt32 KEYEVENTF_KEYUP = 2;
        internal const UInt32 MF_BYCOMMAND = 0x00000000;

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


    }
}
