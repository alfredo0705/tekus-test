import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatCardModule } from '@angular/material/card';
import { ActivatedRoute, Router } from '@angular/router';
import { ProviderService } from '../../../../_services/provider.service';
import { Provider } from '../../../../_models/provider';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-provider-edit',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatCardModule
  ],
  templateUrl: './provider-edit.component.html',
  styleUrl: './provider-edit.component.scss'
})
export class ProviderEditComponent implements OnInit {
  provider: Provider;
  form: FormGroup | undefined;

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private providerService: ProviderService,
    private toastr: ToastrService
  ) {}

  ngOnInit() {
    this.route.data.subscribe(data =>{
      this.provider = data['provider'];
    })

    this.initForm(this.provider);
  }

  initForm(provider:Provider){
  this.form = this.fb.group({
    id: [provider.id.toString()],
    name: [provider.name, Validators.required],
    nit: [provider.nit, Validators.required],
    email: [provider.email, [Validators.required, Validators.email]]
  });
  }

  save() {
    if (this.form.invalid) return;

    this.providerService.updateProvider(this.form?.value).subscribe({
      next: (result) => {
        this.toastr.success("Proveedor actualizado");
        this.router.navigateByUrl("/providers");
      }
    })
  }

  cancel() {
    this.router.navigate(['/providers']);
  }
}