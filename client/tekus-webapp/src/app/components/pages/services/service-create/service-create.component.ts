import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { ActivatedRoute, Router } from '@angular/router';
import { ServiceService } from '../../../../_services/service.service';
import { ToastrService } from 'ngx-toastr';
import { MatSelectModule } from '@angular/material/select';
import { Provider } from '../../../../_models/provider';
import { ProviderService } from '../../../../_services/provider.service';

@Component({
  selector: 'app-service-create',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatSelectModule,
    MatInputModule,
    MatButtonModule,
    MatCardModule
      ],
  templateUrl: './service-create.component.html',
  styleUrl: './service-create.component.scss'
})
export class ServiceCreateComponent implements OnInit {
  form: FormGroup | undefined;
  providers: Provider[] = [];

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private  serviceService: ServiceService,
    private toastr: ToastrService,
    private providerService: ProviderService
  ) {}

  ngOnInit() {
    this.loadProviders();
    this.initForm();
  }

  initForm(){
    this.form = this.fb.group({
      name: ['', Validators.required],
      hourlyRate: ['', Validators.required],
      providerId: ['', Validators.required]
    });
  }

  save() {
    if (this.form.invalid) return;

    this.serviceService.addService(this.form?.value).subscribe({
      next: (result) => {
        this.toastr.success("Servicio creado");
        this.router.navigateByUrl("/services");
      }
    })
  }

  cancel() {
    this.router.navigate(['/services']);
  }

  loadProviders() {
    this.providerService.getProvidersList().subscribe({
      next: (response) => {
        console.log(response);
        this.providers = response;
      }
    })
  }
}