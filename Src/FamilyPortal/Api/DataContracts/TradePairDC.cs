using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using FamilyPortal.Api.InternalObjects;
using System.ComponentModel;

namespace FamilyPortal.Api.DataContracts
{
    [DataContract(Name = "tradePair", Namespace = "")]
    public class TradePairDC
    {
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public int? Id { set; get; }

        [DataMember(Name = "symbol", EmitDefaultValue = false)]
        [DefaultValue(ApiConstants.STRING_DEFAULT_VALUE)]
        public string Symbol { set; get; }

        [DataMember(Name = "trades", EmitDefaultValue = false)]
        public TradeDCList TradeList { set; get; }

        [DataMember(Name = "summary", EmitDefaultValue = false)]
        [DefaultValue(ApiConstants.STRING_DEFAULT_VALUE)]
        public string Summary { set; get; }

        [DataMember(Name = "attachment", EmitDefaultValue = false)]
        [DefaultValue(ApiConstants.STRING_DEFAULT_VALUE)]
        public string Attachment { set; get; }

        [DataMember(Name = "profitAndLoss", EmitDefaultValue = false)]
        public int? ProfitAndLoss { set; get; }
    }



    [CollectionDataContract(Name = "tradePairs", ItemName = "tradePair", Namespace = "")]
    public class TradePairDCList : List<TradePairDC>
    {
        public TradePairDCList()
            : base()
        {
        }
    }
}