import { Component } from '@angular/core';
import { ExoplanetSearchComponent } from './exoplanet-search/exoplanet-search.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [ExoplanetSearchComponent],
  template: `
    <app-exoplanet-search></app-exoplanet-search>
  `,
  styles: [`
    :host {
      display: block;
      background-color: #121212;
    }
  `]
})
export class AppComponent {}