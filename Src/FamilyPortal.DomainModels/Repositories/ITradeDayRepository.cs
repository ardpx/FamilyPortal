using FamilyPortal.DomainModels.Entities;
using FamilyPortal.DomainModels.InternalObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyPortal.DomainModels.Repositories
{
    public interface ITradeDayRepository
    {
        IEnumerable<stock_trade_day> GetAll(IAppContext appContext);

        stock_trade_day GetByDate(IAppContext appContext , DateTime date);

        void Remove(IAppContext appContext, stock_trade_day tradeDay);

        void Add(IAppContext appContext, stock_trade_day tradeDay);
    }
}
