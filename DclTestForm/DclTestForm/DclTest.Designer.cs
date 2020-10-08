namespace DclTestForm
{
    partial class DclTest
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
            this.openDT_btn = new System.Windows.Forms.Button();
            this.enterKey_btn = new System.Windows.Forms.Button();
            this.doAll_btn = new System.Windows.Forms.Button();
            this.openDT_lbl = new System.Windows.Forms.Label();
            this.enterKey_lbl = new System.Windows.Forms.Label();
            this.doAll_lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // openDT_btn
            // 
            this.openDT_btn.Location = new System.Drawing.Point(112, 63);
            this.openDT_btn.Name = "openDT_btn";
            this.openDT_btn.Size = new System.Drawing.Size(90, 30);
            this.openDT_btn.TabIndex = 0;
            this.openDT_btn.Text = "Выполнить";
            this.openDT_btn.UseVisualStyleBackColor = true;
            this.openDT_btn.Click += new System.EventHandler(this.openDT_btn_Click);
            // 
            // enterKey_btn
            // 
            this.enterKey_btn.Location = new System.Drawing.Point(112, 99);
            this.enterKey_btn.Name = "enterKey_btn";
            this.enterKey_btn.Size = new System.Drawing.Size(90, 30);
            this.enterKey_btn.TabIndex = 1;
            this.enterKey_btn.Text = "Выполнить";
            this.enterKey_btn.UseVisualStyleBackColor = true;
            this.enterKey_btn.Click += new System.EventHandler(this.enterKey_btn_Click);
            // 
            // doAll_btn
            // 
            this.doAll_btn.Location = new System.Drawing.Point(112, 135);
            this.doAll_btn.Name = "doAll_btn";
            this.doAll_btn.Size = new System.Drawing.Size(90, 30);
            this.doAll_btn.TabIndex = 2;
            this.doAll_btn.Text = "Выполнить";
            this.doAll_btn.UseVisualStyleBackColor = true;
            // 
            // openDT_lbl
            // 
            this.openDT_lbl.AutoSize = true;
            this.openDT_lbl.Location = new System.Drawing.Point(13, 72);
            this.openDT_lbl.Name = "openDT_lbl";
            this.openDT_lbl.Size = new System.Drawing.Size(70, 13);
            this.openDT_lbl.TabIndex = 3;
            this.openDT_lbl.Text = "Открыть ДТ";
            // 
            // enterKey_lbl
            // 
            this.enterKey_lbl.AutoSize = true;
            this.enterKey_lbl.Location = new System.Drawing.Point(13, 108);
            this.enterKey_lbl.Name = "enterKey_lbl";
            this.enterKey_lbl.Size = new System.Drawing.Size(74, 13);
            this.enterKey_lbl.TabIndex = 4;
            this.enterKey_lbl.Text = "Ввести \"333\"";
            // 
            // doAll_lbl
            // 
            this.doAll_lbl.AutoSize = true;
            this.doAll_lbl.Location = new System.Drawing.Point(13, 144);
            this.doAll_lbl.Name = "doAll_lbl";
            this.doAll_lbl.Size = new System.Drawing.Size(84, 13);
            this.doAll_lbl.TabIndex = 5;
            this.doAll_lbl.Text = "Выполнить всё";
            // 
            // DclTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(218, 183);
            this.Controls.Add(this.doAll_lbl);
            this.Controls.Add(this.enterKey_lbl);
            this.Controls.Add(this.openDT_lbl);
            this.Controls.Add(this.doAll_btn);
            this.Controls.Add(this.enterKey_btn);
            this.Controls.Add(this.openDT_btn);
            this.Name = "DclTest";
            this.Text = "DclTest";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openDT_btn;
        private System.Windows.Forms.Button enterKey_btn;
        private System.Windows.Forms.Button doAll_btn;
        private System.Windows.Forms.Label openDT_lbl;
        private System.Windows.Forms.Label enterKey_lbl;
        private System.Windows.Forms.Label doAll_lbl;
    }
}

