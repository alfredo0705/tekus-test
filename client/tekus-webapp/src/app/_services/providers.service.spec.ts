import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';
import { ProviderService } from '../_services/provider.service';
import { Provider } from '../_models/provider';
import { Params } from '../_models/params';
import { environment } from '../../environments/environment';

describe('ProviderService', () => {
  let baseUrl = environment.apiUrl;
  let service: ProviderService;
  let httpMock: HttpTestingController;
  let params: Params;

  const mockProvidersResponse = {
    result: [
      { id: 1, nit: '123456', name: 'Importaciones Tekus S.A.', email: 'contacto@tekus.com', customFields: [] },
      { id: 2, nit: '654321', name: 'Servicios Tekus Ltda', email: 'info@tekus.com', customFields: [] }
    ],
    pagination: {
      pageNumber: 1,
      pageSize: 10,
      totalCount: 2,
      totalPages: 1
    }
  };

  beforeEach(() => {
    params = new Params();
    params.pageNumber = 1;
    params.pageSize = 10;
    params.searchCriteria = '';

    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [ProviderService],
    });

    service = TestBed.inject(ProviderService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => httpMock.verify());

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should fetch providers with pagination', () => {
    service.getProviders(params).subscribe(response => {
      expect(response.result.length).toBe(2);
      expect(response).toEqual(mockProvidersResponse);
    });

    const req = httpMock.expectOne(r => r.url === baseUrl + 'providers/getProviders');
    expect(req.request.method).toBe('GET');
    expect(req.request.params.get('pageNumber')).toBe('1');
    expect(req.request.params.get('pageSize')).toBe('10');
    expect(req.request.params.get('searchCriteria')).toBe('');

    req.flush(mockProvidersResponse);
  });

  it('should handle search criteria', () => {
    params.searchCriteria = 'Tekus';

    service.getProviders(params).subscribe(response => {
      expect(response.result.length).toBe(2);
    });

    const req = httpMock.expectOne(r => r.url === baseUrl + 'providers/getProviders');
    expect(req.request.params.get('searchCriteria')).toBe('Tekus');

    req.flush(mockProvidersResponse);
  });

  it('should handle API errors gracefully', () => {
    service.getProviders(params).subscribe({
      next: () => fail('should have failed with 500 error'),
      error: error => expect(error.status).toBe(500)
    });

    const req = httpMock.expectOne(r => r.url === baseUrl + 'providers/getProviders');
    req.flush('Internal Server Error', { status: 500, statusText: 'Server Error' });
  });
});
