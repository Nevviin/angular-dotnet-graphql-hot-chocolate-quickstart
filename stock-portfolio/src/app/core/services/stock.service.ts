import { HttpClient } from '@angular/common/http';
import { Injectable, Service } from '@angular/core';
import { map, Observable } from 'rxjs';


export interface StockQuote {
    symbol: string;
    name?: string;
    price?: number;
    change?: number;
}

interface StockQueryResponse {
    data?: {
        stock?: StockQuote | null;
    };
}


// @Service()
@Injectable({ providedIn: 'root' })
export class StockService {

    constructor(private readonly http: HttpClient) { }

    getStock(symbol: string): Observable<any> {
        {
            return this.http.post<any>('http://localhost:5289/graphql', {
                query: `
    query StockByTicker($ticker: String!) {
      stockByTicker(ticker: $ticker) {
        ticker
        companyName
        currentPrice
        dailyChangePercent
      }
    }
  `,
                variables: {
                    ticker: symbol
                }
            }).pipe(
                map((response) => {
                    const item = response?.data?.stockByTicker;

                    if (!item) {
                        return null;
                    }

                    return {
                        symbol: item.ticker,
                        name: item.companyName,
                        price: item.currentPrice,
                        change: item.dailyChangePercent,
                    };
                })
            );

        }
    }
}

