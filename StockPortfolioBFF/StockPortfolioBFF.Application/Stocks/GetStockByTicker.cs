using StockPortfolioBFF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockPortfolioBFF.Application.Stocks
{
    public sealed class GetStockByTicker
    {
        private readonly IStockRepository _stockRepository;

        public GetStockByTicker(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;

        }

        public Task<Stock> ExecuteAsync(
            string ticker,
            CancellationToken cancellationToken = default)
        {
            return _stockRepository.GetByTickerAsync(ticker, cancellationToken);
        }
    }
}
