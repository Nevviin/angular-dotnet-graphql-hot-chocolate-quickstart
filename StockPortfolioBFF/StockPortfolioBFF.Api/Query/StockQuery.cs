using System.Collections;
using static StockPortfolioBFF.Api.Types.Types;

namespace StockPortfolioBFF.Api.Query
{
    [QueryType]
    public class StockQuery
    {
        public Stock GetStockByTicker(string ticker)
        {
            return new Stock(
                Ticker: ticker,
                CompanyName: "Example 2 Company",
                CurrentPrice: 123.45m,
                DailyChangePercent: 1.23
            );
        }
    }
}
