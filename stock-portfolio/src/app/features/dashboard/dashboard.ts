import { Component, signal } from '@angular/core';
import { StockQuote, StockService } from '../../core/services/stock.service';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  templateUrl: './dashboard.html',
  styleUrl: './dashboard.scss',
})
export class Dashboard {
  readonly title = signal('Dashboard');
  readonly stock = signal<StockQuote | null>(null);
  readonly loading = signal(false);
  readonly error = signal<string | null>(null);

  constructor(private readonly stockService : StockService){}


  loadStock(): void {
   this.loading.set(true);
   this.error.set(null);

   this.stockService.getStock('AAPL').subscribe({
    next : (result) => this.stock.set(result),
  error:()=>{
    this.error.set('Failed to load stock data');
    this.loading.set(false);
   },
  complete :()=> this.loading.set(false),
  });
}
}
