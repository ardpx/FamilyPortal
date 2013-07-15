using FamilyPortal.Api.DataContracts;
using FamilyPortal.DomainModels.Entities;
using FamilyPortal.DomainModels.Factories;
using FamilyPortal.DomainModels.Repositories;
using FamilyPortal.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FamilyPortal.Api.Services
{
    public class TradeDayService
    {
        private ITradeDayRepository _TradeDayRepository;

        public TradeDayService()
        {
        }

        public TradeDayService(ITradeDayRepository tradeDayRepository)
            : this()
        {
            _TradeDayRepository = tradeDayRepository;
        }

        public TradeDayDCList GetGenericTradeDayData()
        {
            var tradeDayList = _TradeDayRepository.GetAll(WebAppContext.Current);
            var tradeDayDCList = new TradeDayDCList();
            foreach (var tradeDay in tradeDayList)
            {
                var tradeDayDC = ToDataContract(tradeDay);
                tradeDayDCList.Add(tradeDayDC);
            }
            return tradeDayDCList;
        }

        public stock_trade_day AddTradeDay(TradeDayDC tradeDayDC)
        {
            if (tradeDayDC.Date == null)
                throw new Exception("Date of trade day is null");
            var newTradeDay = TradeDayFactory.CreateTradeDay(tradeDayDC.Date.Value, tradeDayDC.Summary, _TradeDayRepository, WebAppContext.Current);
            
            foreach(var tradePairDC in tradeDayDC.TradePairList)
            {
                var newTradePair = newTradeDay.AddTradePair(tradePairDC.Symbol, tradePairDC.Summary, tradePairDC.Attachment);
                foreach(var tradeDC in tradePairDC.TradeList)
                {
                    if (tradeDC.Share == null)
                        throw new Exception("share shall not be null");
                    if (tradeDC.Price == null)
                        throw new Exception("Price shall not be null");
                    newTradeDay.AddTrade(newTradePair, TimeSpan.Parse(tradeDC.Time), ConvertTradeType(tradeDC.Type), tradeDC.Action == "buy" ? 0 : 1,
                                         tradeDC.Share.Value, tradeDC.Price.Value, tradeDC.Summary);
                }
                newTradePair.UpdateShare();
                newTradePair.CalculateProfitAndLoss();
            }
            newTradeDay.CalculateProfitAndLoss();
            return null;

        }

        public int ConvertTradeType(string type)
        {
            switch (type)
            {
                case "limit": return 0;
                case "market": return 1;
                case "trail": return 2;
                case "stop": return 3;
                case "stoplimit": return 4;
                default: throw new Exception("trade type is invalid");
            }
        }

        public TradeDayDC ToDataContract(stock_trade_day tradeDay)
        {
            var tradeDayDC = new TradeDayDC
            {
                Date = tradeDay.trade_date,
                Summary = tradeDay.summary,
                ProfitAndLoss = tradeDay.profit_loss,
                TradePairCount = tradeDay.trade_pairs.Count(),
                TradeCount = tradeDay.trade_pairs.SelectMany(tp => tp.trades).Count()
            };
            return tradeDayDC;
        }
    }
}