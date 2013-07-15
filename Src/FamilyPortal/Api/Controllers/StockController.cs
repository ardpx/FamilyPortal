using FamilyPortal.Api.DataContracts;
using FamilyPortal.Api.Services;
using FamilyPortal.Data.RepositoryImp;
using FamilyPortal.DomainModels.Repositories;
using FamilyPortal.Infrastructures;
using FamilyPortal.Utilites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FamilyPortal.Api.Controllers
{
    public class StockController : ApiController
    {
        private ITradeDayRepository _TradeDayRepository ;
        private TradeDayService _TradeDayService;
        public StockController()
            : base()
        {
             _TradeDayRepository = new TradeDayRepository();
             _TradeDayService = new TradeDayService(_TradeDayRepository);
        }
       
        #region five classic RESTful APIs

        ///  GET api/stock
        /// <summary>
        /// Get all stock trade days
        /// </summary>
        /// <returns>List of Resource objects</returns>
        [ActionName("DefaultWebApiAction")]
        public TradeDayDCList Get()
        {
            return _TradeDayService.GetGenericTradeDayData();
        }

        /// POST api/stock
        /// <summary>
        /// Create new resource object
        /// </summary>
        /// <param name="value">new resource data</param>
        [ActionName("DefaultWebApiAction")]
        public void Post([FromBody]TradeDayDCList tradeDays)
        {
            try
            {
                foreach (var tradeDay in tradeDays)
                {
                    _TradeDayService.AddTradeDay(tradeDay);
                }
                WebAppContext.Current.Commit();
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }
        }

        #endregion
    }
}
