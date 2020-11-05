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
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileScript = new System.Windows.Forms.SaveFileDialog();
            this.scriptsTask_ms.SuspendLayout();
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
            this.chooseScript_btn.Click += new System.EventHandler(this.chooseScript_btn_Click);
            // 
            // listOfCommand
            // 
            this.listOfCommand.HideSelection = false;
            this.listOfCommand.Location = new System.Drawing.Point(257, 42);
            this.listOfCommand.Name = "listOfCommand";
            this.listOfCommand.Size = new System.Drawing.Size(263, 237);
            this.listOfCommand.TabIndex = 1;
            this.listOfCommand.UseCompatibleStateImageBehavior = false;
            this.listOfCommand.View = System.Windows.Forms.View.List;
            this.listOfCommand.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listOfCommand_MouseClick);
            // 
            // editCommand_tb
            // 
            this.editCommand_tb.Location = new System.Drawing.Point(12, 109);
            this.editCommand_tb.Name = "editCommand_tb";
            this.editCommand_tb.Size = new System.Drawing.Size(148, 20);
            this.editCommand_tb.TabIndex = 2;
            // 
            // editComand_btn
            // 
            this.editComand_btn.Location = new System.Drawing.Point(166, 106);
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
            this.startScript_btn.Location = new System.Drawing.Point(166, 42);
            this.startScript_btn.Name = "startScript_btn";
            this.startScript_btn.Size = new System.Drawing.Size(75, 27);
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
            this.scriptsTask_ms.Size = new System.Drawing.Size(539, 24);
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
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // DclTestFormWPy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 306);
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
    }
}

