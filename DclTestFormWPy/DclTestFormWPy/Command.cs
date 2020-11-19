using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DclTestFormWPy
{
    class Command
    {
        int _id;
        string _strCommand;
        string _param;

        public Command(int id, string strCommand, string param)
        {
            _id = id;
            _strCommand = strCommand;
            _param = param;
        }
    }

}
