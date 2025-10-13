import { Component, OnInit, ViewChild } from '@angular/core';
import { Provider } from '../../../../_models/provider';
import { ProviderService } from '../../../../_services/provider.service';
import { Params } from '../../../../_models/params';
import { Pagination } from '../../../../_models/pagination';
import { MatPaginator, MatPaginatorModule, PageEvent } from '@angular/material/paginator';
import { CommonModule } from '@angular/common';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatInputModule } from '@angular/material/input';
import { Router } from '@angular/router';
import { MatToolbarModule } from '@angular/material/toolbar';

@Component({
  selector: 'app-provider-list',
  standalone: true,
  imports: [
    CommonModule,
    MatPaginatorModule,
    MatTableModule,
    MatSortModule,
    MatIconModule,
    MatButtonModule,
    MatTooltipModule,
    MatInputModule,
    MatToolbarModule
  ],
  templateUrl: './provider-list.component.html',
  styleUrl: './provider-list.component.scss'
})
export class ProviderListComponent implements OnInit {
  providers: Provider[];
  params: Params = new Params();
  pagination!: Pagination;
  displayedColumns: string[] = ['id', 'nit', 'name', 'email', 'customFields', 'actions'];
  dataSource = new MatTableDataSource<Provider>([]);
  filterValue = '';

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(
    private providerService: ProviderService,
    private router: Router){
    this.params = this.providerService.getParams();
  }

  ngOnInit(): void {
    this.loadProviders();
  }

  loadProviders(){
    this.providerService.getProviders(this.params).subscribe({
      next: (response)=>{
        console.log(response)
        this.pagination = response.pagination;
        this.providers = response.result;

        this.dataSource.data = response.result;
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;

      }
    })
  }

  onPageChanged(event: PageEvent){
    this.pagination.currentPage = event.pageIndex;
    this.pagination.itemsPerPage = event.pageSize;
    this.providerService.setParams(this.params);
    this.loadProviders();
  }

  applyFilter(event: Event) {
    const input = (event.target as HTMLInputElement).value;
    this.filterValue = input;
    this.dataSource.filter = input.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  clearFilter() {
    this.filterValue = '';
    this.dataSource.filter = '';
  }

  navigateToNewProvider() {
    this.router.navigate(['/providers/create']);
  }

  navigateToEditProvider(id: string) {
    this.router.navigate(['/providers/edit', id]);
  }

}
