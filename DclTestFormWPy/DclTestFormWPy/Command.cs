using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DclTestFormWPy
{
    public class Command
    {
       public int _id { get; set; }
        public string _strCommand { get; set; }
        public string _param { get; set; }
        public string _description { get; set; }
        public string _result { get; set; }

        public Command(int id, string strCommand, string param)
        {
            this._id = id;
            this._strCommand = strCommand;
            this._param = param;
        }
        public Command(string strCommand, string param)
        {
            this._strCommand = strCommand;
            this._param = param;
        }
        public Command(string strCommand)
        {
            this._strCommand = strCommand;
        }
    }

}
