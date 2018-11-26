using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace HostInfoService
{
    [DataContract]
    public class HostInfo
    {
        [DataMember]
        public string ip { get; set; }
        [DataMember]
        public string OsVersion { get; set; }
        [DataMember]
        public string HostName { get; set; }

    }
}