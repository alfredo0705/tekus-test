import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { ActivatedRoute, Router } from '@angular/router';
import { ServiceService } from '../../../../_services/service.service';
import { ToastrService } from 'ngx-toastr';
import { MatSelectModule } from '@angular/material/select';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { Provider } from '../../../../_models/provider';
import { ProviderService } from '../../../../_services/provider.service';
import { CountryService } from '../../../../_services/country.service';
import { Country } from '../../../../_models/country';

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
    MatCardModule,
    MatCheckboxModule
      ],
  templateUrl: './service-create.component.html',
  styleUrl: './service-create.component.scss'
})
export class ServiceCreateComponent implements OnInit {
  form: FormGroup | undefined;
  providers: Provider[] = [];
  countries: Country[];

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private  serviceService: ServiceService,
    private toastr: ToastrService,
    private providerService: ProviderService,
    private countryService: CountryService
  ) {}

  ngOnInit() {
    this.loadCountries();
    this.loadProviders();
    this.initForm();
  }

  loadCountries(){
    this.countryService.getCountries().subscribe({
      next: (response) =>{
        this.countries = response;
        console.log(this.countries);
      }
    })
  }

  initForm(){
    this.form = this.fb.group({
      name: ['', Validators.required],
      hourlyRate: ['', Validators.required],
      providerId: ['', Validators.required],
      countries: this.fb.array([], Validators.required)
    });
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

    console.log('Seleccionados:', this.form.value.countries);

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
        this.providers = response;
      }
    })
  }
}