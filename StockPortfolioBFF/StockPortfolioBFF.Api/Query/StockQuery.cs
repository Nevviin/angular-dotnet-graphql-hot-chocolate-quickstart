using System.Collections;
using static StockPortfolioBFF.Api.Types.Types;
using GetStockByTickerUseCase = StockPortfolioBFF.Application.Stocks.GetStockByTicker;

namespace StockPortfolioBFF.Api.Query
{
    [QueryType]
    public class StockQuery
    {

        public async Task<Stock> GetStockByTicker(string ticker,
           [Service] GetStockByTickerUseCase operation,
              CancellationToken cancellationToken = default
            )
        {
            var stock = await operation.ExecuteAsync(ticker, cancellationToken);
            return new Stock(
                Ticker: stock.Ticker,
                CompanyName: stock.CompanyName,
                CurrentPrice: stock.CurrentPrice,
                DailyChangePercent: (double)stock.DailyChangePercent
            );
        }




        public Stock GetStockByTickerMock(string ticker)
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
