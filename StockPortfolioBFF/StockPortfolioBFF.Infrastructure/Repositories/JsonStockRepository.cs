using StockPortfolioBFF.Application.Stocks;
using StockPortfolioBFF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace StockPortfolioBFF.Infrastructure.Repositories
{
    public sealed class JsonStockRepository : IStockRepository
    {
        private readonly string _filePath;

        public JsonStockRepository(string filePath)
        {
            _filePath = filePath;

        }


        public async Task<Stock> GetByTickerAsync(
            string ticker,
            CancellationToken cancellationToken = default
            )
        {
            await using var stream = File.OpenRead(_filePath);

            var stocks = await JsonSerializer.DeserializeAsync<List<Stock>>(stream,
                cancellationToken: cancellationToken
                );

            if (stocks is null)
            {
                throw new InvalidDataException($"The StockData file {_filePath} didnot contain a stock list.");
            }

            var stock =  stocks.FirstOrDefault(stock => string.Equals(stock.Ticker, ticker, StringComparison.OrdinalIgnoreCase));

            return stock ?? throw new KeyNotFoundException($"Stock with ticker '{ticker}' not found.");

        }

    }
}
