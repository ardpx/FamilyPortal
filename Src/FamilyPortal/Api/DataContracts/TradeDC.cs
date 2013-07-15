using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using System.ComponentModel;
using FamilyPortal.Api.InternalObjects;

namespace FamilyPortal.Api.DataContracts
{
    [DataContract(Name = "trade", Namespace = "")]
    public class TradeDC
    {
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public int? Id { set; get; }
       
        [DataMember(Name = "action", EmitDefaultValue = false)]
        [DefaultValue(ApiConstants.STRING_DEFAULT_VALUE)]
        public string Action { set; get; }

        [DataMember(Name = "type", EmitDefaultValue = false)]
        [DefaultValue(ApiConstants.STRING_DEFAULT_VALUE)]
        public string Type { set; get; }

        [DataMember(Name = "time", EmitDefaultValue = false)]
        public string Time { set; get; }

        [DataMember(Name = "share", EmitDefaultValue = false)]
        public int? Share { set; get; }

        [DataMember(Name = "price", EmitDefaultValue = false)]
        public double? Price { set; get; }

        [DataMember(Name = "summary", EmitDefaultValue = false)]
        [DefaultValue(ApiConstants.STRING_DEFAULT_VALUE)]
        public string Summary { set; get; }
    }

    [CollectionDataContract(Name = "trades", ItemName = "trade", Namespace = "")]
    public class TradeDCList : List<TradeDC>
    {
        public TradeDCList()
            : base()
        {
        }
    }
}