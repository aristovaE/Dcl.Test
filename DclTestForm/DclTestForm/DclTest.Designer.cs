﻿namespace DclTestForm
{
    partial class DclTestForm
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
            this.nextControl_btn = new System.Windows.Forms.Button();
            this.nextControl_lbl = new System.Windows.Forms.Label();
            this.howToOpenDT_cmb = new System.Windows.Forms.ComboBox();
            this.enterKey_tb = new System.Windows.Forms.TextBox();
            this.showAllTextBoxes_btn = new System.Windows.Forms.Button();
            this.editTextBox_btn = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // openDT_btn
            // 
            this.openDT_btn.Location = new System.Drawing.Point(248, 60);
            this.openDT_btn.Name = "openDT_btn";
            this.openDT_btn.Size = new System.Drawing.Size(90, 30);
            this.openDT_btn.TabIndex = 0;
            this.openDT_btn.Text = "Выполнить";
            this.openDT_btn.UseVisualStyleBackColor = true;
            this.openDT_btn.Click += new System.EventHandler(this.openDT_btn_Click);
            // 
            // enterKey_btn
            // 
            this.enterKey_btn.Location = new System.Drawing.Point(248, 96);
            this.enterKey_btn.Name = "enterKey_btn";
            this.enterKey_btn.Size = new System.Drawing.Size(90, 30);
            this.enterKey_btn.TabIndex = 1;
            this.enterKey_btn.Text = "Ввести";
            this.enterKey_btn.UseVisualStyleBackColor = true;
            this.enterKey_btn.Click += new System.EventHandler(this.enterKey_btn_Click);
            // 
            // doAll_btn
            // 
            this.doAll_btn.Location = new System.Drawing.Point(248, 132);
            this.doAll_btn.Name = "doAll_btn";
            this.doAll_btn.Size = new System.Drawing.Size(90, 30);
            this.doAll_btn.TabIndex = 2;
            this.doAll_btn.Text = "Выполнить";
            this.doAll_btn.UseVisualStyleBackColor = true;
            this.doAll_btn.Click += new System.EventHandler(this.doAll_btn_Click);
            // 
            // openDT_lbl
            // 
            this.openDT_lbl.AutoSize = true;
            this.openDT_lbl.Location = new System.Drawing.Point(22, 69);
            this.openDT_lbl.Name = "openDT_lbl";
            this.openDT_lbl.Size = new System.Drawing.Size(70, 13);
            this.openDT_lbl.TabIndex = 3;
            this.openDT_lbl.Text = "Открыть ДТ";
            // 
            // enterKey_lbl
            // 
            this.enterKey_lbl.AutoSize = true;
            this.enterKey_lbl.Location = new System.Drawing.Point(22, 105);
            this.enterKey_lbl.Name = "enterKey_lbl";
            this.enterKey_lbl.Size = new System.Drawing.Size(87, 13);
            this.enterKey_lbl.TabIndex = 4;
            this.enterKey_lbl.Text = "Поле для ввода";
            // 
            // doAll_lbl
            // 
            this.doAll_lbl.AutoSize = true;
            this.doAll_lbl.Location = new System.Drawing.Point(22, 141);
            this.doAll_lbl.Name = "doAll_lbl";
            this.doAll_lbl.Size = new System.Drawing.Size(84, 13);
            this.doAll_lbl.TabIndex = 5;
            this.doAll_lbl.Text = "Выполнить всё";
            // 
            // nextControl_btn
            // 
            this.nextControl_btn.Location = new System.Drawing.Point(248, 12);
            this.nextControl_btn.Name = "nextControl_btn";
            this.nextControl_btn.Size = new System.Drawing.Size(90, 30);
            this.nextControl_btn.TabIndex = 7;
            this.nextControl_btn.Text = "Перейти";
            this.nextControl_btn.UseVisualStyleBackColor = true;
            this.nextControl_btn.Click += new System.EventHandler(this.nextControl_btn_Click);
            // 
            // nextControl_lbl
            // 
            this.nextControl_lbl.AutoSize = true;
            this.nextControl_lbl.Location = new System.Drawing.Point(22, 21);
            this.nextControl_lbl.Name = "nextControl_lbl";
            this.nextControl_lbl.Size = new System.Drawing.Size(93, 13);
            this.nextControl_lbl.TabIndex = 8;
            this.nextControl_lbl.Text = "Следующее поле";
            // 
            // howToOpenDT_cmb
            // 
            this.howToOpenDT_cmb.FormattingEnabled = true;
            this.howToOpenDT_cmb.Items.AddRange(new object[] {
            "Комбинациями клавиш",
            "Координатами"});
            this.howToOpenDT_cmb.Location = new System.Drawing.Point(121, 66);
            this.howToOpenDT_cmb.Name = "howToOpenDT_cmb";
            this.howToOpenDT_cmb.Size = new System.Drawing.Size(121, 21);
            this.howToOpenDT_cmb.TabIndex = 9;
            // 
            // enterKey_tb
            // 
            this.enterKey_tb.Location = new System.Drawing.Point(121, 102);
            this.enterKey_tb.Name = "enterKey_tb";
            this.enterKey_tb.Size = new System.Drawing.Size(121, 20);
            this.enterKey_tb.TabIndex = 10;
            // 
            // showAllTextBoxes_btn
            // 
            this.showAllTextBoxes_btn.Location = new System.Drawing.Point(248, 185);
            this.showAllTextBoxes_btn.Name = "showAllTextBoxes_btn";
            this.showAllTextBoxes_btn.Size = new System.Drawing.Size(90, 30);
            this.showAllTextBoxes_btn.TabIndex = 11;
            this.showAllTextBoxes_btn.Text = "Вывести";
            this.showAllTextBoxes_btn.UseVisualStyleBackColor = true;
            this.showAllTextBoxes_btn.Click += new System.EventHandler(this.showAllTextBoxes_btn_Click);
            // 
            // editTextBox_btn
            // 
            this.editTextBox_btn.Location = new System.Drawing.Point(249, 221);
            this.editTextBox_btn.Name = "editTextBox_btn";
            this.editTextBox_btn.Size = new System.Drawing.Size(89, 30);
            this.editTextBox_btn.TabIndex = 13;
            this.editTextBox_btn.Text = "Ввести";
            this.editTextBox_btn.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(25, 185);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(217, 122);
            this.listView1.TabIndex = 14;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            // 
            // DclTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 319);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.editTextBox_btn);
            this.Controls.Add(this.showAllTextBoxes_btn);
            this.Controls.Add(this.enterKey_tb);
            this.Controls.Add(this.howToOpenDT_cmb);
            this.Controls.Add(this.nextControl_lbl);
            this.Controls.Add(this.nextControl_btn);
            this.Controls.Add(this.doAll_lbl);
            this.Controls.Add(this.enterKey_lbl);
            this.Controls.Add(this.openDT_lbl);
            this.Controls.Add(this.doAll_btn);
            this.Controls.Add(this.enterKey_btn);
            this.Controls.Add(this.openDT_btn);
            this.Name = "DclTestForm";
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
        private System.Windows.Forms.Button nextControl_btn;
        private System.Windows.Forms.Label nextControl_lbl;
        private System.Windows.Forms.ComboBox howToOpenDT_cmb;
        private System.Windows.Forms.TextBox enterKey_tb;
        private System.Windows.Forms.Button showAllTextBoxes_btn;
        private System.Windows.Forms.Button editTextBox_btn;
        private System.Windows.Forms.ListView listView1;
    }
}

