using FamilyPortal.Api.InternalObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace FamilyPortal.Api.DataContracts
{
    [DataContract(Name = "tradeDay", Namespace = "")]
    public class TradeDayDC
    {
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public int? Id { set; get; }

        [DataMember(Name = "date", EmitDefaultValue = false)]
        public DateTime? Date { set; get; }

        [DataMember(Name = "tradePairs", EmitDefaultValue = false)]
        public TradePairDCList TradePairList { set; get; }

        [DataMember(Name = "summary", EmitDefaultValue = false)]
        [DefaultValue(ApiConstants.STRING_DEFAULT_VALUE)]
        public string Summary { set; get; }

        [DataMember(Name = "profitAndLoss", EmitDefaultValue = false)]
        public int ProfitAndLoss {set; get;}

        [DataMember(Name = "tradePairCount", EmitDefaultValue = false)]
        public int TradePairCount { set; get; }

        [DataMember(Name = "tradeCount", EmitDefaultValue = false)]
        public int TradeCount { set; get; }
    }

    [CollectionDataContract(Name = "tradeDays", ItemName = "tradeDay", Namespace = "")]
    public class TradeDayDCList : List<TradeDayDC>
    {
        public TradeDayDCList()
            : base()
        {
        }
    }
}