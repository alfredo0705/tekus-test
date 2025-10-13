import { CommonModule } from '@angular/common';
import { Component, Inject } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MAT_DIALOG_DATA, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { ProviderService } from '../../../../_services/provider.service';

@Component({
  selector: 'app-add-custom-field-dialog',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatDialogModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
  ],
  templateUrl: './add-custom-field-dialog.component.html',
  styleUrl: './add-custom-field-dialog.component.scss'
})
export class AddCustomFieldDialogComponent {
  form = this.fb.group({
    fieldName: ['', Validators.required],
    fieldValue: ['', Validators.required],
  });

  constructor(
    private fb: FormBuilder,
    public dialogRef: MatDialogRef<AddCustomFieldDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { providerId: number }
  ) {}

  save() {
    if (this.form.valid) {
      this.dialogRef.close({
        providerId: this.data.providerId,
        customField: this.form.value
      });
    }
  }

  close() {
    this.dialogRef.close();
  }
}