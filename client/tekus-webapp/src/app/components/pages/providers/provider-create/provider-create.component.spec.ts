import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ProviderCreateComponent } from './provider-create.component';
import { ReactiveFormsModule } from '@angular/forms';
import { ProviderService } from '../../../../_services/provider.service';
import { ToastrService } from 'ngx-toastr';
import { Router, ActivatedRoute } from '@angular/router';
import { of } from 'rxjs';
import { By } from '@angular/platform-browser';

describe('ProviderCreateComponent', () => {
  let component: ProviderCreateComponent;
  let fixture: ComponentFixture<ProviderCreateComponent>;
  let providerServiceSpy: { addProvider: jest.Mock };
  let toastrSpy: { success: jest.Mock };
  let routerSpy: { navigateByUrl: jest.Mock; navigate: jest.Mock };

  beforeEach(async () => {
    providerServiceSpy = { addProvider: jest.fn() };
    toastrSpy = { success: jest.fn() };
    routerSpy = { navigateByUrl: jest.fn(), navigate: jest.fn() };

    await TestBed.configureTestingModule({
      imports: [ReactiveFormsModule, ProviderCreateComponent  ],
      declarations: [],
      providers: [
        { provide: ProviderService, useValue: providerServiceSpy },
        { provide: ToastrService, useValue: toastrSpy },
        { provide: Router, useValue: routerSpy },
        { provide: ActivatedRoute, useValue: { snapshot: { params: {} } } }
      ]
    }).compileComponents();

    fixture = TestBed.createComponent(ProviderCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should initialize the form with empty values', () => {
    const form = component.form;
    expect(form).toBeDefined();
    expect(form?.controls['name'].value).toBe('');
    expect(form?.controls['nit'].value).toBe('');
    expect(form?.controls['email'].value).toBe('');
  });

  it('should mark form as invalid if empty', () => {
    component.form?.setValue({ name: '', nit: '', email: '' });
    expect(component.form?.invalid).toBe(true);
  });

  it('should validate email field', () => {
    const email = component.form?.controls['email'];
    email?.setValue('not-an-email');
    expect(email?.valid).toBe(false);

    email?.setValue('user@tekus.com');
    expect(email?.valid).toBe(true);
  });

  it('should call addProvider and navigate on save if form is valid', async () => {
    component.form?.setValue({ name: 'Tekus', nit: '12345', email: 'info@tekus.com' });
    providerServiceSpy.addProvider.mockReturnValue(of({ id: 1 }));

    await component.save();

    expect(providerServiceSpy.addProvider).toHaveBeenCalledWith({
      name: 'Tekus',
      nit: '12345',
      email: 'info@tekus.com'
    });
    expect(toastrSpy.success).toHaveBeenCalledWith('Proveedor creado');
    expect(routerSpy.navigateByUrl).toHaveBeenCalledWith('/providers');
  });

  it('should not call addProvider if form is invalid', async () => {
    component.form?.setValue({ name: '', nit: '', email: '' });
    await component.save();

    expect(providerServiceSpy.addProvider).not.toHaveBeenCalled();
  });

  it('should navigate to /providers on cancel', () => {
    component.cancel();
    expect(routerSpy.navigate).toHaveBeenCalledWith(['/providers']);
  });
});
