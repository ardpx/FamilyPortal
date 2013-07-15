using FamilyPortal.DomainModels.Entities;
using FamilyPortal.DomainModels.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyPortal.DomainModels.Factories
{
    public class TradeDayFactory
    {
        public static stock_trade_day CreateTradeDay(DateTime date, string summary, ITradeDayRepository _TradeDayRepository, IAppContext appContext)
        {
            var existingTradeDay = _TradeDayRepository.GetByDate(appContext, date);
            if (existingTradeDay != null)
            {
                _TradeDayRepository.Remove(appContext, existingTradeDay);
            }
            var newTradeDay = new stock_trade_day
            {
                trade_date = date,
                summary = summary
            };

            _TradeDayRepository.Add(appContext, newTradeDay);

            return newTradeDay;

        }
    }
}
