namespace DclTestFormWPy
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
            this.chooseScript_btn = new System.Windows.Forms.Button();
            this.listOfCommand = new System.Windows.Forms.ListView();
            this.editCommand_tb = new System.Windows.Forms.TextBox();
            this.editComand_btn = new System.Windows.Forms.Button();
            this.openFileScript = new System.Windows.Forms.OpenFileDialog();
            this.startScript_btn = new System.Windows.Forms.Button();
            this.scriptsTask_ms = new System.Windows.Forms.MenuStrip();
            this.сценарийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сценарийToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.группуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileScript = new System.Windows.Forms.SaveFileDialog();
            this.tableScript_dgv = new System.Windows.Forms.DataGridView();
            this.numberOfCommand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameOfCommand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paramOfCommand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionOfCommand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resultOfCommand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.command_cmb = new System.Windows.Forms.ComboBox();
            this.addCommand_btn = new System.Windows.Forms.Button();
            this.params_cmb = new System.Windows.Forms.ComboBox();
            this.params_tb = new System.Windows.Forms.TextBox();
            this.delCommand_btn = new System.Windows.Forms.Button();
            this.add_gb = new System.Windows.Forms.GroupBox();
            this.endGroup_btn = new System.Windows.Forms.Button();
            this.del_gb = new System.Windows.Forms.GroupBox();
            this.edit_gb = new System.Windows.Forms.GroupBox();
            this.fileName_lbl = new System.Windows.Forms.Label();
            this.treeViewOfScript = new System.Windows.Forms.TreeView();
            this.tabScripts = new System.Windows.Forms.TabControl();
            this.tabTreeViewScript = new System.Windows.Forms.TabPage();
            this.tabTableScript = new System.Windows.Forms.TabPage();
            this.refresh_btn = new System.Windows.Forms.Button();
            this.openFileGroup = new System.Windows.Forms.OpenFileDialog();
            this.DeleteAll_btn = new System.Windows.Forms.Button();
            this.scriptsTask_ms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableScript_dgv)).BeginInit();
            this.add_gb.SuspendLayout();
            this.del_gb.SuspendLayout();
            this.edit_gb.SuspendLayout();
            this.tabScripts.SuspendLayout();
            this.tabTreeViewScript.SuspendLayout();
            this.tabTableScript.SuspendLayout();
            this.SuspendLayout();
            // 
            // chooseScript_btn
            // 
            this.chooseScript_btn.Location = new System.Drawing.Point(861, 42);
            this.chooseScript_btn.Name = "chooseScript_btn";
            this.chooseScript_btn.Size = new System.Drawing.Size(148, 27);
            this.chooseScript_btn.TabIndex = 0;
            this.chooseScript_btn.Text = "Выбрать сценарий";
            this.chooseScript_btn.UseVisualStyleBackColor = true;
            this.chooseScript_btn.Visible = false;
            this.chooseScript_btn.Click += new System.EventHandler(this.chooseScript_btn_Click);
            // 
            // listOfCommand
            // 
            this.listOfCommand.HideSelection = false;
            this.listOfCommand.Location = new System.Drawing.Point(223, 42);
            this.listOfCommand.Name = "listOfCommand";
            this.listOfCommand.Size = new System.Drawing.Size(150, 237);
            this.listOfCommand.TabIndex = 1;
            this.listOfCommand.UseCompatibleStateImageBehavior = false;
            this.listOfCommand.View = System.Windows.Forms.View.List;
            this.listOfCommand.Visible = false;
            this.listOfCommand.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listOfCommand_MouseClick);
            // 
            // editCommand_tb
            // 
            this.editCommand_tb.Location = new System.Drawing.Point(10, 19);
            this.editCommand_tb.Name = "editCommand_tb";
            this.editCommand_tb.Size = new System.Drawing.Size(148, 20);
            this.editCommand_tb.TabIndex = 2;
            // 
            // editComand_btn
            // 
            this.editComand_btn.Location = new System.Drawing.Point(164, 16);
            this.editComand_btn.Name = "editComand_btn";
            this.editComand_btn.Size = new System.Drawing.Size(75, 25);
            this.editComand_btn.TabIndex = 3;
            this.editComand_btn.Text = "Изменить";
            this.editComand_btn.UseVisualStyleBackColor = true;
            this.editComand_btn.Click += new System.EventHandler(this.editComand_btn_Click);
            // 
            // openFileScript
            // 
            this.openFileScript.FileName = "openFileDialog1";
            // 
            // startScript_btn
            // 
            this.startScript_btn.Location = new System.Drawing.Point(12, 247);
            this.startScript_btn.Name = "startScript_btn";
            this.startScript_btn.Size = new System.Drawing.Size(148, 32);
            this.startScript_btn.TabIndex = 4;
            this.startScript_btn.Text = "Выполнить";
            this.startScript_btn.UseVisualStyleBackColor = true;
            this.startScript_btn.Click += new System.EventHandler(this.startScript_btn_Click);
            // 
            // scriptsTask_ms
            // 
            this.scriptsTask_ms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сценарийToolStripMenuItem});
            this.scriptsTask_ms.Location = new System.Drawing.Point(0, 0);
            this.scriptsTask_ms.Name = "scriptsTask_ms";
            this.scriptsTask_ms.Size = new System.Drawing.Size(862, 24);
            this.scriptsTask_ms.TabIndex = 5;
            this.scriptsTask_ms.Text = "menuStrip1";
            // 
            // сценарийToolStripMenuItem
            // 
            this.сценарийToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.сохранитьToolStripMenuItem});
            this.сценарийToolStripMenuItem.Name = "сценарийToolStripMenuItem";
            this.сценарийToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.сценарийToolStripMenuItem.Text = "Сценарий";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сценарийToolStripMenuItem1,
            this.группуToolStripMenuItem});
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.открытьToolStripMenuItem.Text = "Открыть";
            // 
            // сценарийToolStripMenuItem1
            // 
            this.сценарийToolStripMenuItem1.Name = "сценарийToolStripMenuItem1";
            this.сценарийToolStripMenuItem1.Size = new System.Drawing.Size(129, 22);
            this.сценарийToolStripMenuItem1.Text = "Сценарий";
            this.сценарийToolStripMenuItem1.Click += new System.EventHandler(this.сценарийToolStripMenuItem1_Click);
            // 
            // группуToolStripMenuItem
            // 
            this.группуToolStripMenuItem.Name = "группуToolStripMenuItem";
            this.группуToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.группуToolStripMenuItem.Text = "Группу";
            this.группуToolStripMenuItem.Click += new System.EventHandler(this.группуToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // tableScript_dgv
            // 
            this.tableScript_dgv.AllowUserToAddRows = false;
            this.tableScript_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tableScript_dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.tableScript_dgv.BackgroundColor = System.Drawing.SystemColors.Control;
            this.tableScript_dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tableScript_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableScript_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numberOfCommand,
            this.nameOfCommand,
            this.paramOfCommand,
            this.descriptionOfCommand,
            this.resultOfCommand});
            this.tableScript_dgv.GridColor = System.Drawing.SystemColors.Control;
            this.tableScript_dgv.Location = new System.Drawing.Point(0, 0);
            this.tableScript_dgv.Name = "tableScript_dgv";
            this.tableScript_dgv.Size = new System.Drawing.Size(584, 188);
            this.tableScript_dgv.TabIndex = 7;
            this.tableScript_dgv.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.tableScript_dgv_RowHeaderMouseClick);
            // 
            // numberOfCommand
            // 
            this.numberOfCommand.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.numberOfCommand.FillWeight = 18F;
            this.numberOfCommand.HeaderText = "Id";
            this.numberOfCommand.Name = "numberOfCommand";
            this.numberOfCommand.ReadOnly = true;
            this.numberOfCommand.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // nameOfCommand
            // 
            this.nameOfCommand.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameOfCommand.HeaderText = "Название";
            this.nameOfCommand.Name = "nameOfCommand";
            this.nameOfCommand.ReadOnly = true;
            // 
            // paramOfCommand
            // 
            this.paramOfCommand.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.paramOfCommand.FillWeight = 70F;
            this.paramOfCommand.HeaderText = "Параметр";
            this.paramOfCommand.Name = "paramOfCommand";
            // 
            // descriptionOfCommand
            // 
            this.descriptionOfCommand.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descriptionOfCommand.HeaderText = "Описание";
            this.descriptionOfCommand.Name = "descriptionOfCommand";
            // 
            // resultOfCommand
            // 
            this.resultOfCommand.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.resultOfCommand.FillWeight = 45F;
            this.resultOfCommand.HeaderText = "Результат";
            this.resultOfCommand.Name = "resultOfCommand";
            this.resultOfCommand.ReadOnly = true;
            // 
            // command_cmb
            // 
            this.command_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.command_cmb.FormattingEnabled = true;
            this.command_cmb.Items.AddRange(new object[] {
            " ",
            "открыть окно ВД",
            "выполнить автозаполнение",
            "открыть классификатор",
            "перейти вперед",
            "нажать",
            "ввести значение",
            "перейти к графе номер",
            "подождать секунд",
            "группа:",
            "добавить товар",
            "перейти к первому товару"});
            this.command_cmb.Location = new System.Drawing.Point(10, 22);
            this.command_cmb.Name = "command_cmb";
            this.command_cmb.Size = new System.Drawing.Size(148, 21);
            this.command_cmb.TabIndex = 8;
            this.command_cmb.SelectedIndexChanged += new System.EventHandler(this.command_cmb_SelectedIndexChanged);
            // 
            // addCommand_btn
            // 
            this.addCommand_btn.Location = new System.Drawing.Point(164, 19);
            this.addCommand_btn.Name = "addCommand_btn";
            this.addCommand_btn.Size = new System.Drawing.Size(75, 25);
            this.addCommand_btn.TabIndex = 9;
            this.addCommand_btn.Text = "Добавить";
            this.addCommand_btn.UseVisualStyleBackColor = true;
            this.addCommand_btn.Click += new System.EventHandler(this.addCommand_btn_Click);
            // 
            // params_cmb
            // 
            this.params_cmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.params_cmb.FormattingEnabled = true;
            this.params_cmb.Items.AddRange(new object[] {
            "ENTER",
            "F5",
            "ESC",
            "F3",
            "стрелку влево",
            "стрелку вправо",
            "стрелку вверх",
            "стрелку вниз"});
            this.params_cmb.Location = new System.Drawing.Point(10, 53);
            this.params_cmb.Name = "params_cmb";
            this.params_cmb.Size = new System.Drawing.Size(148, 21);
            this.params_cmb.TabIndex = 10;
            this.params_cmb.Visible = false;
            // 
            // params_tb
            // 
            this.params_tb.Location = new System.Drawing.Point(10, 54);
            this.params_tb.Name = "params_tb";
            this.params_tb.Size = new System.Drawing.Size(148, 20);
            this.params_tb.TabIndex = 11;
            this.params_tb.Visible = false;
            // 
            // delCommand_btn
            // 
            this.delCommand_btn.Location = new System.Drawing.Point(164, 19);
            this.delCommand_btn.Name = "delCommand_btn";
            this.delCommand_btn.Size = new System.Drawing.Size(75, 23);
            this.delCommand_btn.TabIndex = 12;
            this.delCommand_btn.Text = "Удалить";
            this.delCommand_btn.UseVisualStyleBackColor = true;
            this.delCommand_btn.Click += new System.EventHandler(this.delCommand_btn_Click);
            // 
            // add_gb
            // 
            this.add_gb.Controls.Add(this.endGroup_btn);
            this.add_gb.Controls.Add(this.command_cmb);
            this.add_gb.Controls.Add(this.params_tb);
            this.add_gb.Controls.Add(this.addCommand_btn);
            this.add_gb.Controls.Add(this.params_cmb);
            this.add_gb.Location = new System.Drawing.Point(610, 42);
            this.add_gb.Name = "add_gb";
            this.add_gb.Size = new System.Drawing.Size(245, 86);
            this.add_gb.TabIndex = 13;
            this.add_gb.TabStop = false;
            this.add_gb.Text = "Добавление";
            // 
            // endGroup_btn
            // 
            this.endGroup_btn.Location = new System.Drawing.Point(164, 50);
            this.endGroup_btn.Name = "endGroup_btn";
            this.endGroup_btn.Size = new System.Drawing.Size(75, 25);
            this.endGroup_btn.TabIndex = 12;
            this.endGroup_btn.Text = "Конец";
            this.endGroup_btn.UseVisualStyleBackColor = true;
            this.endGroup_btn.Visible = false;
            this.endGroup_btn.Click += new System.EventHandler(this.endGroup_btn_Click);
            // 
            // del_gb
            // 
            this.del_gb.Controls.Add(this.delCommand_btn);
            this.del_gb.Location = new System.Drawing.Point(610, 134);
            this.del_gb.Name = "del_gb";
            this.del_gb.Size = new System.Drawing.Size(245, 56);
            this.del_gb.TabIndex = 14;
            this.del_gb.TabStop = false;
            this.del_gb.Text = "Удаление";
            // 
            // edit_gb
            // 
            this.edit_gb.Controls.Add(this.editComand_btn);
            this.edit_gb.Controls.Add(this.editCommand_tb);
            this.edit_gb.Location = new System.Drawing.Point(610, 197);
            this.edit_gb.Name = "edit_gb";
            this.edit_gb.Size = new System.Drawing.Size(245, 82);
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
            // treeViewOfScript
            // 
            this.treeViewOfScript.Location = new System.Drawing.Point(0, 0);
            this.treeViewOfScript.Name = "treeViewOfScript";
            this.treeViewOfScript.Size = new System.Drawing.Size(584, 188);
            this.treeViewOfScript.TabIndex = 17;
            // 
            // tabScripts
            // 
            this.tabScripts.Controls.Add(this.tabTreeViewScript);
            this.tabScripts.Controls.Add(this.tabTableScript);
            this.tabScripts.Location = new System.Drawing.Point(12, 27);
            this.tabScripts.Name = "tabScripts";
            this.tabScripts.SelectedIndex = 0;
            this.tabScripts.Size = new System.Drawing.Size(592, 214);
            this.tabScripts.TabIndex = 18;
            // 
            // tabTreeViewScript
            // 
            this.tabTreeViewScript.Controls.Add(this.treeViewOfScript);
            this.tabTreeViewScript.Location = new System.Drawing.Point(4, 22);
            this.tabTreeViewScript.Name = "tabTreeViewScript";
            this.tabTreeViewScript.Padding = new System.Windows.Forms.Padding(3);
            this.tabTreeViewScript.Size = new System.Drawing.Size(584, 188);
            this.tabTreeViewScript.TabIndex = 0;
            this.tabTreeViewScript.Text = "Древовидно";
            this.tabTreeViewScript.UseVisualStyleBackColor = true;
            // 
            // tabTableScript
            // 
            this.tabTableScript.Controls.Add(this.tableScript_dgv);
            this.tabTableScript.Location = new System.Drawing.Point(4, 22);
            this.tabTableScript.Name = "tabTableScript";
            this.tabTableScript.Padding = new System.Windows.Forms.Padding(3);
            this.tabTableScript.Size = new System.Drawing.Size(584, 188);
            this.tabTableScript.TabIndex = 1;
            this.tabTableScript.Text = "Таблично";
            this.tabTableScript.UseVisualStyleBackColor = true;
            // 
            // refresh_btn
            // 
            this.refresh_btn.Location = new System.Drawing.Point(529, 244);
            this.refresh_btn.Name = "refresh_btn";
            this.refresh_btn.Size = new System.Drawing.Size(75, 25);
            this.refresh_btn.TabIndex = 20;
            this.refresh_btn.Text = "Обновить";
            this.refresh_btn.UseVisualStyleBackColor = true;
            this.refresh_btn.Click += new System.EventHandler(this.refresh_btn_Click);
            // 
            // openFileGroup
            // 
            this.openFileGroup.FileName = "openFileDialog1";
            // 
            // DeleteAll_btn
            // 
            this.DeleteAll_btn.Location = new System.Drawing.Point(448, 244);
            this.DeleteAll_btn.Name = "DeleteAll_btn";
            this.DeleteAll_btn.Size = new System.Drawing.Size(75, 25);
            this.DeleteAll_btn.TabIndex = 21;
            this.DeleteAll_btn.Text = "Очистить";
            this.DeleteAll_btn.UseVisualStyleBackColor = true;
            this.DeleteAll_btn.Click += new System.EventHandler(this.DeleteAll_btn_Click);
            // 
            // DclTestFormWPy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 290);
            this.Controls.Add(this.DeleteAll_btn);
            this.Controls.Add(this.refresh_btn);
            this.Controls.Add(this.tabScripts);
            this.Controls.Add(this.fileName_lbl);
            this.Controls.Add(this.edit_gb);
            this.Controls.Add(this.del_gb);
            this.Controls.Add(this.add_gb);
            this.Controls.Add(this.startScript_btn);
            this.Controls.Add(this.listOfCommand);
            this.Controls.Add(this.chooseScript_btn);
            this.Controls.Add(this.scriptsTask_ms);
            this.MainMenuStrip = this.scriptsTask_ms;
            this.Name = "DclTestFormWPy";
            this.Text = "DclTest";
            this.scriptsTask_ms.ResumeLayout(false);
            this.scriptsTask_ms.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableScript_dgv)).EndInit();
            this.add_gb.ResumeLayout(false);
            this.add_gb.PerformLayout();
            this.del_gb.ResumeLayout(false);
            this.edit_gb.ResumeLayout(false);
            this.edit_gb.PerformLayout();
            this.tabScripts.ResumeLayout(false);
            this.tabTreeViewScript.ResumeLayout(false);
            this.tabTableScript.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button chooseScript_btn;
        private System.Windows.Forms.ListView listOfCommand;
        private System.Windows.Forms.TextBox editCommand_tb;
        private System.Windows.Forms.Button editComand_btn;
        private System.Windows.Forms.OpenFileDialog openFileScript;
        private System.Windows.Forms.Button startScript_btn;
        private System.Windows.Forms.MenuStrip scriptsTask_ms;
        private System.Windows.Forms.ToolStripMenuItem сценарийToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileScript;
        private System.Windows.Forms.DataGridView tableScript_dgv;
        private System.Windows.Forms.ComboBox command_cmb;
        private System.Windows.Forms.Button addCommand_btn;
        private System.Windows.Forms.ComboBox params_cmb;
        private System.Windows.Forms.TextBox params_tb;
        private System.Windows.Forms.Button delCommand_btn;
        private System.Windows.Forms.GroupBox add_gb;
        private System.Windows.Forms.GroupBox del_gb;
        private System.Windows.Forms.GroupBox edit_gb;
        private System.Windows.Forms.Label fileName_lbl;
        private System.Windows.Forms.TreeView treeViewOfScript;
        private System.Windows.Forms.Button endGroup_btn;
        private System.Windows.Forms.TabControl tabScripts;
        private System.Windows.Forms.TabPage tabTreeViewScript;
        private System.Windows.Forms.TabPage tabTableScript;
        private System.Windows.Forms.Button refresh_btn;
        private System.Windows.Forms.OpenFileDialog openFileGroup;
        private System.Windows.Forms.ToolStripMenuItem сценарийToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem группуToolStripMenuItem;
        private System.Windows.Forms.Button DeleteAll_btn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberOfCommand;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameOfCommand;
        private System.Windows.Forms.DataGridViewTextBoxColumn paramOfCommand;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionOfCommand;
        private System.Windows.Forms.DataGridViewTextBoxColumn resultOfCommand;
    }
}

