using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace storeAssist.UI
{
    public class ValidationInfoDTO
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _message;

        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }

        public ValidationInfoDTO( string msg)
        {
           //this. _name = name;
           this.Message = msg;
        }
    }
}
