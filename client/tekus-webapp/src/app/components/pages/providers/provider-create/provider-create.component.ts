import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ProviderService } from '../../../../_services/provider.service';
import { ToastrService } from 'ngx-toastr';
import { CommonModule } from '@angular/common';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';

@Component({
  selector: 'app-provider-create',
  standalone: true,
  imports: [
      CommonModule,
      ReactiveFormsModule,
      MatFormFieldModule,
      MatInputModule,
      MatButtonModule,
      MatCardModule
    ],
  templateUrl: './provider-create.component.html',
  styleUrl: './provider-create.component.scss'
})
export class ProviderCreateComponent implements OnInit {
  form: FormGroup | undefined;

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private providerService: ProviderService,
    private toastr: ToastrService
  ) {}

  ngOnInit() {
    this.initForm();
  }

  initForm(){
    this.form = this.fb.group({
      name: ['', Validators.required],
      nit: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]]
    });
  }

  save() {
    if (this.form.invalid) return;

    this.providerService.addProvider(this.form?.value).subscribe({
      next: (result) => {
        this.toastr.success("Proveedor creado");
        this.router.navigateByUrl("/providers");
      }
    })
  }

  cancel() {
    this.router.navigate(['/providers']);
  }
}