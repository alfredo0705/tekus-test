import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { Service } from '../../../../_models/service';
import { Params } from '../../../../_models/params';
import { Pagination } from '../../../../_models/pagination';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { CommonModule } from '@angular/common';
import { MatPaginator, MatPaginatorModule, PageEvent } from '@angular/material/paginator';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatInputModule } from '@angular/material/input';
import { MatToolbarModule } from '@angular/material/toolbar';
import { ProviderService } from '../../../../_services/provider.service';
import { Router } from '@angular/router';
import { ServiceService } from '../../../../_services/service.service';
import { MatChipsModule } from '@angular/material/chips';

@Component({
  selector: 'app-service-list',
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
      MatToolbarModule,
      MatChipsModule
    ],
  templateUrl: './service-list.component.html',
  styleUrl: './service-list.component.scss'
})
export class ServiceListComponent implements OnInit, AfterViewInit {
  services: Service[];
  params: Params = new Params();
  pagination!: Pagination;
  displayedColumns: string[] = ['id', 'name', 'providerName', 'countries', 'actions'];
  dataSource = new MatTableDataSource<Service>([]);
  filterValue = '';

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(
    private serviceService: ServiceService,
    private router: Router){
    this.params = this.serviceService.getParams();
  }

  ngOnInit(): void {
    this.loadServices();
  }

  loadServices(){
    this.serviceService.getServices(this.params).subscribe({
      next: (response)=>{
        this.pagination = response.pagination;
        this.services = response.result;

        this.dataSource.data = response.result;
        
        if (this.paginator) {
          this.paginator.length = this.pagination.totalItems;
          this.paginator.pageIndex = this.pagination.currentPage - 1;
          this.paginator.pageSize = this.pagination.itemsPerPage;
        }
      }
    })
  }

  ngAfterViewInit() {
  this.dataSource.paginator = this.paginator;
  this.dataSource.sort = this.sort;
}

  onPageChanged(event: PageEvent){
    if (event.pageSize !== this.params.pageSize) {
      this.params.pageNumber = 1;
      this.paginator.pageIndex = 0;
    } else {
      this.params.pageNumber = event.pageIndex + 1;
    }

    this.params.pageSize = event.pageSize;
    this.serviceService.setParams(this.params);
    this.loadServices();
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
    this.router.navigate(['/services/create']);
  }

  navigateToEditProvider(id: string) {
    this.router.navigate(['/services/edit', id]);
  }

}
