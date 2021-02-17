using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DclTestFormWPy
{
    /// <summary>
    /// Часть кода (взаимодействие с формой)
    /// </summary>
    public partial class DclTestFormWPy : Form
    {
        public DclTestFormWPy()
        {
            InitializeComponent();
            TableScript_dgv.Rows.Clear();
            SpeedChoise_cmb.SelectedIndex = 1;
        }

        int WidthForm = 765;
        int HeightForm = 335;
        /// <summary>
        /// Очистка столбца Результат в таблице
        /// </summary>
        private void DeleteAll_btn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in TableScript_dgv.Rows)
            {
                row.Cells[4].Value = null;
            }
        }

        /// <summary>
        /// Открытие сценария из меню
        /// </summary>
        private void OpenScriptMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileScript.ShowDialog() == DialogResult.Cancel)
                return;

            TableScript_dgv.Rows.Clear();
            TreeViewOfScript.Nodes.Clear();
            StatusStripNameOfFile.Items.Clear();

            //fileName_lbl.Text = openFileScript.SafeFileName.ToString();
            StatusStripNameOfFile.Items.Add(openFileScript.SafeFileName.ToString());
            string strmas = File.ReadAllText(openFileScript.FileName);

            String[] commands = strmas.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < commands.Length; i++)
            {
                String[] comWithParams = commands[i].Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                int y = 1;
                int rowNumber = TableScript_dgv.Rows.Add();
                TableScript_dgv.Rows[rowNumber].Cells[0].Value = rowNumber + 1;
                foreach (string str in comWithParams)
                {
                    if (str.IndexOf('*') != -1)
                    {
                        TableScript_dgv.Rows[rowNumber].Cells[5].Value = true;
                        string strWithout = str.Remove(str.IndexOf('*'), 1);
                        TableScript_dgv.Rows[rowNumber].Cells[y].Value = strWithout;
                    }
                    else
                    {
                        TableScript_dgv.Rows[rowNumber].Cells[y].Value = str;
                    }
                    TableScript_dgv.Rows[rowNumber].Cells[y].Tag = y;
                    y++;
                    if (TableScript_dgv.Rows[rowNumber].Cells[3].Value == null)
                        TableScript_dgv.Rows[rowNumber].Cells[3].Value = Commands.CheckDescription(str);
                }
            }


            TreeNode prevCommand = TreeViewOfScript.Nodes.Add(StatusStripNameOfFile.Items[0].Text);
            int index = 0;
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
                        ////не писать команду в тривью
                        //prevCommand = prevCommand.Parent;
                        //prevCommand.Tag = index;
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

        /// <summary>
        /// Нажатие на ветку в TreeView
        /// </summary>
        private void TreeViewOfScript_MouseDown(object sender, MouseEventArgs e)
        {
            contextMenuToTreeView.Items.Clear();
            // Убедитесь, что это правая кнопка.
            if (e.Button != MouseButtons.Right) return;

            // Выберите этот узел.
            TreeNode node_here = TreeViewOfScript.GetNodeAt(e.X, e.Y);
            TreeViewOfScript.SelectedNode = node_here;

            // Если treenode в данном месте нет
            if (node_here != null)
            {
                ToolStripMenuItem delCommand = new ToolStripMenuItem("Удалить");
                contextMenuToTreeView.Items.AddRange(new[] { delCommand });
                delCommand.Click += DeleteCommand_btn_Click;

                ToolStripMenuItem editCommand = new ToolStripMenuItem("Редактировать");
                contextMenuToTreeView.Items.AddRange(new[] { editCommand });
                editCommand.Click += EditCommandToTextBox;
                return;
            }
        }

        /// <summary>
        /// Перенос команды в поле для редактирования
        /// </summary>
        void EditCommandToTextBox(object sender, EventArgs e)
        {
            EditCommand_tb.Text = TreeViewOfScript.SelectedNode.Text;
        }

        /// <summary>
        /// Открытие шаблона - группы команд и добавление их в ранее открытый сценарий
        /// </summary>
        private void OpenGroupMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileGroup.ShowDialog() == DialogResult.Cancel)
                return;

            string strmas = File.ReadAllText(openFileGroup.FileName);
            String[] commands = strmas.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            int rowNumber = TableScript_dgv.Rows.Add();
            int index = TableScript_dgv.Rows.Count; //для treeview
            TableScript_dgv.Rows[rowNumber].Cells[0].Value = rowNumber + 1;
            TableScript_dgv.Rows[rowNumber].Cells[1].Value = "группа";
            TableScript_dgv.Rows[rowNumber].Cells[1].Tag = rowNumber;
            TableScript_dgv.Rows[rowNumber].Cells[2].Value = openFileGroup.FileName.Split('.', '\\')[openFileGroup.FileName.Split('.', '\\').Length - 2];
            MessageBox.Show($"Группа команд \"{openFileGroup}\" добавлена в сценарий");
            for (int i = 0; i < commands.Length; i++)
            {
                String[] comWithParams = commands[i].Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                int y = 1;
                rowNumber = TableScript_dgv.Rows.Add();
                TableScript_dgv.Rows[rowNumber].Cells[0].Value = rowNumber + 1;
                foreach (string str in comWithParams)
                {
                    if (str.IndexOf('*') != -1)
                    {
                        TableScript_dgv.Rows[rowNumber].Cells[5].Value = true;
                        string strWithout = str.Remove(str.IndexOf('*'), 1);
                        TableScript_dgv.Rows[rowNumber].Cells[y].Value = strWithout;
                    }
                    else
                    {
                        TableScript_dgv.Rows[rowNumber].Cells[y].Value = str;
                    }
                    TableScript_dgv.Rows[rowNumber].Cells[y].Tag = y;
                    y++;
                    if (TableScript_dgv.Rows[rowNumber].Cells[3].Value == null)
                        TableScript_dgv.Rows[rowNumber].Cells[3].Value = Commands.CheckDescription(str);
                }
            }
            rowNumber = TableScript_dgv.Rows.Add();
            TableScript_dgv.Rows[rowNumber].Cells[0].Value = rowNumber + 1;
            TableScript_dgv.Rows[rowNumber].Cells[1].Value = "конец";

            TreeNode prevCommand = TreeViewOfScript.Nodes[0].Nodes.Add($"группа:{openFileGroup.SafeFileName}");
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

        /// <summary>
        /// Редактирование команды (замена содержимого команды из поля EditCommand_tb
        /// </summary>
        private void EditComand_btn_Click(object sender, EventArgs e)
        {
            if (tabScripts.SelectedIndex == 1)
            {
                TableScript_dgv.CurrentRow.Cells[1].Value = EditCommand_tb.Text;
            }
            else
            {
                TreeViewOfScript.SelectedNode.Text = EditCommand_tb.Text;
                TableScript_dgv.Rows[Convert.ToInt32(TreeViewOfScript.SelectedNode.Tag.ToString())].Cells[2].Value = EditCommand_tb.Text.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries)[1];
            }
            EditCommand_tb.Text = "";
        }

        /// <summary>
        ///Сохранение сценария через меню в текстовый файл
        /// </summary>
        private void SaveMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileScript.ShowDialog() == DialogResult.Cancel)
                return;
            TextWriter tw = new StreamWriter(saveFileScript.FileName + ".txt");
            foreach (DataGridViewRow dgvr in TableScript_dgv.Rows)
            {
                if (dgvr.Cells[1].Value != null)
                {
                    string str;
                    if (dgvr.Cells[2].Value != null)
                        str = dgvr.Cells[1].Value.ToString() + ":" + dgvr.Cells[2].Value.ToString();
                    else
                        str = dgvr.Cells[1].Value.ToString();
                    if ((Boolean)dgvr.Cells[5].EditedFormattedValue == true)
                        str += "*";
                    tw.WriteLine(str);
                }
            }
            tw.Close();
            string[] name = saveFileScript.FileName.Split('\\');
            StatusStripNameOfFile.Items[0].Text = name[name.Length - 1];
            TreeViewOfScript.Nodes[0].Text = name[name.Length - 1];
            MessageBox.Show($"Текстовый сценарий \"{name[name.Length - 1]}\" успешно сохранен!");
        }

        /// <summary>
        /// Выделение команды в таблицы и занесение в EditCommand_tb
        /// </summary>
        private void TableScript_dgv_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (TableScript_dgv.CurrentRow != null && TableScript_dgv.CurrentRow.Cells[2].Value != null)
            {
                EditCommand_tb.Text = "";
                EditCommand_tb.Text = TableScript_dgv.CurrentRow.Cells[2].Value.ToString();
            }
        }

        /// <summary>
        /// Добавление новой команды в таблицу и древовидное представление
        /// </summary>
        private void AddCommand_btn_Click(object sender, EventArgs e)
        {
            //переменные, чтобы при добавлении новых команд в выпадающий списк Command_cmb не менять в коде позиции различных команд (с и без параметра / с параметром в списке / с параметром в поле)
            int index_CommandWithParams_First = 6;
            int index_CommandWithParams_Last = 13;
            int index_CommandWithTwoParams = 22;

            //добавление в таблицу
            //не выделена строка в таблице -> добавление в конец сценария
            if (TableScript_dgv.SelectedRows.Count == 0)
            {
                if (Command_cmb.SelectedItem != null)
                {
                    //команды, где есть параметры
                    if (Command_cmb.SelectedIndex > index_CommandWithParams_First && Command_cmb.SelectedIndex < index_CommandWithParams_Last || Command_cmb.SelectedIndex == 0)
                    {
                        //параметр из текстового поля
                        if (Params_cmb.Visible == false)
                        {
                            if (Params_tb.Text != "")
                                TableScript_dgv.Rows.Add(TableScript_dgv.RowCount + 1, Command_cmb.SelectedItem.ToString(), Params_tb.Text);
                            else MessageBox.Show("Для данной команды необходимо ввести значение");
                        }
                        //параметр из выпадающего списка
                        else if (Params_cmb.SelectedIndex != -1)
                            TableScript_dgv.Rows.Add(TableScript_dgv.RowCount + 1, Command_cmb.SelectedItem.ToString(), Params_cmb.SelectedItem.ToString());
                        else MessageBox.Show("Для данной команды необходимо выбрать значение");
                    }
                    // команда "нажать в точке" с параметром Х и Y
                    else if (Command_cmb.SelectedIndex == index_CommandWithTwoParams)
                    {
                        if (Params_cmb.Visible == false)
                        {
                            if (CoordX_tb.Text != "" && CoordY_tb.Text != "")
                                TableScript_dgv.Rows.Add(TableScript_dgv.RowCount + 1, Command_cmb.SelectedItem.ToString(), CoordX_tb.Text.ToString() + ";" + CoordY_tb.Text.ToString());
                            else MessageBox.Show("Для данной команды необходимо ввести значение");
                        }
                        else MessageBox.Show("Для данной команды необходимо выбрать значения Х и Y");
                    }
                    //команда без параметра
                    else
                    {
                        TableScript_dgv.Rows.Add(TableScript_dgv.RowCount + 1, Command_cmb.SelectedItem.ToString());
                    }
                    TableScript_dgv.Rows[TableScript_dgv.RowCount - 1].Cells[3].Value = Commands.CheckDescription(TableScript_dgv.Rows[TableScript_dgv.RowCount - 1].Cells[1].Value.ToString());
                }
            }
            //выделена минимум одна строка -> добавление в середину сценария после выделенной строки
            else
            {
                if (Command_cmb.SelectedItem != null)
                {
                    //команды, где есть параметры
                    if (Command_cmb.SelectedIndex > index_CommandWithParams_First && Command_cmb.SelectedIndex < index_CommandWithParams_Last || Command_cmb.SelectedIndex == 0)
                    {
                        if (Params_cmb.Visible == false)
                        {
                            //параметр из текстового поля
                            if (Params_tb.Text != "")
                                TableScript_dgv.Rows.Insert(TableScript_dgv.SelectedCells[0].RowIndex + 1, TableScript_dgv.Rows.Count + 1, Command_cmb.SelectedItem.ToString(), Params_tb.Text);
                            else MessageBox.Show("Для данной команды необходимо ввести значение");
                        }
                        //параметр из выпадающего списка
                        else if (Params_cmb.SelectedIndex != -1)
                            TableScript_dgv.Rows.Insert(TableScript_dgv.SelectedCells[0].RowIndex + 1, TableScript_dgv.Rows.Count + 1, Command_cmb.SelectedItem.ToString(), Params_cmb.SelectedItem.ToString());
                        else MessageBox.Show("Для данной команды необходимо выбрать значение");
                    }
                    // команда "нажать в точке" с параметром Х и Y
                    else if (Command_cmb.SelectedIndex == index_CommandWithTwoParams)
                    {
                        if (CoordX_tb.Text != "" && CoordY_tb.Text != "")
                            TableScript_dgv.Rows.Insert(TableScript_dgv.SelectedCells[0].RowIndex + 1, TableScript_dgv.Rows.Count + 1, Command_cmb.SelectedItem.ToString(), CoordX_tb.Text.ToString() + ";" + CoordY_tb.Text.ToString());
                        else MessageBox.Show("Для данной команды необходимо выбрать значения Х и Y");
                    }
                    //команда без параметра
                    else
                    {
                        TableScript_dgv.Rows.Insert(TableScript_dgv.SelectedCells[0].RowIndex + 1, TableScript_dgv.Rows.Count + 1, Command_cmb.SelectedItem.ToString());
                    }
                    //сортировка id
                    int i = 1;
                    foreach (DataGridViewRow dataGridViewRow in TableScript_dgv.Rows)
                    {
                        dataGridViewRow.Cells[0].Value = i;
                        i++;
                    }
                    TableScript_dgv.Rows[TableScript_dgv.SelectedCells[0].RowIndex + 1].Cells[3].Value = Commands.CheckDescription(TableScript_dgv.Rows[TableScript_dgv.SelectedCells[0].RowIndex + 1].Cells[1].Value.ToString());
                }
            }

            TableScript_dgv.ClearSelection();

            //добавление в тривью
            if (Command_cmb.SelectedItem != null)
            {
                if (Command_cmb.SelectedIndex > index_CommandWithParams_First && Command_cmb.SelectedIndex < index_CommandWithParams_Last || Command_cmb.SelectedIndex == 0)
                {
                    if (Params_cmb.Visible == false)
                    {
                        if (Params_tb.Text != "")
                            TreeViewOfScript.Nodes[TreeViewOfScript.Nodes.Count - 1].Nodes.Add($"{Command_cmb.SelectedItem}:{Params_tb.Text}");
                        else MessageBox.Show("Для данной команды необходимо ввести значение");
                    }
                    else if (Params_cmb.SelectedIndex != -1)
                        TreeViewOfScript.Nodes[TreeViewOfScript.Nodes.Count - 1].Nodes.Add($"{Command_cmb.SelectedItem}:{Params_cmb.SelectedItem}");
                    else MessageBox.Show("Для данной команды необходимо выбрать значение");
                }
                else
                {
                    TreeViewOfScript.Nodes[TreeViewOfScript.Nodes.Count - 1].Nodes.Add($"{Command_cmb.SelectedItem}");
                }
            }
        }

        /// <summary>
        /// Изменение на текстовое поле или выпадающий список в зависимости от индекса выбранного в Command_cmb
        /// </summary>
        private void Command_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            //команда требующая параметра, написанного вручную (нажать / ввести / найти / перейти / подождать / группа)
            if (Command_cmb.SelectedIndex > 7 && Command_cmb.SelectedIndex < 13 || Command_cmb.SelectedIndex == 0)
            {
                Params_cmb.Visible = false;
                Params_tb.Visible = true;
                Params_tb.Text = "";
                x_lbl.Visible = false;
                y_lbl.Visible = false;
                CoordX_tb.Visible = false;
                CoordY_tb.Visible = false;
            }
            //команда требующая параметра, выбранного из списка (Нажать :Esc. Enter ...)
            else if (Command_cmb.SelectedIndex == 7)
            {
                Params_tb.Visible = false;
                Params_cmb.Visible = true;
                Params_cmb.SelectedIndex = -1;
                x_lbl.Visible = false;
                y_lbl.Visible = false;
                CoordX_tb.Visible = false;
                CoordY_tb.Visible = false;
            }
            //команда не требующая параметра
            else if (Command_cmb.SelectedIndex == 22)
            {
                Params_tb.Visible = false;
                Params_cmb.Visible = false;
                x_lbl.Visible = true;
                y_lbl.Visible = true;
                CoordX_tb.Visible = true;
                CoordY_tb.Visible = true;
            }
            else
            {
                Params_cmb.Visible = false;
                Params_tb.Visible = false;
                x_lbl.Visible = false;
                y_lbl.Visible = false;
                CoordX_tb.Visible = false;
                CoordY_tb.Visible = false;
            }
        }

        /// <summary>
        /// Добавление команды "конец" группы в сценарий
        /// </summary>
        private void EndGroup_btn_Click(object sender, EventArgs e)
        {
            if (TableScript_dgv.SelectedRows.Count == 0)
            {
                int rowNumber = TableScript_dgv.Rows.Add();
                TableScript_dgv.Rows[rowNumber].Cells[0].Value = rowNumber + 1;
                TableScript_dgv.Rows[rowNumber].Cells[1].Value = "конец";
                EndGroup_btn.Visible = false;
            }
            else
            {
                TableScript_dgv.Rows.Insert(TableScript_dgv.SelectedCells[0].RowIndex + 1, TableScript_dgv.Rows.Count + 1, "конец");
                EndGroup_btn.Visible = false;
            }
        }

        /// <summary>
        /// Удаление команды из сценария
        /// </summary>
        private void DeleteCommand_btn_Click(object sender, EventArgs e)
        {
            if (tabScripts.SelectedIndex == 0)
            {
                TreeViewOfScript.SelectedNode.Remove();
                foreach (DataGridViewRow row in TableScript_dgv.Rows)
                {
                    if (Convert.ToInt32(row.Cells[0].Value.ToString()) == Convert.ToInt32(TreeViewOfScript.SelectedNode.Tag.ToString()))
                        TableScript_dgv.Rows.RemoveAt(row.Index - 1);
                }
            }
            else
            {
                try
                {
                    //нужны классы для удобного поиска каждой команды????????????
                    int rowIndexSelected = TableScript_dgv.SelectedCells[0].RowIndex;
                    TableScript_dgv.Rows.RemoveAt(rowIndexSelected);
                    TreeViewOfScript.Nodes[0].Nodes[rowIndexSelected].Remove();
                    //не работает в группах
                }
                catch { }

            }
        }

        /// <summary>
        /// Пролистывание команды на одну вперед
        /// </summary>
        private void OneStepForward_btn_Click(object sender, EventArgs e)
        {
            int numOfCommand = TableScript_dgv.SelectedRows[0].Index;
            TableScript_dgv.ClearSelection();
            if (numOfCommand + 1 < TableScript_dgv.Rows.Count)
                TableScript_dgv.Rows[numOfCommand + 1].Selected = true;
            TableScript_dgv.FirstDisplayedScrollingRowIndex = numOfCommand;
            TableScript_dgv.Update();
        }

        /// <summary>
        /// Пролистывание команды на одну назад
        /// </summary>
        private void OneStepBackward_btn_Click(object sender, EventArgs e)
        {
            int numOfCommand = TableScript_dgv.SelectedRows[0].Index;
            TableScript_dgv.ClearSelection();
            if (numOfCommand - 1 >= 0)
            {
                TableScript_dgv.Rows[numOfCommand - 1].Selected = true;
                TableScript_dgv.FirstDisplayedScrollingRowIndex = numOfCommand - 1;
            }
            TableScript_dgv.Update();
        }

        /// <summary>
        ///Выполнение сценария с начала без точек останова
        ///ТРЕБУЕТ ОПТИМИЗАЦИИ
        /// </summary>
        private void FromTheBeginning_btn_Click(object sender, EventArgs e)
        {
            //выполнение не смотря на точки останова с начала
            StartScript_btn.Text = "| |";
            int column = 1, row = 1;
            bool IsStop = false;
            OpenDCL();
            IntPtr windowFocus = GetForegroundWindow();
            for (int numOfCommand = 0; numOfCommand < TableScript_dgv.Rows.Count; numOfCommand++)
            {
                string command = TableScript_dgv.Rows[numOfCommand].Cells[1].Value.ToString();
                IsStop = DoCommand(command, ref numOfCommand, ref column, ref row, windowFocus);
                if (IsStop != false)
                {
                    break;
                }
                WaitSometime();
            }
            StartScript_btn.Text = "▶";
        }

        /// <summary>
        /// Выполнение сценария до ближайшей точки останова
        ///ТРЕБУЕТ ОПТИМИЗАЦИИ
        /// </summary>
        private void StartScript_btn_Click(object sender, EventArgs e)
        {
            StartScript_btn.Text = "| |";
            tabScripts.SelectedIndex = 1;
            StartScript_btn.Refresh();
            int column = 1, row = 1;
            bool IsStop = false;
            int numOfCommand = TableScript_dgv.SelectedRows[0].Index;
            OpenDCL();
            IntPtr windowFocus = GetForegroundWindow();
            while (numOfCommand < TableScript_dgv.Rows.Count)
            {
                //прерывание, если команда в точке останова
                if ((Boolean)TableScript_dgv.Rows[numOfCommand].Cells[5].EditedFormattedValue == true)
                { break; }
                string command = TableScript_dgv.Rows[numOfCommand].Cells[1].Value.ToString();
                IsStop = DoCommand(command, ref numOfCommand, ref column, ref row, windowFocus);
                if (IsStop != false)
                {
                    break;
                }
                numOfCommand++;
                WaitSometime();
            }
            StartScript_btn.Text = "▶";
        }

        /// <summary>
        /// Выполнение сценария из выделенных пользователем команд
        ///ТРЕБУЕТ ОПТИМИЗАЦИИ
        /// </summary>
        private void DoSelectStartScript_btn_Click(object sender, EventArgs e)
        {
            StartScript_btn.Text = "| |";
            StartScript_btn.Refresh();
            int column = 1, row = 1;
            bool IsStop = false;
            int numOfCommand = TableScript_dgv.SelectedRows[TableScript_dgv.SelectedRows.Count - 1].Index;
            int CountCommand = TableScript_dgv.SelectedRows.Count;
            OpenDCL();
            IntPtr windowFocus = GetForegroundWindow();
            for (int index = 0; index < CountCommand; index++)
            {
                string command = TableScript_dgv.Rows[numOfCommand].Cells[1].Value.ToString();
                IsStop = DoCommand(command, ref numOfCommand, ref column, ref row, windowFocus);
                if (IsStop != false)
                {
                    break;
                }
                numOfCommand++;
                WaitSometime();
            }
            StartScript_btn.Text = "▶";
        }
        private void WaitSometime()
        {
            switch (SpeedChoise_cmb.SelectedIndex.ToString())
            {
                case "0":
                    {
                        Thread.Sleep(2000);
                        break;
                    }
                case "1":
                    {
                        Thread.Sleep(1000);
                        break;
                    }
                case "2":
                    {
                        Thread.Sleep(500);
                        break;
                    }
                default:
                    {
                        Thread.Sleep(1000);
                        break;
                    }

            }
        }
        /// <summary>
        /// Нажатие ПКМ по кнопке старта сценария
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartScript_btn_MouseDown(object sender, MouseEventArgs e)
        {
            contextMenuToStart.Items.Clear();
            // Убедитесь, что это правая кнопка.
            if (e.Button != MouseButtons.Right) return;

            ToolStripMenuItem doAll = new ToolStripMenuItem("Выполнить полностью");
            ToolStripMenuItem doToBreakpoint = new ToolStripMenuItem("Выполнить до точки останова");
            ToolStripMenuItem doSelect = new ToolStripMenuItem("Выполнить выделенное");
            contextMenuToStart.Items.AddRange(new[] { doAll, doToBreakpoint, doSelect });
            doAll.Click += FromTheBeginning_btn_Click;
            doToBreakpoint.Click += StartScript_btn_Click;
            doSelect.Click += DoSelectStartScript_btn_Click;

            tabScripts.SelectedIndex = 1;
            return;
        }

        private void редактированиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            add_gb.Visible = true;
            del_gb.Visible = true;
            edit_gb.Visible = true;
            search_gb.Visible = false;
            panel1.Size = new System.Drawing.Size(panel1.Width, panel1.Height);
            panel2.Location = new System.Drawing.Point(panel1.Width + 5, 43);
            ClientSize = new System.Drawing.Size(panel1.Width + 250, HeightForm);
            //EditingSearchForm formEdit = new EditingSearchForm();
            //formEdit.Show();
        }

        private void скрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            add_gb.Visible = false;
            del_gb.Visible = false;
            edit_gb.Visible = false;
            search_gb.Visible = false;
            ClientSize = new System.Drawing.Size(WidthForm, HeightForm);
        }

        private void поискToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            add_gb.Visible = false;
            del_gb.Visible = false;
            edit_gb.Visible = false;
            search_gb.Visible = true;
            ClientSize = new System.Drawing.Size(WidthForm + 250, HeightForm);
        }

        

        private void ClearSearch_btn_Click(object sender, EventArgs e)
        {
            TableScript_dgv.ClearSelection();
            ClearSearch_btn.Visible = false;
        }

        private void Search_btn_Click(object sender, EventArgs e)
        {

        }
    }
}