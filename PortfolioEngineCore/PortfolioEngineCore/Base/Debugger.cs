using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PortfolioEngineCore
{
    public class Debugger
    {
        private StringBuilder message = new StringBuilder();
        bool _debug = false;

        public Debugger(bool debug)
        {
            _debug = debug;
        }

        public void AddMessage(string msg)
        {
            if(_debug)
            {
                message.Append(DateTime.Now.ToString() + " - " + msg + "\r\n");
            }
        }

        public string GetMessage()
        {
            return message.ToString();
        }
    }
}
