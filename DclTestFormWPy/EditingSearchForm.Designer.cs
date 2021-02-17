
namespace DclTestFormWPy
{
    partial class EditingSearchForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.search_gb = new System.Windows.Forms.GroupBox();
            this.search_tb = new System.Windows.Forms.TextBox();
            this.ClearSearch_btn = new System.Windows.Forms.Button();
            this.Search_btn = new System.Windows.Forms.Button();
            this.add_gb = new System.Windows.Forms.GroupBox();
            this.y_lbl = new System.Windows.Forms.Label();
            this.x_lbl = new System.Windows.Forms.Label();
            this.CoordY_tb = new System.Windows.Forms.TextBox();
            this.CoordX_tb = new System.Windows.Forms.TextBox();
            this.EndGroup_btn = new System.Windows.Forms.Button();
            this.Command_cmb = new System.Windows.Forms.ComboBox();
            this.Params_tb = new System.Windows.Forms.TextBox();
            this.addCommand_btn = new System.Windows.Forms.Button();
            this.Params_cmb = new System.Windows.Forms.ComboBox();
            this.del_gb = new System.Windows.Forms.GroupBox();
            this.DeleteCommand_btn = new System.Windows.Forms.Button();
            this.edit_gb = new System.Windows.Forms.GroupBox();
            this.EditComand_btn = new System.Windows.Forms.Button();
            this.EditCommand_tb = new System.Windows.Forms.TextBox();
            this.DeleteAll_btn = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.search_gb.SuspendLayout();
            this.add_gb.SuspendLayout();
            this.del_gb.SuspendLayout();
            this.edit_gb.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.search_gb);
            this.panel2.Controls.Add(this.add_gb);
            this.panel2.Controls.Add(this.del_gb);
            this.panel2.Controls.Add(this.edit_gb);
            this.panel2.Controls.Add(this.DeleteAll_btn);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(273, 246);
            this.panel2.TabIndex = 29;
            this.panel2.Visible = false;
            // 
            // search_gb
            // 
            this.search_gb.Controls.Add(this.search_tb);
            this.search_gb.Controls.Add(this.ClearSearch_btn);
            this.search_gb.Controls.Add(this.Search_btn);
            this.search_gb.Location = new System.Drawing.Point(3, 6);
            this.search_gb.Name = "search_gb";
            this.search_gb.Size = new System.Drawing.Size(245, 86);
            this.search_gb.TabIndex = 17;
            this.search_gb.TabStop = false;
            this.search_gb.Text = "Введите слово для поиска в сценарии";
            this.search_gb.Visible = false;
            // 
            // search_tb
            // 
            this.search_tb.Location = new System.Drawing.Point(6, 22);
            this.search_tb.Name = "search_tb";
            this.search_tb.Size = new System.Drawing.Size(152, 20);
            this.search_tb.TabIndex = 13;
            // 
            // ClearSearch_btn
            // 
            this.ClearSearch_btn.Location = new System.Drawing.Point(164, 50);
            this.ClearSearch_btn.Name = "ClearSearch_btn";
            this.ClearSearch_btn.Size = new System.Drawing.Size(75, 25);
            this.ClearSearch_btn.TabIndex = 12;
            this.ClearSearch_btn.Text = "Очистить";
            this.ClearSearch_btn.UseVisualStyleBackColor = true;
            this.ClearSearch_btn.Visible = false;
            // 
            // Search_btn
            // 
            this.Search_btn.Location = new System.Drawing.Point(164, 19);
            this.Search_btn.Name = "Search_btn";
            this.Search_btn.Size = new System.Drawing.Size(75, 25);
            this.Search_btn.TabIndex = 9;
            this.Search_btn.Text = "Поиск";
            this.Search_btn.UseVisualStyleBackColor = true;
            this.Search_btn.Click += new System.EventHandler(this.Search_btn_Click);
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
            this.add_gb.Location = new System.Drawing.Point(6, 6);
            this.add_gb.Name = "add_gb";
            this.add_gb.Size = new System.Drawing.Size(245, 86);
            this.add_gb.TabIndex = 13;
            this.add_gb.TabStop = false;
            this.add_gb.Text = "Добавление";
            this.add_gb.Visible = false;
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
            // CoordY_tb
            // 
            this.CoordY_tb.Location = new System.Drawing.Point(113, 53);
            this.CoordY_tb.Name = "CoordY_tb";
            this.CoordY_tb.Size = new System.Drawing.Size(45, 20);
            this.CoordY_tb.TabIndex = 14;
            this.CoordY_tb.Visible = false;
            // 
            // CoordX_tb
            // 
            this.CoordX_tb.Location = new System.Drawing.Point(34, 53);
            this.CoordX_tb.Name = "CoordX_tb";
            this.CoordX_tb.Size = new System.Drawing.Size(45, 20);
            this.CoordX_tb.TabIndex = 13;
            this.CoordX_tb.Visible = false;
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
            "нажать в точке",
            "",
            "прочитать из XML",
            "записать в XML",
            "прочитать из СТМ",
            "записать в СТМ"});
            this.Command_cmb.Location = new System.Drawing.Point(10, 22);
            this.Command_cmb.Name = "Command_cmb";
            this.Command_cmb.Size = new System.Drawing.Size(148, 21);
            this.Command_cmb.TabIndex = 8;
            // 
            // Params_tb
            // 
            this.Params_tb.Location = new System.Drawing.Point(10, 53);
            this.Params_tb.Name = "Params_tb";
            this.Params_tb.Size = new System.Drawing.Size(148, 20);
            this.Params_tb.TabIndex = 11;
            this.Params_tb.Visible = false;
            // 
            // addCommand_btn
            // 
            this.addCommand_btn.Location = new System.Drawing.Point(164, 19);
            this.addCommand_btn.Name = "addCommand_btn";
            this.addCommand_btn.Size = new System.Drawing.Size(75, 25);
            this.addCommand_btn.TabIndex = 9;
            this.addCommand_btn.Text = "Добавить";
            this.addCommand_btn.UseVisualStyleBackColor = true;
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
            // del_gb
            // 
            this.del_gb.Controls.Add(this.DeleteCommand_btn);
            this.del_gb.Location = new System.Drawing.Point(6, 98);
            this.del_gb.Name = "del_gb";
            this.del_gb.Size = new System.Drawing.Size(245, 56);
            this.del_gb.TabIndex = 14;
            this.del_gb.TabStop = false;
            this.del_gb.Text = "Удаление";
            this.del_gb.Visible = false;
            // 
            // DeleteCommand_btn
            // 
            this.DeleteCommand_btn.Location = new System.Drawing.Point(164, 19);
            this.DeleteCommand_btn.Name = "DeleteCommand_btn";
            this.DeleteCommand_btn.Size = new System.Drawing.Size(75, 23);
            this.DeleteCommand_btn.TabIndex = 12;
            this.DeleteCommand_btn.Text = "Удалить";
            this.DeleteCommand_btn.UseVisualStyleBackColor = true;
            // 
            // edit_gb
            // 
            this.edit_gb.Controls.Add(this.EditComand_btn);
            this.edit_gb.Controls.Add(this.EditCommand_tb);
            this.edit_gb.Location = new System.Drawing.Point(6, 161);
            this.edit_gb.Name = "edit_gb";
            this.edit_gb.Size = new System.Drawing.Size(245, 73);
            this.edit_gb.TabIndex = 15;
            this.edit_gb.TabStop = false;
            this.edit_gb.Text = "Редактирование";
            this.edit_gb.Visible = false;
            // 
            // EditComand_btn
            // 
            this.EditComand_btn.Location = new System.Drawing.Point(164, 16);
            this.EditComand_btn.Name = "EditComand_btn";
            this.EditComand_btn.Size = new System.Drawing.Size(75, 25);
            this.EditComand_btn.TabIndex = 3;
            this.EditComand_btn.Text = "Изменить";
            this.EditComand_btn.UseVisualStyleBackColor = true;
            // 
            // EditCommand_tb
            // 
            this.EditCommand_tb.Location = new System.Drawing.Point(10, 19);
            this.EditCommand_tb.Name = "EditCommand_tb";
            this.EditCommand_tb.Size = new System.Drawing.Size(148, 20);
            this.EditCommand_tb.TabIndex = 2;
            // 
            // DeleteAll_btn
            // 
            this.DeleteAll_btn.Location = new System.Drawing.Point(176, 261);
            this.DeleteAll_btn.Name = "DeleteAll_btn";
            this.DeleteAll_btn.Size = new System.Drawing.Size(75, 25);
            this.DeleteAll_btn.TabIndex = 21;
            this.DeleteAll_btn.Text = "Очистить";
            this.DeleteAll_btn.UseVisualStyleBackColor = true;
            this.DeleteAll_btn.Visible = false;
            // 
            // EditingSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 272);
            this.Controls.Add(this.panel2);
            this.Name = "EditingSearchForm";
            this.Text = "EditingSearchForm";
            this.panel2.ResumeLayout(false);
            this.search_gb.ResumeLayout(false);
            this.search_gb.PerformLayout();
            this.add_gb.ResumeLayout(false);
            this.add_gb.PerformLayout();
            this.del_gb.ResumeLayout(false);
            this.edit_gb.ResumeLayout(false);
            this.edit_gb.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox search_gb;
        private System.Windows.Forms.TextBox search_tb;
        private System.Windows.Forms.Button ClearSearch_btn;
        private System.Windows.Forms.Button Search_btn;
        private System.Windows.Forms.GroupBox add_gb;
        private System.Windows.Forms.Label y_lbl;
        private System.Windows.Forms.Label x_lbl;
        private System.Windows.Forms.TextBox CoordY_tb;
        private System.Windows.Forms.TextBox CoordX_tb;
        private System.Windows.Forms.Button EndGroup_btn;
        private System.Windows.Forms.ComboBox Command_cmb;
        private System.Windows.Forms.TextBox Params_tb;
        private System.Windows.Forms.Button addCommand_btn;
        private System.Windows.Forms.ComboBox Params_cmb;
        private System.Windows.Forms.GroupBox del_gb;
        private System.Windows.Forms.Button DeleteCommand_btn;
        private System.Windows.Forms.GroupBox edit_gb;
        private System.Windows.Forms.Button EditComand_btn;
        private System.Windows.Forms.TextBox EditCommand_tb;
        private System.Windows.Forms.Button DeleteAll_btn;
    }
}