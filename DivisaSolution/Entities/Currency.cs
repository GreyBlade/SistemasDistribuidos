using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [DataContract]
    public class Currency
    {
        string from = "";
        string to = "";
        string rate = "";

        [DataMember]
        public string From
        {
            get { return from; }
            set { from = value; }
        }

        [DataMember]
        public string To
        {
            get { return to; }
            set { to = value; }
        }
        [DataMember]
        public string Rate
        {
            get { return rate; }
            set { rate = value; }
        }

    }
}
