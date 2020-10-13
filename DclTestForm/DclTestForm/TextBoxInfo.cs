using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DclTestForm
{
    class TextBoxInfo
    {
        IntPtr handle;
        string caption;
        //rect? coords? type???

        public TextBoxInfo(IntPtr handle, string caption)
        {
            this.handle = handle;
            this.caption = caption;
        }
    }
    
}
