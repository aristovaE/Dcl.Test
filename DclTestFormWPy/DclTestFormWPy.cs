using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace DclTestFormWPy
{
    public partial class DclTestFormWPy : Form
    {
        public DclTestFormWPy()
        {
            InitializeComponent();
            tableScript_dgv.Rows.Clear();
        }

        /// <summary>
        /// Попытка в работу с Питоном
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chooseScript_btn_Click(object sender, EventArgs e)
        {
            //if (openFileScript.ShowDialog() == DialogResult.Cancel)
            //    return;
            //string strmas = File.ReadAllText(openFileScript.FileName);
            //String[] commands = strmas.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            ////String[] words = strmas.Split(new char[] { '\r', '\n', ':' }, StringSplitOptions.RemoveEmptyEntries);

            //ScriptEngine engine = Python.CreateEngine();
            //ScriptScope scope = engine.CreateScope();
            ////engine.ExecuteFile(@"\\Vboxsvr\temp\python\second.py", scope);
            //engine.SetSearchPaths(new[] { @"C:\Users\User\AppData\Local\Programs\Python\Python39\Lib" });
            //engine.ExecuteFile(@"D:\VirtualBox VMs\TEMP\python\ff.py", scope);
            ////List<string> listCommandsFromPy = (List<string>)scope.GetVariable("listOfCommand");
            ////ScriptSource source = engine.CreateScriptSourceFromFile(@"D:\VirtualBox VMs\TEMP\python\ff.py");
            ////ObjectOperations op = engine.Operations;
            //IList<object> objs = scope.GetVariable("listOfCommand");
            //List<string> strs = new List<string>();
            //foreach (var obj in objs)
            //{
            //    strs.Add((string)obj);
            //}
            //List<string> strs2 = new List<string>();
            //List<string> strs3 = new List<string>();
            //foreach (string str in strs)
            //{
            //    byte[] bytes = Encoding.Default.GetBytes(str);
            //    strs2.Add(Encoding.Default.GetString(bytes));
            //    byte[] bytes2 = Encoding.UTF8.GetBytes(str);
            //    strs3.Add(Encoding.UTF8.GetString(bytes));
            //}
            //List<string> listCommandsFromPy = (List<string>)scope.GetVariable("listOfCommand"); //БЕДА С КОДИРОВКОЙ
            ////source.Execute(scope); // class object created
            ////object method = op.GetMember(instance, "func"); // get a method
            ////List<string> result = ((IList<object>)op.Invoke(method)).Cast<string>().ToList(); // call the method and get result



            //listOfCommand.Items.Clear();
            //foreach (string command in commands)
            //{
            //    listOfCommand.Items.Add(command);
            //}
        }
        private void startScript_btn_Click(object sender, EventArgs e)
        {
            int numOfCommand = 0;
            int column = 1, row = 1;
            IntPtr windowFocus = IntPtr.Zero;
            List<string> commands = new List<string>();
            //List<string> commands = listOfCommand.Items.Cast<ListViewItem>().Select(item => item.Text).ToList();
            for (int i = 0; i < tableScript_dgv.Rows.Count; i++)
            {
                commands.Add(tableScript_dgv.Rows[i].Cells[1].Value.ToString());
            }
            //new Thread(() =>
            //{
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
                            column = Int32.Parse(tableScript_dgv.Rows[numOfCommand].Cells[2].Value.ToString());
                            break;
                        case "в строке":
                            for (int i = row; i < Int32.Parse(tableScript_dgv.Rows[numOfCommand].Cells[2].Value.ToString()); i++)
                            {
                                EnterShortcut(VK_DOWN);
                            }
                            column = Int32.Parse(tableScript_dgv.Rows[numOfCommand].Cells[2].Value.ToString());
                            break;
                        case "найти значение":
                            EnterShortcut(VK_F4);
                            EnterShortcut(VK_F3);
                            EnterText(GetForegroundWindow(), tableScript_dgv.Rows[numOfCommand].Cells[2].Value.ToString());
                            EnterShortcut(VK_RETURN);
                            EnterShortcut(VK_ESCAPE);
                            EnterShortcut(VK_RETURN);
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
                    tableScript_dgv.Rows[numOfCommand].Cells[4].Value = "успешно";
                    numOfCommand++;
                }
            }
            catch (Exception ex)
            {
                tableScript_dgv.Rows[numOfCommand].Cells[4].Value = $"неудачно({ex.Message})";
            }
            finally
            {

            }
        }


        private void listOfCommand_MouseClick(object sender, MouseEventArgs e)
        {
            editCommand_tb.Text = "";
            editCommand_tb.Text = listOfCommand.SelectedItems[0].Text;
        }

        private void editComand_btn_Click(object sender, EventArgs e)
        {
            tableScript_dgv.CurrentRow.Cells[1].Value = editCommand_tb.Text;
            editCommand_tb.Text = "";
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
                    string str;
                    if (dgvr.Cells[2].Value != null)
                        str = dgvr.Cells[1].Value.ToString() + ":" + dgvr.Cells[2].Value.ToString();
                    else
                        str = dgvr.Cells[1].Value.ToString();
                    tw.WriteLine(str);
                }
            }
            tw.Close();

            MessageBox.Show("Текстовый сценарий " + saveFileScript.FileName + " успешно сохранен!");
        }

        private void tableScript_dgv_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (tableScript_dgv.CurrentRow != null && tableScript_dgv.CurrentRow.Cells[2].Value != null)
            {
                editCommand_tb.Text = "";
                editCommand_tb.Text = tableScript_dgv.CurrentRow.Cells[2].Value.ToString();
            }
        }

        private void addCommand_btn_Click(object sender, EventArgs e)
        {
            if (tableScript_dgv.SelectedRows.Count == 0)
            {
                if (command_cmb.SelectedItem != null)
                {
                    if (command_cmb.SelectedIndex == 0)
                    {
                        tableScript_dgv.Rows.Add(tableScript_dgv.RowCount + 1, "", params_tb.Text);
                    }
                    else if (command_cmb.SelectedIndex == 5 || command_cmb.SelectedIndex == 6 || command_cmb.SelectedIndex == 7 || command_cmb.SelectedIndex == 8 || command_cmb.SelectedIndex == 9)
                    {
                        if (params_cmb.Visible == false)
                        {
                            if (params_tb.Text != "")
                                tableScript_dgv.Rows.Add(tableScript_dgv.RowCount + 1, command_cmb.SelectedItem.ToString(), params_tb.Text);
                            else MessageBox.Show("Для данной команды необходимо ввести значение");
                        }
                        else if (params_cmb.SelectedIndex != -1)
                            tableScript_dgv.Rows.Add(tableScript_dgv.RowCount + 1, command_cmb.SelectedItem.ToString(), params_cmb.SelectedItem.ToString());
                        else MessageBox.Show("Для данной команды необходимо выбрать значение");
                    }
                    else
                    {
                        tableScript_dgv.Rows.Add(tableScript_dgv.RowCount + 1, command_cmb.SelectedItem.ToString());
                    }
                }
            }
            else
            {
                if (command_cmb.SelectedItem != null)
                {
                    if (command_cmb.SelectedIndex == 0)
                    {
                        tableScript_dgv.Rows.Insert(tableScript_dgv.SelectedCells[0].RowIndex + 1, tableScript_dgv.Rows.Count + 1, "", params_tb.Text);
                    }
                    else if (command_cmb.SelectedIndex == 5 || command_cmb.SelectedIndex == 6 || command_cmb.SelectedIndex == 7 || command_cmb.SelectedIndex == 8 || command_cmb.SelectedIndex == 9)
                    {
                        if (params_cmb.Visible == false)
                        {
                            if (params_tb.Text != "")
                                tableScript_dgv.Rows.Insert(tableScript_dgv.SelectedCells[0].RowIndex + 1, tableScript_dgv.Rows.Count + 1, command_cmb.SelectedItem.ToString(), params_tb.Text);
                            else MessageBox.Show("Для данной команды необходимо ввести значение");
                        }
                        else if (params_cmb.SelectedIndex != -1)
                            tableScript_dgv.Rows.Insert(tableScript_dgv.SelectedCells[0].RowIndex + 1, tableScript_dgv.Rows.Count + 1, command_cmb.SelectedItem.ToString(), params_cmb.SelectedItem.ToString());
                        else MessageBox.Show("Для данной команды необходимо выбрать значение");
                    }
                    else
                    {
                        tableScript_dgv.Rows.Insert(tableScript_dgv.SelectedCells[0].RowIndex + 1, tableScript_dgv.Rows.Count + 1, command_cmb.SelectedItem.ToString());
                    }
                    int i = 1;
                    foreach (DataGridViewRow dataGridViewRow in tableScript_dgv.Rows)
                    {
                        dataGridViewRow.Cells[0].Value = i;
                        i++;
                    }
                }
            }
            tableScript_dgv.ClearSelection();
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
                params_tb.Text = "";
            }
            else if (command_cmb.SelectedIndex == 9)
            {
                params_cmb.Visible = false;
                params_tb.Visible = true;
                params_tb.Text = "";
                endGroup_btn.Visible = true;
            }
            else
            {
                params_cmb.Visible = false;
                params_tb.Visible = false;
            }
        }

        private void delCommand_btn_Click(object sender, EventArgs e)
        {
            if (tabScripts.SelectedIndex == 0)
            {
                treeViewOfScript.SelectedNode.Remove();
                foreach (DataGridViewRow row in tableScript_dgv.Rows)
                {
                    if(Convert.ToInt32(row.Cells[0].Value.ToString()) ==Convert.ToInt32(treeViewOfScript.SelectedNode.Tag.ToString()))
                     tableScript_dgv.Rows.RemoveAt(row.Index-1);
                }
            }
            else
            {
                //нужны классы для удобного поиска каждой команды????????????
                int rowIndexSelected = tableScript_dgv.SelectedCells[0].RowIndex;
                tableScript_dgv.Rows.RemoveAt(rowIndexSelected);
                    treeViewOfScript.Nodes[0].Nodes[rowIndexSelected].Remove();
            }
        }

        private void endGroup_btn_Click(object sender, EventArgs e)
        {
            int rowNumber = tableScript_dgv.Rows.Add();
            tableScript_dgv.Rows[rowNumber].Cells[0].Value = rowNumber + 1;
            tableScript_dgv.Rows[rowNumber].Cells[1].Value = "конец:";
            endGroup_btn.Visible = false;
        }

        private void refresh_btn_Click(object sender, EventArgs e)
        {
            tableScript_dgv.Rows.Clear();
            listOfCommand.Items.Clear();
            treeViewOfScript.Nodes.Clear();

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

            TreeNode newTR = treeViewOfScript.Nodes.Add(fileName_lbl.Text);
            TreeNode nameOfGroup = null;
            int index = 0;
            bool IsInGroup = false;

            int indexOfCommand = 0;
            foreach (string command in commands)
            {
                if (command.Contains("группа:"))
                {
                    nameOfGroup = newTR.Nodes.Add(command);
                    indexOfCommand += 1;
                    IsInGroup = true;
                }
                else if (index != 0)
                {
                    if (commands[index - 1].Contains("конец"))
                    {
                        nameOfGroup = newTR.Nodes.Add(command);
                        //indexOfCommand += 1;
                    }
                    else if (command.Contains("конец"))
                    {
                        //не писать команду в тривью
                        IsInGroup = false;
                    }

                    else if (!IsInGroup)
                    {
                        TreeNode commandsOfScript = newTR.Nodes.Add(command);
                    }
                    else
                    {
                        TreeNode commandsOfGroups = nameOfGroup.Nodes.Add(command);
                    }
                }
                index += 1;
            }
        }

        private void сценарийToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (openFileScript.ShowDialog() == DialogResult.Cancel)
                return;

            tableScript_dgv.Rows.Clear();
            listOfCommand.Items.Clear();
            treeViewOfScript.Nodes.Clear();

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

            TreeNode prevCommand = treeViewOfScript.Nodes.Add(fileName_lbl.Text);
            int index = 1;
            foreach (string command in commands)
            {
                if (command.Contains("группа:"))
                {
                    prevCommand = prevCommand.Nodes.Add(command);
                    prevCommand.Tag = index;
                }
                else
                {
                    if (command.Contains("конец"))
                    {
                        //не писать команду в тривью
                        prevCommand = prevCommand.Parent;
                        prevCommand.Tag = index;
                    }
                    else
                    {
                        TreeNode nextNextCommand = prevCommand.Nodes.Add(command);
                        nextNextCommand.Tag = index;
                    }
                }
                index++;
            }
        }

        private void группуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileGroup.ShowDialog() == DialogResult.Cancel)
                return;

            string strmas = File.ReadAllText(openFileGroup.FileName);
            String[] commands = strmas.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            int rowNumber = tableScript_dgv.Rows.Add();
            tableScript_dgv.Rows[rowNumber].Cells[0].Value = rowNumber + 1;
            tableScript_dgv.Rows[rowNumber].Cells[1].Value = "группа";
            tableScript_dgv.Rows[rowNumber].Cells[2].Value = openFileGroup.FileName.Split('.', '\\')[openFileGroup.FileName.Split('.', '\\').Length - 2];
            MessageBox.Show($"Группа команд \"{openFileGroup}\" добавлена в сценарий");
            for (int i = 0; i < commands.Length; i++)
            {
                String[] comWithParams = commands[i].Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                int y = 1;
                rowNumber = tableScript_dgv.Rows.Add();
                tableScript_dgv.Rows[rowNumber].Cells[0].Value = rowNumber + 1;
                foreach (string str in comWithParams)
                {
                    tableScript_dgv.Rows[rowNumber].Cells[y].Value = str;
                    y++;
                }
            }
            rowNumber = tableScript_dgv.Rows.Add();
            tableScript_dgv.Rows[rowNumber].Cells[0].Value = rowNumber + 1;
            tableScript_dgv.Rows[rowNumber].Cells[1].Value = "конец";
        }

        private void DeleteAll_btn_Click(object sender, EventArgs e)
        {
            tableScript_dgv.Rows.Clear();
            treeViewOfScript.Nodes.Clear();
        }

        private void treeViewOfScript_MouseDown(object sender, MouseEventArgs e)
        {
            contextMenuToTreeView.Items.Clear();
            // Убедитесь, что это правая кнопка.
            if (e.Button != MouseButtons.Right) return;

            // Выберите этот узел.
            TreeNode node_here = treeViewOfScript.GetNodeAt(e.X, e.Y);
            treeViewOfScript.SelectedNode = node_here;

            // Если treenode в данном месте нет
            if (node_here != null)
            {
                ToolStripMenuItem delCommand = new ToolStripMenuItem("Удалить");
                contextMenuToTreeView.Items.AddRange(new[] { delCommand });
                delCommand.Click += delCommand_btn_Click;
                return;
            }
        }
    }
}