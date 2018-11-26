using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Currency
    {
        string from = "";
        string to = "";
        string rate = "";

        public string From
        {
            get { return from; }
            set { from = value; }
        }

        public string To
        {
            get { return to; }
            set { to = value; }
        }

        public string Rate
        {
            get { return rate; }
            set { rate = value; }
        }

    }
}
