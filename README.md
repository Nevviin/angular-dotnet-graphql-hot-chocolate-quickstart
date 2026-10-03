# Stock Portfolio

A small full-stack stock portfolio starter with an Angular frontend and an ASP.NET Core backend. The backend exposes a GraphQL API using Hot Chocolate and reads stock data from a JSON file.

## Projects

- `stock-portfolio` — Angular user interface for looking up a stock ticker.
- `StockPortfolioBFF` — .NET 10 backend, organized into API, Application, Domain, and Infrastructure projects.

## Requirements

- Node.js and npm
- .NET 10 SDK

## Run locally

Start the backend from the repository root:

```powershell
dotnet run --project .\StockPortfolioBFF\StockPortfolioBFF.Api --launch-profile http
```

The backend listens at `http://localhost:5289`; its GraphQL endpoint is `http://localhost:5289/graphql`.

In a second terminal, start Angular:

```powershell
Set-Location .\stock-portfolio
npm install
npm start
```

Open `http://localhost:4200`, enter a ticker such as `AAPL`, and select **Load stock**.

## How the application is organized

### Angular frontend

The Angular app groups the dashboard UI as a feature and keeps GraphQL communication in a service:

- The dashboard template displays the ticker input, button, loading/error messages, and stock result.
- The dashboard component handles user actions and tracks view state with Angular signals.
- `StockService` sends the GraphQL request to the backend and maps the response for the UI.

The frontend request flow is:

```text
Dashboard template → Dashboard component → StockService → GraphQL API
```

### .NET backend

The backend uses a Clean Architecture-inspired, four-project structure:

- **Api** hosts ASP.NET Core and Hot Chocolate. Its GraphQL resolver calls the Application operation.
- **Application** contains the stock lookup operation and the `IStockRepository` contract it needs.
- **Domain** contains the core `Stock` type, independent of GraphQL and JSON storage.
- **Infrastructure** implements `IStockRepository` by reading stock data from the JSON file.

The backend request flow is:

```text
GraphQL resolver → Application operation → IStockRepository
    → JSON repository → stock data
```

The dependency direction points inward: Domain has no project dependencies; Application depends on Domain; Infrastructure implements Application's repository contract; and Api connects the layers. Application and Domain do not depend on GraphQL or the JSON implementation.

## Example GraphQL query

You can run this at `http://localhost:5289/graphql`:

```graphql
query {
  stockByTicker(ticker: "AAPL") {
    ticker
    companyName
    currentPrice
    dailyChangePercent
  }
}
```
