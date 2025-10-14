import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
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
import { Country } from '../../../../_models/country';
import { CountryService } from '../../../../_services/country.service';
import { MatCheckboxModule } from '@angular/material/checkbox';

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
    MatCardModule,
    MatCheckboxModule
  ],
  templateUrl: './service-edit.component.html',
  styleUrl: './service-edit.component.scss'
})
export class ServiceEditComponent implements OnInit {
  form: FormGroup | undefined;
  providers: Provider[] = [];
  service: Service;
  countries: Country[];

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private serviceService: ServiceService,
    private toastr: ToastrService,
    private providerService: ProviderService,
    private countryService: CountryService
  ) { }

  ngOnInit() {
    this.loadCountries();
    this.loadProviders();
    this.route.data.subscribe(data => {
      this.service = data['service'];
    })

    this.initForm(this.service);
  }

  loadCountries() {
    this.countryService.getCountries().subscribe({
      next: (response) => {
        this.countries = response;
      }
    })
  }

  initForm(service: Service) {
    this.form = this.fb.group({
      id: [service.id.toString(), Validators.required],
      name: [service.name, Validators.required],
      hourlyRate: [service.hourlyRate, Validators.required],
      providerId: [Number(service.providerId), [Validators.required]],
      countries: this.fb.array([], Validators.required)
    });

    // Cargar los países seleccionados al editar
    if (service.countries && service.countries.length > 0) {
      service.countries.forEach(country => {
        this.countriesArray.push(this.fb.control(country));
      });
    }
  }

  get countriesArray() {
    return this.form.get('countries') as FormArray;
  }

  onCheckboxChange(event: any, code: string) {
    const countries = this.form.get('countries') as FormArray;
    if (event.checked) {
      countries.push(this.fb.control(code));
    } else {
      const index = countries.controls.findIndex(x => x.value === code);
      countries.removeAt(index);
    }
  }

  save() {
    if (this.form.invalid) return;

    this.serviceService.updateService(this.form?.value).subscribe({
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
        this.providers = response;
        // Vuelve a establecer el valor después de cargar los proveedores
        if (this.form && this.form.get('providerId')?.value) {
          const id = Number(this.form.get('providerId')?.value);
          this.form.get('providerId')?.setValue(id);
        }
      }
    })
  }
}