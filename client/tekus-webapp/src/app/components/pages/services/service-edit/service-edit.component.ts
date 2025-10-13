import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { Provider } from '../../../../_models/provider';
import { ActivatedRoute, Router } from '@angular/router';
import { ServiceService } from '../../../../_services/service.service';
import { ToastrService } from 'ngx-toastr';
import { ProviderService } from '../../../../_services/provider.service';
import { Service } from '../../../../_models/service';

@Component({
  selector: 'app-service-edit',
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
  templateUrl: './service-edit.component.html',
  styleUrl: './service-edit.component.scss'
})
export class ServiceEditComponent implements OnInit {
  form: FormGroup | undefined;
  providers: Provider[] = [];
  service: Service;

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
    this.route.data.subscribe(data =>{
      this.service = data['service'];
    })

    this.initForm(this.service);
  }

  initForm(service: Service){
    this.form = this.fb.group({
      id: [service.id.toString(), Validators.required],
      name: [service.name, Validators.required],
      hourlyRate: [service.hourlyRate, Validators.required],
      providerId: [service.providerId, [Validators.required, Validators.email]]
    });
  }

  save() {
    if (this.form.invalid) return;

    this.serviceService.addService(this.form?.value).subscribe({
      next: (result) => {
        this.toastr.success("Servicio actualizado");
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