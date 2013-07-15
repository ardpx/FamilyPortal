using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace FamilyPortal.Api.DataContracts
{
    [DataContract(Name = "resource")]
    public class ResourceDC
    {
        [DataMember(Name = "url")]
        public string URL { set; get; }
    }
}