using System;
using System.Collections.Generic;
using System.Text;

namespace StockPortfolioBFF.Domain.Entities
{
    public sealed record Stock
    (
        string Ticker,
        string CompanyName,
        decimal CurrentPrice,
        decimal DailyChangePercent

    );
}
