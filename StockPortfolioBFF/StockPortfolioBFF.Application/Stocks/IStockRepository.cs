using StockPortfolioBFF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockPortfolioBFF.Application.Stocks
{
    public interface IStockRepository
    {
        Task<Stock> GetByTickerAsync(string ticker, CancellationToken cancellationToken= default);
    }
}
