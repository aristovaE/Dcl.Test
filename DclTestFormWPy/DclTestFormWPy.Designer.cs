﻿namespace DclTestFormWPy
{
    partial class DclTestFormWPy
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("новый сценарий");
            this.EditCommand_tb = new System.Windows.Forms.TextBox();
            this.EditComand_btn = new System.Windows.Forms.Button();
            this.openFileScript = new System.Windows.Forms.OpenFileDialog();
            this.FromTheBeginning_btn = new System.Windows.Forms.Button();
            this.scriptsTask_ms = new System.Windows.Forms.MenuStrip();
            this.MainMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Open_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenScript_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenGroup_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Save_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileScript = new System.Windows.Forms.SaveFileDialog();
            this.TableScript_dgv = new System.Windows.Forms.DataGridView();
            this.numberOfCommand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameOfCommand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paramOfCommand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionOfCommand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resultOfCommand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BreakPointOfCommand = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Command_cmb = new System.Windows.Forms.ComboBox();
            this.addCommand_btn = new System.Windows.Forms.Button();
            this.Params_cmb = new System.Windows.Forms.ComboBox();
            this.Params_tb = new System.Windows.Forms.TextBox();
            this.DeleteCommand_btn = new System.Windows.Forms.Button();
            this.add_gb = new System.Windows.Forms.GroupBox();
            this.EndGroup_btn = new System.Windows.Forms.Button();
            this.del_gb = new System.Windows.Forms.GroupBox();
            this.edit_gb = new System.Windows.Forms.GroupBox();
            this.fileName_lbl = new System.Windows.Forms.Label();
            this.TreeViewOfScript = new System.Windows.Forms.TreeView();
            this.contextMenuToTreeView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tabScripts = new System.Windows.Forms.TabControl();
            this.tabTreeViewScript = new System.Windows.Forms.TabPage();
            this.tabTableScript = new System.Windows.Forms.TabPage();
            this.openFileGroup = new System.Windows.Forms.OpenFileDialog();
            this.DeleteAll_btn = new System.Windows.Forms.Button();
            this.StatusStripNameOfFile = new System.Windows.Forms.StatusStrip();
            this.fileName_statstrip = new System.Windows.Forms.ToolStripStatusLabel();
            this.OneStepForward_btn = new System.Windows.Forms.Button();
            this.OneStepBackward_btn = new System.Windows.Forms.Button();
            this.StartScript_btn = new System.Windows.Forms.Button();
            this.contextMenuToStart = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CoordX_tb = new System.Windows.Forms.TextBox();
            this.CoordY_tb = new System.Windows.Forms.TextBox();
            this.x_lbl = new System.Windows.Forms.Label();
            this.y_lbl = new System.Windows.Forms.Label();
            this.scriptsTask_ms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TableScript_dgv)).BeginInit();
            this.add_gb.SuspendLayout();
            this.del_gb.SuspendLayout();
            this.edit_gb.SuspendLayout();
            this.tabScripts.SuspendLayout();
            this.tabTreeViewScript.SuspendLayout();
            this.tabTableScript.SuspendLayout();
            this.StatusStripNameOfFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // EditCommand_tb
            // 
            this.EditCommand_tb.Location = new System.Drawing.Point(10, 19);
            this.EditCommand_tb.Name = "EditCommand_tb";
            this.EditCommand_tb.Size = new System.Drawing.Size(148, 20);
            this.EditCommand_tb.TabIndex = 2;
            // 
            // EditComand_btn
            // 
            this.EditComand_btn.Location = new System.Drawing.Point(164, 16);
            this.EditComand_btn.Name = "EditComand_btn";
            this.EditComand_btn.Size = new System.Drawing.Size(75, 25);
            this.EditComand_btn.TabIndex = 3;
            this.EditComand_btn.Text = "Изменить";
            this.EditComand_btn.UseVisualStyleBackColor = true;
            this.EditComand_btn.Click += new System.EventHandler(this.EditComand_btn_Click);
            // 
            // openFileScript
            // 
            this.openFileScript.FileName = "openFileDialog1";
            // 
            // FromTheBeginning_btn
            // 
            this.FromTheBeginning_btn.Location = new System.Drawing.Point(12, 287);
            this.FromTheBeginning_btn.Name = "FromTheBeginning_btn";
            this.FromTheBeginning_btn.Size = new System.Drawing.Size(148, 25);
            this.FromTheBeginning_btn.TabIndex = 4;
            this.FromTheBeginning_btn.Text = "Выполнить всё";
            this.FromTheBeginning_btn.UseVisualStyleBackColor = true;
            this.FromTheBeginning_btn.Visible = false;
            this.FromTheBeginning_btn.Click += new System.EventHandler(this.FromTheBeginning_btn_Click);
            // 
            // scriptsTask_ms
            // 
            this.scriptsTask_ms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainMenuItem});
            this.scriptsTask_ms.Location = new System.Drawing.Point(0, 0);
            this.scriptsTask_ms.Name = "scriptsTask_ms";
            this.scriptsTask_ms.Size = new System.Drawing.Size(1023, 24);
            this.scriptsTask_ms.TabIndex = 5;
            this.scriptsTask_ms.Text = "menuStrip1";
            // 
            // MainMenuItem
            // 
            this.MainMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Open_MenuItem,
            this.Save_MenuItem});
            this.MainMenuItem.Name = "MainMenuItem";
            this.MainMenuItem.Size = new System.Drawing.Size(74, 20);
            this.MainMenuItem.Text = "Сценарий";
            // 
            // Open_MenuItem
            // 
            this.Open_MenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenScript_MenuItem,
            this.OpenGroup_MenuItem});
            this.Open_MenuItem.Name = "Open_MenuItem";
            this.Open_MenuItem.Size = new System.Drawing.Size(133, 22);
            this.Open_MenuItem.Text = "Открыть";
            // 
            // OpenScript_MenuItem
            // 
            this.OpenScript_MenuItem.Name = "OpenScript_MenuItem";
            this.OpenScript_MenuItem.Size = new System.Drawing.Size(129, 22);
            this.OpenScript_MenuItem.Text = "Сценарий";
            this.OpenScript_MenuItem.Click += new System.EventHandler(this.OpenScriptMenuItem_Click);
            // 
            // OpenGroup_MenuItem
            // 
            this.OpenGroup_MenuItem.Name = "OpenGroup_MenuItem";
            this.OpenGroup_MenuItem.Size = new System.Drawing.Size(129, 22);
            this.OpenGroup_MenuItem.Text = "Шаблон";
            this.OpenGroup_MenuItem.Click += new System.EventHandler(this.OpenGroupMenuItem_Click);
            // 
            // Save_MenuItem
            // 
            this.Save_MenuItem.Name = "Save_MenuItem";
            this.Save_MenuItem.Size = new System.Drawing.Size(133, 22);
            this.Save_MenuItem.Text = "Сохранить";
            this.Save_MenuItem.Click += new System.EventHandler(this.SaveMenuItem_Click);
            // 
            // TableScript_dgv
            // 
            this.TableScript_dgv.AllowUserToAddRows = false;
            this.TableScript_dgv.AllowUserToOrderColumns = true;
            this.TableScript_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.TableScript_dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.TableScript_dgv.BackgroundColor = System.Drawing.SystemColors.Control;
            this.TableScript_dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TableScript_dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.TableScript_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TableScript_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numberOfCommand,
            this.nameOfCommand,
            this.paramOfCommand,
            this.descriptionOfCommand,
            this.resultOfCommand,
            this.BreakPointOfCommand});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.TableScript_dgv.DefaultCellStyle = dataGridViewCellStyle8;
            this.TableScript_dgv.GridColor = System.Drawing.SystemColors.Control;
            this.TableScript_dgv.Location = new System.Drawing.Point(6, 6);
            this.TableScript_dgv.Name = "TableScript_dgv";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TableScript_dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.TableScript_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.TableScript_dgv.Size = new System.Drawing.Size(738, 233);
            this.TableScript_dgv.TabIndex = 7;
            this.TableScript_dgv.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.TableScript_dgv_RowHeaderMouseClick);
            // 
            // numberOfCommand
            // 
            this.numberOfCommand.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.numberOfCommand.FillWeight = 7F;
            this.numberOfCommand.HeaderText = "№";
            this.numberOfCommand.Name = "numberOfCommand";
            this.numberOfCommand.ReadOnly = true;
            this.numberOfCommand.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // nameOfCommand
            // 
            this.nameOfCommand.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameOfCommand.FillWeight = 60F;
            this.nameOfCommand.HeaderText = "Название";
            this.nameOfCommand.Name = "nameOfCommand";
            this.nameOfCommand.ReadOnly = true;
            // 
            // paramOfCommand
            // 
            this.paramOfCommand.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.paramOfCommand.FillWeight = 30F;
            this.paramOfCommand.HeaderText = "Параметр";
            this.paramOfCommand.Name = "paramOfCommand";
            // 
            // descriptionOfCommand
            // 
            this.descriptionOfCommand.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descriptionOfCommand.FillWeight = 80F;
            this.descriptionOfCommand.HeaderText = "Описание";
            this.descriptionOfCommand.Name = "descriptionOfCommand";
            // 
            // resultOfCommand
            // 
            this.resultOfCommand.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.resultOfCommand.FillWeight = 25F;
            this.resultOfCommand.HeaderText = "Результат";
            this.resultOfCommand.Name = "resultOfCommand";
            this.resultOfCommand.ReadOnly = true;
            // 
            // BreakPointOfCommand
            // 
            this.BreakPointOfCommand.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BreakPointOfCommand.FillWeight = 25F;
            this.BreakPointOfCommand.HeaderText = "Точка останова";
            this.BreakPointOfCommand.Name = "BreakPointOfCommand";
            this.BreakPointOfCommand.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BreakPointOfCommand.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Command_cmb
            // 
            this.Command_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Command_cmb.FormattingEnabled = true;
            this.Command_cmb.Items.AddRange(new object[] {
            " ",
            "открыть окно ВД",
            "выполнить автозаполнение",
            "открыть классификатор",
            "перейти вперед",
            "перейти назад",
            "",
            "нажать",
            "ввести значение",
            "найти значение",
            "перейти к графе номер",
            "подождать секунд",
            "группа",
            "",
            "добавить товар",
            "перейти к первому товару",
            "",
            "проверка",
            "",
            "в столбце",
            "в строке",
            "",
            "нажать в точке"});
            this.Command_cmb.Location = new System.Drawing.Point(10, 22);
            this.Command_cmb.Name = "Command_cmb";
            this.Command_cmb.Size = new System.Drawing.Size(148, 21);
            this.Command_cmb.TabIndex = 8;
            this.Command_cmb.SelectedIndexChanged += new System.EventHandler(this.Command_cmb_SelectedIndexChanged);
            // 
            // addCommand_btn
            // 
            this.addCommand_btn.Location = new System.Drawing.Point(164, 19);
            this.addCommand_btn.Name = "addCommand_btn";
            this.addCommand_btn.Size = new System.Drawing.Size(75, 25);
            this.addCommand_btn.TabIndex = 9;
            this.addCommand_btn.Text = "Добавить";
            this.addCommand_btn.UseVisualStyleBackColor = true;
            this.addCommand_btn.Click += new System.EventHandler(this.AddCommand_btn_Click);
            // 
            // Params_cmb
            // 
            this.Params_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Params_cmb.FormattingEnabled = true;
            this.Params_cmb.Items.AddRange(new object[] {
            "ENTER",
            "F5",
            "ESC",
            "F3",
            "стрелку влево",
            "стрелку вправо",
            "стрелку вверх",
            "стрелку вниз"});
            this.Params_cmb.Location = new System.Drawing.Point(10, 53);
            this.Params_cmb.Name = "Params_cmb";
            this.Params_cmb.Size = new System.Drawing.Size(148, 21);
            this.Params_cmb.TabIndex = 10;
            this.Params_cmb.Visible = false;
            // 
            // Params_tb
            // 
            this.Params_tb.Location = new System.Drawing.Point(10, 53);
            this.Params_tb.Name = "Params_tb";
            this.Params_tb.Size = new System.Drawing.Size(148, 20);
            this.Params_tb.TabIndex = 11;
            this.Params_tb.Visible = false;
            // 
            // DeleteCommand_btn
            // 
            this.DeleteCommand_btn.Location = new System.Drawing.Point(164, 19);
            this.DeleteCommand_btn.Name = "DeleteCommand_btn";
            this.DeleteCommand_btn.Size = new System.Drawing.Size(75, 23);
            this.DeleteCommand_btn.TabIndex = 12;
            this.DeleteCommand_btn.Text = "Удалить";
            this.DeleteCommand_btn.UseVisualStyleBackColor = true;
            this.DeleteCommand_btn.Click += new System.EventHandler(this.DeleteCommand_btn_Click);
            // 
            // add_gb
            // 
            this.add_gb.Controls.Add(this.y_lbl);
            this.add_gb.Controls.Add(this.x_lbl);
            this.add_gb.Controls.Add(this.CoordY_tb);
            this.add_gb.Controls.Add(this.CoordX_tb);
            this.add_gb.Controls.Add(this.EndGroup_btn);
            this.add_gb.Controls.Add(this.Command_cmb);
            this.add_gb.Controls.Add(this.Params_tb);
            this.add_gb.Controls.Add(this.addCommand_btn);
            this.add_gb.Controls.Add(this.Params_cmb);
            this.add_gb.Location = new System.Drawing.Point(766, 49);
            this.add_gb.Name = "add_gb";
            this.add_gb.Size = new System.Drawing.Size(245, 86);
            this.add_gb.TabIndex = 13;
            this.add_gb.TabStop = false;
            this.add_gb.Text = "Добавление";
            // 
            // EndGroup_btn
            // 
            this.EndGroup_btn.Location = new System.Drawing.Point(164, 50);
            this.EndGroup_btn.Name = "EndGroup_btn";
            this.EndGroup_btn.Size = new System.Drawing.Size(75, 25);
            this.EndGroup_btn.TabIndex = 12;
            this.EndGroup_btn.Text = "Конец";
            this.EndGroup_btn.UseVisualStyleBackColor = true;
            this.EndGroup_btn.Visible = false;
            this.EndGroup_btn.Click += new System.EventHandler(this.EndGroup_btn_Click);
            // 
            // del_gb
            // 
            this.del_gb.Controls.Add(this.DeleteCommand_btn);
            this.del_gb.Location = new System.Drawing.Point(766, 141);
            this.del_gb.Name = "del_gb";
            this.del_gb.Size = new System.Drawing.Size(245, 56);
            this.del_gb.TabIndex = 14;
            this.del_gb.TabStop = false;
            this.del_gb.Text = "Удаление";
            // 
            // edit_gb
            // 
            this.edit_gb.Controls.Add(this.EditComand_btn);
            this.edit_gb.Controls.Add(this.EditCommand_tb);
            this.edit_gb.Location = new System.Drawing.Point(766, 204);
            this.edit_gb.Name = "edit_gb";
            this.edit_gb.Size = new System.Drawing.Size(245, 81);
            this.edit_gb.TabIndex = 15;
            this.edit_gb.TabStop = false;
            this.edit_gb.Text = "Редактирование";
            // 
            // fileName_lbl
            // 
            this.fileName_lbl.AutoSize = true;
            this.fileName_lbl.Location = new System.Drawing.Point(166, 258);
            this.fileName_lbl.Name = "fileName_lbl";
            this.fileName_lbl.Size = new System.Drawing.Size(10, 13);
            this.fileName_lbl.TabIndex = 16;
            this.fileName_lbl.Text = " ";
            // 
            // TreeViewOfScript
            // 
            this.TreeViewOfScript.ContextMenuStrip = this.contextMenuToTreeView;
            this.TreeViewOfScript.Location = new System.Drawing.Point(6, 6);
            this.TreeViewOfScript.Name = "TreeViewOfScript";
            treeNode1.Name = "nameScript";
            treeNode1.Text = "новый сценарий";
            this.TreeViewOfScript.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.TreeViewOfScript.Size = new System.Drawing.Size(738, 233);
            this.TreeViewOfScript.TabIndex = 17;
            this.TreeViewOfScript.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TreeViewOfScript_MouseDown);
            // 
            // contextMenuToTreeView
            // 
            this.contextMenuToTreeView.Name = "contextMenuToTreeView";
            this.contextMenuToTreeView.Size = new System.Drawing.Size(61, 4);
            // 
            // tabScripts
            // 
            this.tabScripts.Controls.Add(this.tabTreeViewScript);
            this.tabScripts.Controls.Add(this.tabTableScript);
            this.tabScripts.Location = new System.Drawing.Point(12, 27);
            this.tabScripts.Name = "tabScripts";
            this.tabScripts.SelectedIndex = 0;
            this.tabScripts.Size = new System.Drawing.Size(758, 271);
            this.tabScripts.TabIndex = 18;
            // 
            // tabTreeViewScript
            // 
            this.tabTreeViewScript.Controls.Add(this.TreeViewOfScript);
            this.tabTreeViewScript.Location = new System.Drawing.Point(4, 22);
            this.tabTreeViewScript.Name = "tabTreeViewScript";
            this.tabTreeViewScript.Padding = new System.Windows.Forms.Padding(3);
            this.tabTreeViewScript.Size = new System.Drawing.Size(750, 245);
            this.tabTreeViewScript.TabIndex = 0;
            this.tabTreeViewScript.Text = "Древовидно";
            this.tabTreeViewScript.UseVisualStyleBackColor = true;
            // 
            // tabTableScript
            // 
            this.tabTableScript.Controls.Add(this.TableScript_dgv);
            this.tabTableScript.Location = new System.Drawing.Point(4, 22);
            this.tabTableScript.Name = "tabTableScript";
            this.tabTableScript.Padding = new System.Windows.Forms.Padding(3);
            this.tabTableScript.Size = new System.Drawing.Size(750, 245);
            this.tabTableScript.TabIndex = 1;
            this.tabTableScript.Text = "Таблично";
            this.tabTableScript.UseVisualStyleBackColor = true;
            // 
            // openFileGroup
            // 
            this.openFileGroup.FileName = "openFileDialog1";
            // 
            // DeleteAll_btn
            // 
            this.DeleteAll_btn.Location = new System.Drawing.Point(936, 304);
            this.DeleteAll_btn.Name = "DeleteAll_btn";
            this.DeleteAll_btn.Size = new System.Drawing.Size(75, 25);
            this.DeleteAll_btn.TabIndex = 21;
            this.DeleteAll_btn.Text = "Очистить";
            this.DeleteAll_btn.UseVisualStyleBackColor = true;
            this.DeleteAll_btn.Click += new System.EventHandler(this.DeleteAll_btn_Click);
            // 
            // StatusStripNameOfFile
            // 
            this.StatusStripNameOfFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileName_statstrip});
            this.StatusStripNameOfFile.Location = new System.Drawing.Point(0, 332);
            this.StatusStripNameOfFile.Name = "StatusStripNameOfFile";
            this.StatusStripNameOfFile.Size = new System.Drawing.Size(1023, 22);
            this.StatusStripNameOfFile.TabIndex = 22;
            // 
            // fileName_statstrip
            // 
            this.fileName_statstrip.Name = "fileName_statstrip";
            this.fileName_statstrip.Size = new System.Drawing.Size(0, 17);
            // 
            // OneStepForward_btn
            // 
            this.OneStepForward_btn.Location = new System.Drawing.Point(398, 304);
            this.OneStepForward_btn.Name = "OneStepForward_btn";
            this.OneStepForward_btn.Size = new System.Drawing.Size(75, 25);
            this.OneStepForward_btn.TabIndex = 23;
            this.OneStepForward_btn.Text = "Вперед";
            this.OneStepForward_btn.UseVisualStyleBackColor = true;
            this.OneStepForward_btn.Click += new System.EventHandler(this.OneStepForward_btn_Click);
            // 
            // OneStepBackward_btn
            // 
            this.OneStepBackward_btn.Location = new System.Drawing.Point(286, 304);
            this.OneStepBackward_btn.Name = "OneStepBackward_btn";
            this.OneStepBackward_btn.Size = new System.Drawing.Size(75, 25);
            this.OneStepBackward_btn.TabIndex = 24;
            this.OneStepBackward_btn.Text = "Назад";
            this.OneStepBackward_btn.UseVisualStyleBackColor = true;
            this.OneStepBackward_btn.Click += new System.EventHandler(this.OneStepBackward_btn_Click);
            // 
            // StartScript_btn
            // 
            this.StartScript_btn.ContextMenuStrip = this.contextMenuToStart;
            this.StartScript_btn.Location = new System.Drawing.Point(367, 304);
            this.StartScript_btn.Name = "StartScript_btn";
            this.StartScript_btn.Size = new System.Drawing.Size(25, 25);
            this.StartScript_btn.TabIndex = 25;
            this.StartScript_btn.Text = "▶";
            this.StartScript_btn.UseVisualStyleBackColor = true;
            this.StartScript_btn.Click += new System.EventHandler(this.StartScript_btn_Click);
            this.StartScript_btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StartScript_btn_MouseDown);
            // 
            // contextMenuToStart
            // 
            this.contextMenuToStart.Name = "contextMenuToStart";
            this.contextMenuToStart.Size = new System.Drawing.Size(61, 4);
            // 
            // CoordX_tb
            // 
            this.CoordX_tb.Location = new System.Drawing.Point(34, 53);
            this.CoordX_tb.Name = "CoordX_tb";
            this.CoordX_tb.Size = new System.Drawing.Size(45, 20);
            this.CoordX_tb.TabIndex = 13;
            this.CoordX_tb.Visible = false;
            // 
            // CoordY_tb
            // 
            this.CoordY_tb.Location = new System.Drawing.Point(113, 53);
            this.CoordY_tb.Name = "CoordY_tb";
            this.CoordY_tb.Size = new System.Drawing.Size(45, 20);
            this.CoordY_tb.TabIndex = 14;
            this.CoordY_tb.Visible = false;
            // 
            // x_lbl
            // 
            this.x_lbl.AutoSize = true;
            this.x_lbl.Location = new System.Drawing.Point(10, 56);
            this.x_lbl.Name = "x_lbl";
            this.x_lbl.Size = new System.Drawing.Size(18, 13);
            this.x_lbl.TabIndex = 15;
            this.x_lbl.Tag = " ";
            this.x_lbl.Text = "x :";
            this.x_lbl.Visible = false;
            // 
            // y_lbl
            // 
            this.y_lbl.AutoSize = true;
            this.y_lbl.Location = new System.Drawing.Point(89, 56);
            this.y_lbl.Name = "y_lbl";
            this.y_lbl.Size = new System.Drawing.Size(18, 13);
            this.y_lbl.TabIndex = 16;
            this.y_lbl.Tag = " ";
            this.y_lbl.Text = "y :";
            this.y_lbl.Visible = false;
            // 
            // DclTestFormWPy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 354);
            this.Controls.Add(this.StartScript_btn);
            this.Controls.Add(this.OneStepBackward_btn);
            this.Controls.Add(this.OneStepForward_btn);
            this.Controls.Add(this.StatusStripNameOfFile);
            this.Controls.Add(this.DeleteAll_btn);
            this.Controls.Add(this.tabScripts);
            this.Controls.Add(this.fileName_lbl);
            this.Controls.Add(this.edit_gb);
            this.Controls.Add(this.del_gb);
            this.Controls.Add(this.add_gb);
            this.Controls.Add(this.FromTheBeginning_btn);
            this.Controls.Add(this.scriptsTask_ms);
            this.MainMenuStrip = this.scriptsTask_ms;
            this.Name = "DclTestFormWPy";
            this.Text = "DclTest";
            this.scriptsTask_ms.ResumeLayout(false);
            this.scriptsTask_ms.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TableScript_dgv)).EndInit();
            this.add_gb.ResumeLayout(false);
            this.add_gb.PerformLayout();
            this.del_gb.ResumeLayout(false);
            this.edit_gb.ResumeLayout(false);
            this.edit_gb.PerformLayout();
            this.tabScripts.ResumeLayout(false);
            this.tabTreeViewScript.ResumeLayout(false);
            this.tabTableScript.ResumeLayout(false);
            this.StatusStripNameOfFile.ResumeLayout(false);
            this.StatusStripNameOfFile.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox EditCommand_tb;
        private System.Windows.Forms.Button EditComand_btn;
        private System.Windows.Forms.OpenFileDialog openFileScript;
        private System.Windows.Forms.Button FromTheBeginning_btn;
        private System.Windows.Forms.MenuStrip scriptsTask_ms;
        private System.Windows.Forms.ToolStripMenuItem MainMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Open_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem Save_MenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileScript;
        private System.Windows.Forms.DataGridView TableScript_dgv;
        private System.Windows.Forms.ComboBox Command_cmb;
        private System.Windows.Forms.Button addCommand_btn;
        private System.Windows.Forms.ComboBox Params_cmb;
        private System.Windows.Forms.TextBox Params_tb;
        private System.Windows.Forms.Button DeleteCommand_btn;
        private System.Windows.Forms.GroupBox add_gb;
        private System.Windows.Forms.GroupBox del_gb;
        private System.Windows.Forms.GroupBox edit_gb;
        private System.Windows.Forms.Label fileName_lbl;
        private System.Windows.Forms.TreeView TreeViewOfScript;
        private System.Windows.Forms.Button EndGroup_btn;
        private System.Windows.Forms.TabControl tabScripts;
        private System.Windows.Forms.TabPage tabTreeViewScript;
        private System.Windows.Forms.TabPage tabTableScript;
        private System.Windows.Forms.OpenFileDialog openFileGroup;
        private System.Windows.Forms.ToolStripMenuItem OpenScript_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenGroup_MenuItem;
        private System.Windows.Forms.Button DeleteAll_btn;
        private System.Windows.Forms.ContextMenuStrip contextMenuToTreeView;
        private System.Windows.Forms.StatusStrip StatusStripNameOfFile;
        private System.Windows.Forms.ToolStripStatusLabel fileName_statstrip;
        private System.Windows.Forms.Button OneStepForward_btn;
        private System.Windows.Forms.Button OneStepBackward_btn;
        private System.Windows.Forms.Button StartScript_btn;
        private System.Windows.Forms.ContextMenuStrip contextMenuToStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberOfCommand;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameOfCommand;
        private System.Windows.Forms.DataGridViewTextBoxColumn paramOfCommand;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionOfCommand;
        private System.Windows.Forms.DataGridViewTextBoxColumn resultOfCommand;
        private System.Windows.Forms.DataGridViewCheckBoxColumn BreakPointOfCommand;
        private System.Windows.Forms.Label y_lbl;
        private System.Windows.Forms.Label x_lbl;
        private System.Windows.Forms.TextBox CoordY_tb;
        private System.Windows.Forms.TextBox CoordX_tb;
    }
}