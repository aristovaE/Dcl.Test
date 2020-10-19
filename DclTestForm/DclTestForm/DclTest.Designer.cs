namespace DclTestForm
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
            this.navigation_gb.SuspendLayout();
            this.SuspendLayout();
            // 
            // openDT_btn
            // 
            this.openDT_btn.Location = new System.Drawing.Point(305, 99);
            this.openDT_btn.Name = "openDT_btn";
            this.openDT_btn.Size = new System.Drawing.Size(75, 25);
            this.openDT_btn.TabIndex = 0;
            this.openDT_btn.Text = "Выполнить";
            this.openDT_btn.UseVisualStyleBackColor = true;
            this.openDT_btn.Click += new System.EventHandler(this.openDT_btn_Click);
            // 
            // enterKey_btn
            // 
            this.enterKey_btn.Location = new System.Drawing.Point(305, 130);
            this.enterKey_btn.Name = "enterKey_btn";
            this.enterKey_btn.Size = new System.Drawing.Size(75, 25);
            this.enterKey_btn.TabIndex = 1;
            this.enterKey_btn.Text = "Ввести";
            this.enterKey_btn.UseVisualStyleBackColor = true;
            this.enterKey_btn.Click += new System.EventHandler(this.enterKey_btn_Click);
            // 
            // doAll_btn
            // 
            this.doAll_btn.Location = new System.Drawing.Point(305, 161);
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
            this.openDT_lbl.Location = new System.Drawing.Point(22, 105);
            this.openDT_lbl.Name = "openDT_lbl";
            this.openDT_lbl.Size = new System.Drawing.Size(70, 13);
            this.openDT_lbl.TabIndex = 3;
            this.openDT_lbl.Text = "Открыть ДТ";
            // 
            // enterKey_lbl
            // 
            this.enterKey_lbl.AutoSize = true;
            this.enterKey_lbl.Location = new System.Drawing.Point(22, 136);
            this.enterKey_lbl.Name = "enterKey_lbl";
            this.enterKey_lbl.Size = new System.Drawing.Size(87, 13);
            this.enterKey_lbl.TabIndex = 4;
            this.enterKey_lbl.Text = "Поле для ввода";
            // 
            // doAll_lbl
            // 
            this.doAll_lbl.AutoSize = true;
            this.doAll_lbl.Location = new System.Drawing.Point(22, 167);
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
            this.howToOpenDT_cmb.Location = new System.Drawing.Point(115, 102);
            this.howToOpenDT_cmb.Name = "howToOpenDT_cmb";
            this.howToOpenDT_cmb.Size = new System.Drawing.Size(184, 21);
            this.howToOpenDT_cmb.TabIndex = 9;
            // 
            // enterKey_tb
            // 
            this.enterKey_tb.Location = new System.Drawing.Point(115, 133);
            this.enterKey_tb.Name = "enterKey_tb";
            this.enterKey_tb.Size = new System.Drawing.Size(184, 20);
            this.enterKey_tb.TabIndex = 10;
            // 
            // showAllTextBoxes_btn
            // 
            this.showAllTextBoxes_btn.Location = new System.Drawing.Point(103, 207);
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
            this.controlList.Location = new System.Drawing.Point(25, 238);
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
            this.navigation_gb.Location = new System.Drawing.Point(25, 9);
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
            this.propertyOfControl.Location = new System.Drawing.Point(184, 243);
            this.propertyOfControl.Name = "propertyOfControl";
            this.propertyOfControl.Size = new System.Drawing.Size(196, 130);
            this.propertyOfControl.TabIndex = 19;
            this.propertyOfControl.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyOfControl_PropertyValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 218);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Все поля ДТ";
            // 
            // findAndRenameNext_btn
            // 
            this.findAndRenameNext_btn.Location = new System.Drawing.Point(287, 207);
            this.findAndRenameNext_btn.Name = "findAndRenameNext_btn";
            this.findAndRenameNext_btn.Size = new System.Drawing.Size(93, 23);
            this.findAndRenameNext_btn.TabIndex = 22;
            this.findAndRenameNext_btn.Text = "СТМ ->  Город";
            this.findAndRenameNext_btn.UseVisualStyleBackColor = true;
            this.findAndRenameNext_btn.Click += new System.EventHandler(this.findAndRenameNext_btn_Click);
            // 
            // getWindowRect_btn
            // 
            this.getWindowRect_btn.Location = new System.Drawing.Point(23, 391);
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
            this.label2.Location = new System.Drawing.Point(133, 396);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = " ";
            // 
            // DclTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 451);
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
    }
}

