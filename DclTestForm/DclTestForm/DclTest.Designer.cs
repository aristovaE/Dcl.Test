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
            this.nextControlDT_btn = new System.Windows.Forms.Button();
            this.nextControlDT_lbl = new System.Windows.Forms.Label();
            this.howToOpenDT_cmb = new System.Windows.Forms.ComboBox();
            this.enterKey_tb = new System.Windows.Forms.TextBox();
            this.showAllTextBoxes_btn = new System.Windows.Forms.Button();
            this.controlList = new System.Windows.Forms.ListView();
            this.navigation_gb = new System.Windows.Forms.GroupBox();
            this.showOnPropGrid_btn = new System.Windows.Forms.Button();
            this.prevControlDT_btn = new System.Windows.Forms.Button();
            this.propertyOfControl = new System.Windows.Forms.PropertyGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.findAndRenameNext_btn = new System.Windows.Forms.Button();
            this.getWindowRect_btn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.startScript1_btn = new System.Windows.Forms.Button();
            this.resultOf1 = new System.Windows.Forms.Label();
            this.startScript2_btn = new System.Windows.Forms.Button();
            this.resultOf2 = new System.Windows.Forms.Label();
            this.resultOf3 = new System.Windows.Forms.Label();
            this.startScript3_btn = new System.Windows.Forms.Button();
            this.resultOf4 = new System.Windows.Forms.Label();
            this.startScript4_btn = new System.Windows.Forms.Button();
            this.chooseScript_btn = new System.Windows.Forms.Button();
            this.openFileScript = new System.Windows.Forms.OpenFileDialog();
            this.navigation_gb.SuspendLayout();
            this.SuspendLayout();
            // 
            // openDT_btn
            // 
            this.openDT_btn.Location = new System.Drawing.Point(294, 107);
            this.openDT_btn.Name = "openDT_btn";
            this.openDT_btn.Size = new System.Drawing.Size(75, 25);
            this.openDT_btn.TabIndex = 0;
            this.openDT_btn.Text = "Выполнить";
            this.openDT_btn.UseVisualStyleBackColor = true;
            this.openDT_btn.Click += new System.EventHandler(this.openDT_btn_Click);
            // 
            // enterKey_btn
            // 
            this.enterKey_btn.Location = new System.Drawing.Point(294, 138);
            this.enterKey_btn.Name = "enterKey_btn";
            this.enterKey_btn.Size = new System.Drawing.Size(75, 25);
            this.enterKey_btn.TabIndex = 1;
            this.enterKey_btn.Text = "Ввести";
            this.enterKey_btn.UseVisualStyleBackColor = true;
            this.enterKey_btn.Click += new System.EventHandler(this.enterKey_btn_Click);
            // 
            // doAll_btn
            // 
            this.doAll_btn.Location = new System.Drawing.Point(213, 169);
            this.doAll_btn.Name = "doAll_btn";
            this.doAll_btn.Size = new System.Drawing.Size(75, 25);
            this.doAll_btn.TabIndex = 2;
            this.doAll_btn.Text = "Выполнить";
            this.doAll_btn.UseVisualStyleBackColor = true;
            this.doAll_btn.Click += new System.EventHandler(this.doAll_btn_Click);
            // 
            // openDT_lbl
            // 
            this.openDT_lbl.AutoSize = true;
            this.openDT_lbl.Location = new System.Drawing.Point(11, 113);
            this.openDT_lbl.Name = "openDT_lbl";
            this.openDT_lbl.Size = new System.Drawing.Size(70, 13);
            this.openDT_lbl.TabIndex = 3;
            this.openDT_lbl.Text = "Открыть ДТ";
            // 
            // enterKey_lbl
            // 
            this.enterKey_lbl.AutoSize = true;
            this.enterKey_lbl.Location = new System.Drawing.Point(11, 144);
            this.enterKey_lbl.Name = "enterKey_lbl";
            this.enterKey_lbl.Size = new System.Drawing.Size(87, 13);
            this.enterKey_lbl.TabIndex = 4;
            this.enterKey_lbl.Text = "Поле для ввода";
            // 
            // doAll_lbl
            // 
            this.doAll_lbl.AutoSize = true;
            this.doAll_lbl.Location = new System.Drawing.Point(11, 175);
            this.doAll_lbl.Name = "doAll_lbl";
            this.doAll_lbl.Size = new System.Drawing.Size(84, 13);
            this.doAll_lbl.TabIndex = 5;
            this.doAll_lbl.Text = "Выполнить всё";
            // 
            // nextControlDT_btn
            // 
            this.nextControlDT_btn.Location = new System.Drawing.Point(142, 29);
            this.nextControlDT_btn.Name = "nextControlDT_btn";
            this.nextControlDT_btn.Size = new System.Drawing.Size(36, 25);
            this.nextControlDT_btn.TabIndex = 7;
            this.nextControlDT_btn.Text = "→";
            this.nextControlDT_btn.UseVisualStyleBackColor = true;
            this.nextControlDT_btn.Click += new System.EventHandler(this.nextControl_btn_Click);
            // 
            // nextControlDT_lbl
            // 
            this.nextControlDT_lbl.AutoSize = true;
            this.nextControlDT_lbl.Location = new System.Drawing.Point(20, 35);
            this.nextControlDT_lbl.Name = "nextControlDT_lbl";
            this.nextControlDT_lbl.Size = new System.Drawing.Size(108, 13);
            this.nextControlDT_lbl.TabIndex = 8;
            this.nextControlDT_lbl.Text = "полям декларацаии";
            // 
            // howToOpenDT_cmb
            // 
            this.howToOpenDT_cmb.FormattingEnabled = true;
            this.howToOpenDT_cmb.Items.AddRange(new object[] {
            "Комбинациями клавиш",
            "Координатами"});
            this.howToOpenDT_cmb.Location = new System.Drawing.Point(104, 110);
            this.howToOpenDT_cmb.Name = "howToOpenDT_cmb";
            this.howToOpenDT_cmb.Size = new System.Drawing.Size(184, 21);
            this.howToOpenDT_cmb.TabIndex = 9;
            // 
            // enterKey_tb
            // 
            this.enterKey_tb.Location = new System.Drawing.Point(104, 141);
            this.enterKey_tb.Name = "enterKey_tb";
            this.enterKey_tb.Size = new System.Drawing.Size(184, 20);
            this.enterKey_tb.TabIndex = 10;
            // 
            // showAllTextBoxes_btn
            // 
            this.showAllTextBoxes_btn.Location = new System.Drawing.Point(92, 215);
            this.showAllTextBoxes_btn.Name = "showAllTextBoxes_btn";
            this.showAllTextBoxes_btn.Size = new System.Drawing.Size(75, 25);
            this.showAllTextBoxes_btn.TabIndex = 11;
            this.showAllTextBoxes_btn.Text = "Вывести";
            this.showAllTextBoxes_btn.UseVisualStyleBackColor = true;
            this.showAllTextBoxes_btn.Click += new System.EventHandler(this.showAllTextBoxes_btn_Click);
            // 
            // controlList
            // 
            this.controlList.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.controlList.HideSelection = false;
            this.controlList.Location = new System.Drawing.Point(14, 246);
            this.controlList.Name = "controlList";
            this.controlList.Size = new System.Drawing.Size(153, 134);
            this.controlList.TabIndex = 14;
            this.controlList.UseCompatibleStateImageBehavior = false;
            this.controlList.View = System.Windows.Forms.View.List;
            this.controlList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.controlList_MouseClick);
            // 
            // navigation_gb
            // 
            this.navigation_gb.Controls.Add(this.showOnPropGrid_btn);
            this.navigation_gb.Controls.Add(this.prevControlDT_btn);
            this.navigation_gb.Controls.Add(this.nextControlDT_btn);
            this.navigation_gb.Controls.Add(this.nextControlDT_lbl);
            this.navigation_gb.Location = new System.Drawing.Point(14, 17);
            this.navigation_gb.Name = "navigation_gb";
            this.navigation_gb.Size = new System.Drawing.Size(355, 75);
            this.navigation_gb.TabIndex = 18;
            this.navigation_gb.TabStop = false;
            this.navigation_gb.Text = "Навигация по:";
            // 
            // showOnPropGrid_btn
            // 
            this.showOnPropGrid_btn.Location = new System.Drawing.Point(243, 29);
            this.showOnPropGrid_btn.Name = "showOnPropGrid_btn";
            this.showOnPropGrid_btn.Size = new System.Drawing.Size(75, 25);
            this.showOnPropGrid_btn.TabIndex = 20;
            this.showOnPropGrid_btn.Text = "Показать";
            this.showOnPropGrid_btn.UseVisualStyleBackColor = true;
            this.showOnPropGrid_btn.Click += new System.EventHandler(this.showOnPropGrid_btn_Click);
            // 
            // prevControlDT_btn
            // 
            this.prevControlDT_btn.Location = new System.Drawing.Point(181, 29);
            this.prevControlDT_btn.Name = "prevControlDT_btn";
            this.prevControlDT_btn.Size = new System.Drawing.Size(36, 25);
            this.prevControlDT_btn.TabIndex = 19;
            this.prevControlDT_btn.Text = "←";
            this.prevControlDT_btn.UseVisualStyleBackColor = true;
            this.prevControlDT_btn.Click += new System.EventHandler(this.prevControlDT_btn_Click);
            // 
            // propertyOfControl
            // 
            this.propertyOfControl.Location = new System.Drawing.Point(173, 251);
            this.propertyOfControl.Name = "propertyOfControl";
            this.propertyOfControl.Size = new System.Drawing.Size(196, 130);
            this.propertyOfControl.TabIndex = 19;
            this.propertyOfControl.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyOfControl_PropertyValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 226);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Все поля ДТ";
            // 
            // findAndRenameNext_btn
            // 
            this.findAndRenameNext_btn.Location = new System.Drawing.Point(294, 169);
            this.findAndRenameNext_btn.Name = "findAndRenameNext_btn";
            this.findAndRenameNext_btn.Size = new System.Drawing.Size(75, 25);
            this.findAndRenameNext_btn.TabIndex = 22;
            this.findAndRenameNext_btn.Text = "Замена";
            this.findAndRenameNext_btn.UseVisualStyleBackColor = true;
            this.findAndRenameNext_btn.Click += new System.EventHandler(this.findAndRenameNext_btn_Click);
            // 
            // getWindowRect_btn
            // 
            this.getWindowRect_btn.Location = new System.Drawing.Point(12, 399);
            this.getWindowRect_btn.Name = "getWindowRect_btn";
            this.getWindowRect_btn.Size = new System.Drawing.Size(86, 23);
            this.getWindowRect_btn.TabIndex = 23;
            this.getWindowRect_btn.Text = "Данные окна";
            this.getWindowRect_btn.UseVisualStyleBackColor = true;
            this.getWindowRect_btn.Click += new System.EventHandler(this.getWindowRect_btn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(122, 404);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = " ";
            // 
            // startScript1_btn
            // 
            this.startScript1_btn.Location = new System.Drawing.Point(401, 17);
            this.startScript1_btn.Name = "startScript1_btn";
            this.startScript1_btn.Size = new System.Drawing.Size(92, 39);
            this.startScript1_btn.TabIndex = 28;
            this.startScript1_btn.Text = "Сценарий 1.1";
            this.startScript1_btn.UseVisualStyleBackColor = true;
            this.startScript1_btn.Click += new System.EventHandler(this.startScript1_Click);
            // 
            // resultOf1
            // 
            this.resultOf1.AutoSize = true;
            this.resultOf1.Location = new System.Drawing.Point(375, 59);
            this.resultOf1.Name = "resultOf1";
            this.resultOf1.Size = new System.Drawing.Size(62, 13);
            this.resultOf1.TabIndex = 27;
            this.resultOf1.Text = "Результат:";
            // 
            // startScript2_btn
            // 
            this.startScript2_btn.Location = new System.Drawing.Point(401, 100);
            this.startScript2_btn.Name = "startScript2_btn";
            this.startScript2_btn.Size = new System.Drawing.Size(92, 39);
            this.startScript2_btn.TabIndex = 29;
            this.startScript2_btn.Text = "Сценарий 1.2";
            this.startScript2_btn.UseVisualStyleBackColor = true;
            this.startScript2_btn.Click += new System.EventHandler(this.startScript2_Click);
            // 
            // resultOf2
            // 
            this.resultOf2.AutoSize = true;
            this.resultOf2.Location = new System.Drawing.Point(375, 144);
            this.resultOf2.Name = "resultOf2";
            this.resultOf2.Size = new System.Drawing.Size(62, 13);
            this.resultOf2.TabIndex = 30;
            this.resultOf2.Text = "Результат:";
            // 
            // resultOf3
            // 
            this.resultOf3.AutoSize = true;
            this.resultOf3.Location = new System.Drawing.Point(375, 231);
            this.resultOf3.Name = "resultOf3";
            this.resultOf3.Size = new System.Drawing.Size(62, 13);
            this.resultOf3.TabIndex = 32;
            this.resultOf3.Text = "Результат:";
            // 
            // startScript3_btn
            // 
            this.startScript3_btn.Location = new System.Drawing.Point(401, 189);
            this.startScript3_btn.Name = "startScript3_btn";
            this.startScript3_btn.Size = new System.Drawing.Size(92, 39);
            this.startScript3_btn.TabIndex = 31;
            this.startScript3_btn.Text = "Сценарий 1.3";
            this.startScript3_btn.UseVisualStyleBackColor = true;
            this.startScript3_btn.Click += new System.EventHandler(this.startScript3_Click);
            // 
            // resultOf4
            // 
            this.resultOf4.AutoSize = true;
            this.resultOf4.Location = new System.Drawing.Point(515, 59);
            this.resultOf4.Name = "resultOf4";
            this.resultOf4.Size = new System.Drawing.Size(62, 13);
            this.resultOf4.TabIndex = 34;
            this.resultOf4.Text = "Результат:";
            // 
            // startScript4_btn
            // 
            this.startScript4_btn.Location = new System.Drawing.Point(541, 17);
            this.startScript4_btn.Name = "startScript4_btn";
            this.startScript4_btn.Size = new System.Drawing.Size(92, 39);
            this.startScript4_btn.TabIndex = 33;
            this.startScript4_btn.Text = "Сценарий 2.1";
            this.startScript4_btn.UseVisualStyleBackColor = true;
            this.startScript4_btn.Click += new System.EventHandler(this.startScript4_btn_Click);
            // 
            // chooseScript_btn
            // 
            this.chooseScript_btn.Location = new System.Drawing.Point(390, 339);
            this.chooseScript_btn.Name = "chooseScript_btn";
            this.chooseScript_btn.Size = new System.Drawing.Size(156, 41);
            this.chooseScript_btn.TabIndex = 36;
            this.chooseScript_btn.Text = "Выбрать сценарий";
            this.chooseScript_btn.UseVisualStyleBackColor = true;
            this.chooseScript_btn.Click += new System.EventHandler(this.chooseScript_btn_Click);
            // 
            // openFileScript
            // 
            this.openFileScript.FileName = "openFileDialog1";
            // 
            // DclTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 436);
            this.Controls.Add(this.chooseScript_btn);
            this.Controls.Add(this.resultOf4);
            this.Controls.Add(this.startScript4_btn);
            this.Controls.Add(this.resultOf3);
            this.Controls.Add(this.startScript3_btn);
            this.Controls.Add(this.resultOf2);
            this.Controls.Add(this.startScript2_btn);
            this.Controls.Add(this.startScript1_btn);
            this.Controls.Add(this.resultOf1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.getWindowRect_btn);
            this.Controls.Add(this.findAndRenameNext_btn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.propertyOfControl);
            this.Controls.Add(this.navigation_gb);
            this.Controls.Add(this.controlList);
            this.Controls.Add(this.showAllTextBoxes_btn);
            this.Controls.Add(this.enterKey_tb);
            this.Controls.Add(this.howToOpenDT_cmb);
            this.Controls.Add(this.doAll_lbl);
            this.Controls.Add(this.enterKey_lbl);
            this.Controls.Add(this.openDT_lbl);
            this.Controls.Add(this.doAll_btn);
            this.Controls.Add(this.enterKey_btn);
            this.Controls.Add(this.openDT_btn);
            this.Name = "DclTestForm";
            this.Text = "DclTest";
            this.navigation_gb.ResumeLayout(false);
            this.navigation_gb.PerformLayout();
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
        private System.Windows.Forms.Button nextControlDT_btn;
        private System.Windows.Forms.Label nextControlDT_lbl;
        private System.Windows.Forms.ComboBox howToOpenDT_cmb;
        private System.Windows.Forms.TextBox enterKey_tb;
        private System.Windows.Forms.Button showAllTextBoxes_btn;
        private System.Windows.Forms.ListView controlList;
        private System.Windows.Forms.GroupBox navigation_gb;
        private System.Windows.Forms.PropertyGrid propertyOfControl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button prevControlDT_btn;
        private System.Windows.Forms.Button showOnPropGrid_btn;
        private System.Windows.Forms.Button findAndRenameNext_btn;
        private System.Windows.Forms.Button getWindowRect_btn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button startScript1_btn;
        private System.Windows.Forms.Label resultOf1;
        private System.Windows.Forms.Button startScript2_btn;
        private System.Windows.Forms.Label resultOf2;
        private System.Windows.Forms.Label resultOf3;
        private System.Windows.Forms.Button startScript3_btn;
        private System.Windows.Forms.Label resultOf4;
        private System.Windows.Forms.Button startScript4_btn;
        private System.Windows.Forms.Button chooseScript_btn;
        private System.Windows.Forms.OpenFileDialog openFileScript;
    }
}

