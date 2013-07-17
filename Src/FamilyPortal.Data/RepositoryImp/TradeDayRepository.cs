using FamilyPortal.Data.InternalObjects;
using FamilyPortal.DomainModels;
using FamilyPortal.DomainModels.Entities;
using FamilyPortal.DomainModels.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace FamilyPortal.Data.RepositoryImp
{
    public class TradeDayRepository : ITradeDayRepository
    {
        public IEnumerable<stock_trade_day> GetAll(IAppContext appContext)
        {
            var entityContext = EntityModelHelper.GetEntityContext(appContext);
            var tradeDayList = entityContext.stock_trade_days
                                            .Select(td => td)
                                            .ToList();
            return tradeDayList;           
        }

        public stock_trade_day GetByDate(IAppContext appContext, DateTime date)
        {
            var entityContext = EntityModelHelper.GetEntityContext(appContext);
            var tradeDay = entityContext.stock_trade_days
                                        .Where(td => td.trade_date == date)
                                        .FirstOrDefault();
            return tradeDay;             
        }

        public void Remove(IAppContext appContext, stock_trade_day tradeDay)
        {
            var entityContext = EntityModelHelper.GetEntityContext(appContext);
            entityContext.stock_trade_days.Remove(tradeDay);
        }

        public void Add(IAppContext appContext, stock_trade_day tradeDay)
        {
            var entityContext = EntityModelHelper.GetEntityContext(appContext);
            entityContext.stock_trade_days.Add(tradeDay);
        }

		public IEnumerable<stock_trade_pair> GetTradePairList(IAppContext appContext, Expression<Func<stock_trade_pair, bool>> where)
		{
			var entityContext = EntityModelHelper.GetEntityContext(appContext);
			var tradePairList = entityContext.stock_trade_pairs.Include("stock_trade")
											 .Select(tp => tp)
											 .ToList();
			return tradePairList;
		}
    }
}