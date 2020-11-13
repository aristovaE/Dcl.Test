using Ionic.BZip2;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DclTestFormWPy
{
    public partial class DclTestFormWPy : Form
    {
        public DclTestFormWPy()
        {
            InitializeComponent();
        }

        /// <summary>
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
        private void FindField(string numberOfField)
        {
            IntPtr windowDCL = WindowFromPoint(System.Windows.Forms.Cursor.Position = new Point(47, 30)); //Меню - Документ
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
            uint ThreadID1 = GetWindowThreadProcessId(FindWindow(null, "DclTest"), out uint id);
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

        private void chooseScript_btn_Click(object sender, EventArgs e)
        {
            if (openFileScript.ShowDialog() == DialogResult.Cancel)
                return;
            string strmas = File.ReadAllText(openFileScript.FileName);
            String[] commands = strmas.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            //String[] words = strmas.Split(new char[] { '\r', '\n', ':' }, StringSplitOptions.RemoveEmptyEntries);

            ScriptEngine engine = Python.CreateEngine();
            ScriptScope scope = engine.CreateScope();
            //engine.ExecuteFile(@"\\Vboxsvr\temp\python\second.py", scope);
            engine.SetSearchPaths(new[] { @"C:\Users\User\AppData\Local\Programs\Python\Python39\Lib" });
            engine.ExecuteFile(@"D:\VirtualBox VMs\TEMP\python\ff.py", scope);
            //List<string> listCommandsFromPy = (List<string>)scope.GetVariable("listOfCommand");
            //ScriptSource source = engine.CreateScriptSourceFromFile(@"D:\VirtualBox VMs\TEMP\python\ff.py");
            //ObjectOperations op = engine.Operations;
            IList<object> objs = scope.GetVariable("listOfCommand");
            List<string> strs = new List<string>();
            foreach (var obj in objs)
            {
                strs.Add((string)obj);
            }
            List<string> strs2 = new List<string>();
            List<string> strs3 = new List<string>();
            foreach (string str in strs)
            {
                byte[] bytes = Encoding.Default.GetBytes(str);
                strs2.Add(Encoding.Default.GetString(bytes));
                byte[] bytes2 = Encoding.UTF8.GetBytes(str);
                strs3.Add(Encoding.UTF8.GetString(bytes));
            }
            List<string> listCommandsFromPy = (List<string>)scope.GetVariable("listOfCommand"); //БЕДА С КОДИРОВКОЙ
            //source.Execute(scope); // class object created
            //object method = op.GetMember(instance, "func"); // get a method
            //List<string> result = ((IList<object>)op.Invoke(method)).Cast<string>().ToList(); // call the method and get result



            listOfCommand.Items.Clear();
            foreach (string command in commands)
            {
                listOfCommand.Items.Add(command);
            }

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

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr handle, UInt32 message, IntPtr w, IntPtr l);

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
        const int EM_SETSEL = 0x00B1;
        const int WM_CLEAR = 0x0303;
        static uint WM_CLOSE = 0x10;
        const byte VK_TAB = 0x9;
        const byte VK_SHIFT = 0x10;
        const byte VK_ALT = 0x12;
        const byte VK_SPACE = 0x20;
        const byte VK_CTRL = 0x11;
        const byte VK_A = 0x41;
        const byte VK_L = 0x4C;
        const byte VK_B = 0x42;
        const byte VK_C = 0x43;
        const byte VK_D = 0x44;
        const byte VK_P = 0x50;
        const byte VK_Y = 0x59;
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
        public const UInt32 KEYEVENTF_EXTENDEDKEY = 1;
        public const UInt32 KEYEVENTF_KEYUP = 2;
        internal const UInt32 MF_BYCOMMAND = 0x00000000;

        #endregion

        //Thread TMyfunc = new Thread(delegate ()
        //{
        //    DoCommand();
        //});
        //TMyfunc.Start();


        private void startScript_btn_Click(object sender, EventArgs e)
        {
            int numOfCommand = 0;
            int column = 1, row = 1;
            IntPtr windowFocus = IntPtr.Zero;
            String[] commandWParam = null;
            List<string> commands = new List<string>();
            //List<string> commands = listOfCommand.Items.Cast<ListViewItem>().Select(item => item.Text).ToList();
            for (int i = 0; i < tableScript_dgv.Rows.Count - 1; i++)
            {
                commands.Add(tableScript_dgv.Rows[i].Cells[1].Value.ToString());
            }
            //new Thread(() =>
            //{
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

                        case "нажать":
                            switch (tableScript_dgv.Rows[numOfCommand].Cells[2].Value.ToString())
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
                            string numberField = tableScript_dgv.Rows[numOfCommand].Cells[2].Value.ToString();
                            FindField(numberField);
                            break;

                        case "подождать секунд":
                            int secondsToSleep = Int32.Parse(tableScript_dgv.Rows[numOfCommand].Cells[2].Value.ToString());
                            Thread.Sleep(1000 * secondsToSleep);
                            break;

                        case "в столбце":
                            for (int i = column; i < Int32.Parse(tableScript_dgv.Rows[numOfCommand].Cells[2].Value.ToString()); i++)
                            {
                                EnterShortcut(VK_RIGHT);
                            }
                            //EnterShortcut(VK_F4);
                            //EnterShortcut(VK_F3);
                            column = Int32.Parse(tableScript_dgv.Rows[numOfCommand].Cells[2].Value.ToString());
                            break;
                        case "в строке":
                            for (int i = row; i < Int32.Parse(tableScript_dgv.Rows[numOfCommand].Cells[2].Value.ToString()); i++)
                            {
                                EnterShortcut(VK_DOWN);
                            }
                            //EnterShortcut(VK_F4);
                            //EnterShortcut(VK_F3);
                            column = Int32.Parse(tableScript_dgv.Rows[numOfCommand].Cells[2].Value.ToString());
                            break;
                        case "найти значение":
                            EnterShortcut(VK_F4);
                            EnterShortcut(VK_F3);
                            EnterText(GetForegroundWindow(), tableScript_dgv.Rows[numOfCommand].Cells[2].Value.ToString());
                            break;

                        case "ввести значение":
                            EnterText(GetForegroundWindow(), tableScript_dgv.Rows[numOfCommand].Cells[2].Value.ToString());
                            break;

                        case "ждать закрытия окна":
                            while (GetForegroundWindow() != windowFocus)
                            {
                                Thread.Sleep(5000);
                            }
                            break;

                    }
                    tableScript_dgv.Rows[numOfCommand].Cells[4].Value = "успешно";
                    numOfCommand++;
                }
            }
            catch (Exception ex)
            {
                tableScript_dgv.Rows[numOfCommand].Cells[4].Value = "неудачно";
            }
            //}));
            //};

            //if (InvokeRequired)
            //    Invoke(actOfScript);
            //else
            //    actOfScript();
            //})
            ////{
            ////    IsBackground = true,
            ////}
            //}) .Start();
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
        private void CloseWindow(IntPtr newWindow)
        {
            //Size resolution = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size;
            //SendMessage(newWindow, WM_MOUSEMOVE, (IntPtr)0, MakeParam(resolution.Width - 30, 20));
            //DoMouseLeftClick(resolution.Width - 30, 20);
            Size resolution = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size;
            Point p = new Point();
            p.X = Convert.ToInt16(resolution.Width - 25);  //координаты из inspect exe
            p.Y = Convert.ToInt16(20);  //поле How found : Mouse Move(47,30) при наведении мышкой на нужное поле
            SetCursorPos(p.X, p.Y);
            DoMouseLeftClick(p.X, p.Y);
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

        private void listOfCommand_MouseClick(object sender, MouseEventArgs e)
        {
            editCommand_tb.Text = "";
            editCommand_tb.Text = listOfCommand.SelectedItems[0].Text;
        }

        private void editComand_btn_Click(object sender, EventArgs e)
        {
            //listOfCommand.SelectedItems[0].Text = editCommand_tb.Text;
            tableScript_dgv.CurrentRow.Cells[1].Value = editCommand_tb.Text;
            editCommand_tb.Text = "";
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileScript.ShowDialog() == DialogResult.Cancel)
                return;
            tableScript_dgv.Rows.Clear();

            fileName_lbl.Text = openFileScript.SafeFileName.ToString();
            string strmas = File.ReadAllText(openFileScript.FileName);
            String[] commands = strmas.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            listOfCommand.Items.Clear();
            foreach (string command in commands)
            {
                listOfCommand.Items.Add(command);
            }
            for (int i = 0; i < commands.Length; i++)
            {
                String[] comWithParams = commands[i].Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                int y = 1;
                int rowNumber = tableScript_dgv.Rows.Add();
                tableScript_dgv.Rows[rowNumber].Cells[0].Value = rowNumber + 1;
                foreach (string str in comWithParams)
                {
                    tableScript_dgv.Rows[rowNumber].Cells[y].Value = str;
                    y++;
                }
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileScript.ShowDialog() == DialogResult.Cancel)
                return;
            TextWriter tw = new StreamWriter(saveFileScript.FileName + ".txt");
            foreach (DataGridViewRow dgvr in tableScript_dgv.Rows)
            {
                if (dgvr.Cells[1].Value != null)
                {
                    string str = "";
                    if (dgvr.Cells[2].Value != null)
                        str = dgvr.Cells[1].Value.ToString() + ":" + dgvr.Cells[2].Value.ToString();
                    else
                        str = dgvr.Cells[1].Value.ToString();
                    tw.WriteLine(str);
                }
            }
            tw.Close();

            MessageBox.Show("Текстовый сценарий" + saveFileScript.FileName + " успешно сохранен!");
        }

        private void tableScript_dgv_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            editCommand_tb.Text = "";
            editCommand_tb.Text = tableScript_dgv.CurrentRow.Cells[1].Value.ToString();
        }

        private void addCommand_btn_Click(object sender, EventArgs e)
        {
            if (command_cmb.SelectedItem != null)
            {
                if (command_cmb.SelectedIndex == 0)
                {
                    int rowNumber = tableScript_dgv.Rows.Add();
                    tableScript_dgv.Rows[rowNumber].Cells[0].Value = rowNumber + 1;
                    tableScript_dgv.Rows[rowNumber].Cells[2].Value = params_tb.Text;
                }
                else if (command_cmb.SelectedIndex == 5 || command_cmb.SelectedIndex == 6 || command_cmb.SelectedIndex == 7 || command_cmb.SelectedIndex == 8)
                {
                    int rowNumber = tableScript_dgv.Rows.Add();
                    tableScript_dgv.Rows[rowNumber].Cells[0].Value = rowNumber + 1;
                    tableScript_dgv.Rows[rowNumber].Cells[1].Value = command_cmb.SelectedItem.ToString();
                    if (params_cmb.Visible == false)
                    {
                        if (params_tb.Text != "")
                            tableScript_dgv.Rows[rowNumber].Cells[2].Value = params_tb.Text;
                        else MessageBox.Show("Для данной команды необходимо выбрать значение");
                    }
                    else if (params_cmb.SelectedIndex != -1)
                        tableScript_dgv.Rows[rowNumber].Cells[2].Value = params_cmb.SelectedItem.ToString();
                    else MessageBox.Show("Для данной команды необходимо выбрать значение");
                }
                else
                {
                    int rowNumber = tableScript_dgv.Rows.Add();
                    tableScript_dgv.Rows[rowNumber].Cells[0].Value = rowNumber + 1;
                    tableScript_dgv.Rows[rowNumber].Cells[1].Value = command_cmb.SelectedItem.ToString();
                }
                //params_tb.Text = "";
                //params_cmb.SelectedIndex = -1;
                //command_cmb.SelectedIndex = -1;
            }
        }

        private void command_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (command_cmb.SelectedIndex == 5)
            {
                params_tb.Visible = false;
                params_cmb.Visible = true;
                params_cmb.SelectedIndex = -1;
            }
            else if (command_cmb.SelectedIndex == 6 || command_cmb.SelectedIndex == 7 || command_cmb.SelectedIndex == 8)
            {
                params_cmb.Visible = false;
                params_tb.Visible = true;
                params_tb.Text = "";
            }
            else if (command_cmb.SelectedIndex == 0)
            {
                params_cmb.Visible = false;
                params_tb.Visible = true;
            }
            else
            {
                params_cmb.Visible = false;
                params_tb.Visible = false;
            }
        }

        private void delCommand_btn_Click(object sender, EventArgs e)
        {
            int rowIndexSelected = tableScript_dgv.SelectedCells[0].RowIndex;
            tableScript_dgv.Rows.RemoveAt(rowIndexSelected);
        }
    }
}
