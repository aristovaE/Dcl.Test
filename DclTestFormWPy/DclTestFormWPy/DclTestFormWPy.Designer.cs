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
            this.chooseScript_btn = new System.Windows.Forms.Button();
            this.listOfCommand = new System.Windows.Forms.ListView();
            this.editCommand_tb = new System.Windows.Forms.TextBox();
            this.editComand_btn = new System.Windows.Forms.Button();
            this.openFileScript = new System.Windows.Forms.OpenFileDialog();
            this.startScript_btn = new System.Windows.Forms.Button();
            this.scriptsTask_ms = new System.Windows.Forms.MenuStrip();
            this.сценарийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileScript = new System.Windows.Forms.SaveFileDialog();
            this.tableScript_dgv = new System.Windows.Forms.DataGridView();
            this.numberOfCommand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameOfCommand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paramOfCommand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resultOfCommand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.command_cmb = new System.Windows.Forms.ComboBox();
            this.addCommand_btn = new System.Windows.Forms.Button();
            this.params_cmb = new System.Windows.Forms.ComboBox();
            this.scriptsTask_ms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableScript_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // chooseScript_btn
            // 
            this.chooseScript_btn.Location = new System.Drawing.Point(12, 42);
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
            this.editCommand_tb.Location = new System.Drawing.Point(12, 213);
            this.editCommand_tb.Name = "editCommand_tb";
            this.editCommand_tb.Size = new System.Drawing.Size(148, 20);
            this.editCommand_tb.TabIndex = 2;
            // 
            // editComand_btn
            // 
            this.editComand_btn.Location = new System.Drawing.Point(166, 210);
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
            this.scriptsTask_ms.Size = new System.Drawing.Size(833, 24);
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
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
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
            this.tableScript_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tableScript_dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.tableScript_dgv.BackgroundColor = System.Drawing.SystemColors.Control;
            this.tableScript_dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tableScript_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableScript_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numberOfCommand,
            this.nameOfCommand,
            this.paramOfCommand,
            this.resultOfCommand});
            this.tableScript_dgv.Location = new System.Drawing.Point(247, 42);
            this.tableScript_dgv.Name = "tableScript_dgv";
            this.tableScript_dgv.Size = new System.Drawing.Size(574, 237);
            this.tableScript_dgv.TabIndex = 7;
            this.tableScript_dgv.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.tableScript_dgv_RowHeaderMouseClick);
            // 
            // numberOfCommand
            // 
            this.numberOfCommand.FillWeight = 40.60914F;
            this.numberOfCommand.HeaderText = "№";
            this.numberOfCommand.MinimumWidth = 15;
            this.numberOfCommand.Name = "numberOfCommand";
            this.numberOfCommand.ReadOnly = true;
            this.numberOfCommand.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // nameOfCommand
            // 
            this.nameOfCommand.FillWeight = 119.797F;
            this.nameOfCommand.HeaderText = "Команда";
            this.nameOfCommand.Name = "nameOfCommand";
            this.nameOfCommand.ReadOnly = true;
            // 
            // paramOfCommand
            // 
            this.paramOfCommand.FillWeight = 119.797F;
            this.paramOfCommand.HeaderText = "Параметр";
            this.paramOfCommand.Name = "paramOfCommand";
            // 
            // resultOfCommand
            // 
            this.resultOfCommand.FillWeight = 119.797F;
            this.resultOfCommand.HeaderText = "Результат";
            this.resultOfCommand.Name = "resultOfCommand";
            this.resultOfCommand.ReadOnly = true;
            // 
            // command_cmb
            // 
            this.command_cmb.FormattingEnabled = true;
            this.command_cmb.Items.AddRange(new object[] {
            "открыть окно ВД",
            "выполнить автозаполнение",
            "открыть классификатор",
            "перейти вперед",
            "нажать кнопку",
            "ввести значение",
            "перейти к графе номер",
            "подождать секунд"});
            this.command_cmb.Location = new System.Drawing.Point(12, 92);
            this.command_cmb.Name = "command_cmb";
            this.command_cmb.Size = new System.Drawing.Size(148, 21);
            this.command_cmb.TabIndex = 8;
            this.command_cmb.SelectedIndexChanged += new System.EventHandler(this.command_cmb_SelectedIndexChanged);
            // 
            // addCommand_btn
            // 
            this.addCommand_btn.Location = new System.Drawing.Point(166, 89);
            this.addCommand_btn.Name = "addCommand_btn";
            this.addCommand_btn.Size = new System.Drawing.Size(75, 25);
            this.addCommand_btn.TabIndex = 9;
            this.addCommand_btn.Text = "Добавить";
            this.addCommand_btn.UseVisualStyleBackColor = true;
            this.addCommand_btn.Click += new System.EventHandler(this.addCommand_btn_Click);
            // 
            // params_cmb
            // 
            this.params_cmb.FormattingEnabled = true;
            this.params_cmb.Items.AddRange(new object[] {
            "ENTER",
            "F5",
            "ESC",
            "F3",
            "стрелку влево",
            "стрелку вправо"});
            this.params_cmb.Location = new System.Drawing.Point(13, 120);
            this.params_cmb.Name = "params_cmb";
            this.params_cmb.Size = new System.Drawing.Size(147, 21);
            this.params_cmb.TabIndex = 10;
            this.params_cmb.Visible = false;
            // 
            // DclTestFormWPy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 306);
            this.Controls.Add(this.params_cmb);
            this.Controls.Add(this.addCommand_btn);
            this.Controls.Add(this.command_cmb);
            this.Controls.Add(this.tableScript_dgv);
            this.Controls.Add(this.startScript_btn);
            this.Controls.Add(this.editComand_btn);
            this.Controls.Add(this.editCommand_tb);
            this.Controls.Add(this.listOfCommand);
            this.Controls.Add(this.chooseScript_btn);
            this.Controls.Add(this.scriptsTask_ms);
            this.MainMenuStrip = this.scriptsTask_ms;
            this.Name = "DclTestFormWPy";
            this.Text = "DclTest";
            this.scriptsTask_ms.ResumeLayout(false);
            this.scriptsTask_ms.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableScript_dgv)).EndInit();
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
        private System.Windows.Forms.DataGridViewTextBoxColumn numberOfCommand;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameOfCommand;
        private System.Windows.Forms.DataGridViewTextBoxColumn paramOfCommand;
        private System.Windows.Forms.DataGridViewTextBoxColumn resultOfCommand;
        private System.Windows.Forms.ComboBox params_cmb;
    }
}

