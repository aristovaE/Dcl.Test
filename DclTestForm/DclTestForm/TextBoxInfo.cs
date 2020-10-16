using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DclTestForm
{
    [DisplayName("Поле декларации")]
    public class TextBoxInfo
    {
        [Browsable(true)]
        [Description("Указатель в памяти")]
        public IntPtr handle
        {
            get;
            set;
        }
        [Browsable(true)]
        [Description("Содержимое поля")]
        public string caption
        {
            get;
            set;
        }
        //rect? coords? type???

        public TextBoxInfo(IntPtr handle, string caption)
        {
            this.handle = handle;
            this.caption = caption;
        }
    }
    
}
