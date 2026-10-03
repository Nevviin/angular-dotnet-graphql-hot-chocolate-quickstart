namespace StockPortfolioBFF.Api.Types
{
    public class Types
    {
        public record Stock(
        string Ticker,
        string CompanyName,
        decimal CurrentPrice,
        double DailyChangePercent
        );
    }
}
