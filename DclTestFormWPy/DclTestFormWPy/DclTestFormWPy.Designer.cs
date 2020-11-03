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
            this.SuspendLayout();
            // 
            // chooseScript_btn
            // 
            this.chooseScript_btn.Location = new System.Drawing.Point(12, 42);
            this.chooseScript_btn.Name = "chooseScript_btn";
            this.chooseScript_btn.Size = new System.Drawing.Size(128, 38);
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
            // 
            // editCommand_tb
            // 
            this.editCommand_tb.Location = new System.Drawing.Point(12, 257);
            this.editCommand_tb.Name = "editCommand_tb";
            this.editCommand_tb.Size = new System.Drawing.Size(158, 20);
            this.editCommand_tb.TabIndex = 2;
            this.editCommand_tb.Visible = false;
            // 
            // editComand_btn
            // 
            this.editComand_btn.Location = new System.Drawing.Point(176, 254);
            this.editComand_btn.Name = "editComand_btn";
            this.editComand_btn.Size = new System.Drawing.Size(75, 25);
            this.editComand_btn.TabIndex = 3;
            this.editComand_btn.Text = "Изменить";
            this.editComand_btn.UseVisualStyleBackColor = true;
            this.editComand_btn.Visible = false;
            // 
            // openFileScript
            // 
            this.openFileScript.FileName = "openFileDialog1";
            // 
            // startScript_btn
            // 
            this.startScript_btn.Location = new System.Drawing.Point(445, 12);
            this.startScript_btn.Name = "startScript_btn";
            this.startScript_btn.Size = new System.Drawing.Size(75, 23);
            this.startScript_btn.TabIndex = 4;
            this.startScript_btn.Text = "Выполнить";
            this.startScript_btn.UseVisualStyleBackColor = true;
            this.startScript_btn.Click += new System.EventHandler(this.startScript_btn_Click);
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
            this.Name = "DclTestFormWPy";
            this.Text = "DclTest";
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
    }
}

