import { Component, ViewChild, AfterViewInit } from '@angular/core';
import { Subject } from 'rxjs';
import { debounceTime } from 'rxjs/operators';
import { ExoplanetService } from '../exoplanet.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatIconModule } from '@angular/material/icon';
import { MatTableModule, MatTableDataSource } from '@angular/material/table';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';

@Component({
  selector: 'app-exoplanet-search',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatTableModule,
    MatSortModule,
    MatIconModule,    
    MatTooltipModule,  
    MatPaginatorModule
  ],
  templateUrl: './exoplanet-search.component.html',
  styleUrls: ['./exoplanet-search.component.css']
})
export class ExoplanetSearchComponent implements AfterViewInit {
  planetNameSearch: string = '';
  hostNameSearch: string = '';
  discoveryMethodSearch: string = '';
  discoveryFacilitySearch: string = '';
  discoveryYearSearch: number | null = null;

  dataSource = new MatTableDataSource<any>([]);
  displayedColumns: string[] = [
    'planetName', 'hostName', 'discoveryMethod', 'discoveryFacility', 'discoveryYear',
    'orbitalPeriod', 'planetRadius', 'planetMass', 'distance'
  ];
  private searchSubject = new Subject<void>();

  @ViewChild(MatSort) sort!: MatSort;
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(private exoplanetService: ExoplanetService) {
    this.searchSubject.pipe(debounceTime(300)).subscribe(() => this.fetchExoplanets());
  }

  ngAfterViewInit() {
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
  }

  search() {
    this.searchSubject.next();
  }

  fetchExoplanets() {
    const params = {
      planetName: this.planetNameSearch || null,
      hostName: this.hostNameSearch || null,
      discoveryMethod: this.discoveryMethodSearch || null,
      discoveryFacility: this.discoveryFacilitySearch || null,
      discoveryYear: this.discoveryYearSearch
    };

    const hasParams = Object.values(params).some(value => 
      value !== null && value !== '' && value !== undefined
    );

    if (!hasParams) {
      this.dataSource.data = [];
      return;
    }

    this.exoplanetService.getExoplanets(params).subscribe({
      next: (data) => {
        this.dataSource.data = data;
        if (this.paginator) {
          this.dataSource.paginator = this.paginator;
          this.paginator.firstPage();
        }
      },
      error: (err) => {
        console.error('Error fetching exoplanets:', err);
      }
    });
  }

  clear() {
    this.planetNameSearch = '';
    this.hostNameSearch = '';
    this.discoveryMethodSearch = '';
    this.discoveryFacilitySearch = '';
    this.discoveryYearSearch = null;
    this.dataSource.data = [];
    if (this.paginator) {
      this.paginator.firstPage();
    }
  }

  getHostNameUrl(hostName: string): string {
    return `https://exoplanetarchive.ipac.caltech.edu/overview/${encodeURIComponent(hostName)}`;
  }
}