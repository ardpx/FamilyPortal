using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyPortal.DomainModels.Entities
{
    public partial class stock_trade_day
    {
        public stock_trade_pair AddTradePair(string symbol, string summary, string attachmentPath)
        {
            var newTradePair = new stock_trade_pair()
            {
                symbol = symbol,
                summary = summary,
                attachment_uri = attachmentPath,
                profit_loss = 0,
                spread = 0.00D,
                share = 0
            };

            this.trade_pairs.Add(newTradePair);
            return newTradePair;
        }

        public stock_trade AddTrade(stock_trade_pair tradePair, TimeSpan time, int type, int action, int share, double price, string summary)
        {
            var newTrade = new stock_trade
            {
                time = time,
                type = type,
                action = action,
                share = share,
                price = price,
                summary = summary
            };

            tradePair.trades.Add(newTrade);
            return newTrade;
        }

        public void CalculateProfitAndLoss()
        {
            profit_loss = this.trade_pairs.Select(tp => tp.profit_loss).Sum();
        }
    }
}
