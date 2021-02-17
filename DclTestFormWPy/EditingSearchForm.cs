using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DclTestFormWPy
{
    public partial class EditingSearchForm : Form
    {
        public EditingSearchForm(bool IsEdit)
        {
            InitializeComponent();
        }

        private void Search_btn_Click(object sender, EventArgs e)
        {
            //    if (search_tb.Text != "")
            //    {
            //        string search = search_tb.Text;
            //        if (TableScript_dgv.Rows.Count != 0)
            //        {
            //            for (int numOfCommand = 0; numOfCommand < TableScript_dgv.Rows.Count; numOfCommand++)
            //            {
            //                if (TableScript_dgv.Rows[numOfCommand].Cells[1].Value.ToString().Contains(search))
            //                {
            //                    TableScript_dgv.Rows[numOfCommand].Selected = true;
            //                }
            //                else if (TableScript_dgv.Rows[numOfCommand].Cells[2].Value != null)
            //                {
            //                    if (TableScript_dgv.Rows[numOfCommand].Cells[2].Value.ToString().Contains(search))
            //                    {
            //                        TableScript_dgv.Rows[numOfCommand].Selected = true;
            //                    }
            //                }

            //            }
            //            ClearSearch_btn.Visible = true;
            //        }
            //        else MessageBox.Show("Не открыт ни один сценарий!");
            //    }
            //    else MessageBox.Show("Строка поиска пуста!");
            //
        }
    }
}
