using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyPortal.DomainModels.Entities
{
    public partial class stock_trade_pair
    {
        public void UpdateShare()
        {
            int totalShares = this.trades.Select(t => t.share).Sum();
            share = totalShares / 2;
        }

        public void CalculateProfitAndLoss()
        {
            int amountBought = (int)this.trades.Where(t => t.action == 0).Sum(t => t.price * t.share);
            int amountSold = (int)this.trades.Where(t => t.action == 1).Sum(t => t.price * t.share);
			profit_loss = amountSold - amountBought;
            spread = profit_loss / share; 
        }
    }
}
