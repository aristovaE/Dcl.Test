using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace DclTestFormWPy
{
    public partial class DclTestFormWPy : Form
    {
        public DclTestFormWPy()
        {
            InitializeComponent();
            TableScript_dgv.Rows.Clear();
        }

        private void DeleteAll_btn_Click(object sender, EventArgs e)
        {
            TableScript_dgv.Rows.Clear();
            TreeViewOfScript.Nodes.Clear();
            StatusStripNameOfFile.Items.Clear();
            StatusStripNameOfFile.Items.Add("новый сценарий");
            TreeViewOfScript.Nodes.Add("новый сценарий");
        }

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
                    TableScript_dgv.Rows[rowNumber].Cells[y].Value = str;
                    TableScript_dgv.Rows[rowNumber].Cells[y].Tag = y;
                    y++;
                }
            }

            TreeNode prevCommand = TreeViewOfScript.Nodes.Add(StatusStripNameOfFile.Items[0].Text);
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
                editCommand.Click += editCommand_tv;
                return;
            }
        }
        void editCommand_tv(object sender, EventArgs e)
        {
            EditCommand_tb.Text = TreeViewOfScript.SelectedNode.Text;
        }
        private void OpenGroupMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileGroup.ShowDialog() == DialogResult.Cancel)
                return;

            string strmas = File.ReadAllText(openFileGroup.FileName);
            String[] commands = strmas.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            int rowNumber = TableScript_dgv.Rows.Add();
            TableScript_dgv.Rows[rowNumber].Cells[0].Value = rowNumber + 1;
            TableScript_dgv.Rows[rowNumber].Cells[1].Value = "группа";
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
                    TableScript_dgv.Rows[rowNumber].Cells[y].Value = str;
                    y++;
                }
            }
            rowNumber = TableScript_dgv.Rows.Add();
            TableScript_dgv.Rows[rowNumber].Cells[0].Value = rowNumber + 1;
            TableScript_dgv.Rows[rowNumber].Cells[1].Value = "конец";
        }

        private void EditComand_btn_Click(object sender, EventArgs e)
        {
            if (tabScripts.SelectedIndex == 1)
            {
                TableScript_dgv.CurrentRow.Cells[1].Value = EditCommand_tb.Text;
            }
            else
            {
                TreeViewOfScript.SelectedNode.Text = EditCommand_tb.Text;
            }
            EditCommand_tb.Text = "";
        }

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
                    tw.WriteLine(str);
                }
            }
            tw.Close();
            string[] name = saveFileScript.FileName.Split('\\');
            StatusStripNameOfFile.Items[0].Text = name[name.Length - 1];
            TreeViewOfScript.Nodes[0].Text = name[name.Length - 1];
            MessageBox.Show($"Текстовый сценарий \"{name[name.Length - 1]}\" успешно сохранен!");
        }

        private void TableScript_dgv_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (TableScript_dgv.CurrentRow != null && TableScript_dgv.CurrentRow.Cells[2].Value != null)
            {
                EditCommand_tb.Text = "";
                EditCommand_tb.Text = TableScript_dgv.CurrentRow.Cells[2].Value.ToString();
            }
        }

        private void AddCommand_btn_Click(object sender, EventArgs e)
        {
            //добавление в таблицу
            if (TableScript_dgv.SelectedRows.Count == 0)
            {
                if (Command_cmb.SelectedItem != null)
                {
                    if (Command_cmb.SelectedIndex > 4 && Command_cmb.SelectedIndex < 11 || Command_cmb.SelectedIndex == 0)
                    {
                        if (Params_cmb.Visible == false)
                        {
                            if (Params_tb.Text != "")
                                TableScript_dgv.Rows.Add(TableScript_dgv.RowCount + 1, Command_cmb.SelectedItem.ToString(), Params_tb.Text);
                            else MessageBox.Show("Для данной команды необходимо ввести значение");
                        }
                        else if (Params_cmb.SelectedIndex != -1)
                            TableScript_dgv.Rows.Add(TableScript_dgv.RowCount + 1, Command_cmb.SelectedItem.ToString(), Params_cmb.SelectedItem.ToString());
                        else MessageBox.Show("Для данной команды необходимо выбрать значение");
                    }
                    else
                    {
                        TableScript_dgv.Rows.Add(TableScript_dgv.RowCount + 1, Command_cmb.SelectedItem.ToString());
                    }
                }
            }
            else
            {
                if (Command_cmb.SelectedItem != null)
                {
                    if (Command_cmb.SelectedIndex > 5 && Command_cmb.SelectedIndex < 11 || Command_cmb.SelectedIndex == 0)
                    {
                        if (Params_cmb.Visible == false)
                        {
                            if (Params_tb.Text != "")
                                TableScript_dgv.Rows.Insert(TableScript_dgv.SelectedCells[0].RowIndex + 1, TableScript_dgv.Rows.Count + 1, Command_cmb.SelectedItem.ToString(), Params_tb.Text);
                            else MessageBox.Show("Для данной команды необходимо ввести значение");
                        }
                        else if (Params_cmb.SelectedIndex != -1)
                            TableScript_dgv.Rows.Insert(TableScript_dgv.SelectedCells[0].RowIndex + 1, TableScript_dgv.Rows.Count + 1, Command_cmb.SelectedItem.ToString(), Params_cmb.SelectedItem.ToString());
                        else MessageBox.Show("Для данной команды необходимо выбрать значение");
                    }
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
                }
            }
            TableScript_dgv.ClearSelection();

            //добавление в тривью
            if (Command_cmb.SelectedItem != null)
            {
                if (Command_cmb.SelectedIndex > 4 && Command_cmb.SelectedIndex < 11 || Command_cmb.SelectedIndex == 0)
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

        private void Command_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Command_cmb.SelectedIndex > 5 && Command_cmb.SelectedIndex < 11 || Command_cmb.SelectedIndex == 0)
            {
                Params_cmb.Visible = false;
                Params_tb.Visible = true;
                Params_tb.Text = "";
            }
            else if (Command_cmb.SelectedIndex == 5)
            {
                Params_tb.Visible = false;
                Params_cmb.Visible = true;
                Params_cmb.SelectedIndex = -1;
            }
            else
            {
                Params_cmb.Visible = false;
                Params_tb.Visible = false;
            }
        }

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
        private void StartScript_btn_Click(object sender, EventArgs e)
        {
            //new Thread(TestEachCommand).Start();// попытка в потоки - не работает SendMessage()
            //CancellationTokenSource token = new CancellationTokenSource();
            //Task.Factory.StartNew(() =>
            //{
            //    TestEachCommand(token.Token);
            //});// попытка в потоки - не работает SendMessage()
            TestEachCommand();
        }

        private void OneStepForward_btn_Click(object sender, EventArgs e)
        {
            if(TableScript_dgv.SelectedRows!=null)
            {
                List<string> command = new List<string>();
                command.Add(TableScript_dgv.Rows[TableScript_dgv.SelectedRows[0].Index].Cells[1].Value.ToString());
                int index = TableScript_dgv.SelectedRows[0].Index;
                DoCommand(command,index);
            }
        }
    }
}