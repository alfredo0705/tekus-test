import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';
import { ProviderService } from '../_services/provider.service';
import { Provider } from '../_models/provider';
import { Params } from '../_models/params';
import { ServiceService } from './service.service';
import { Service } from '../_models/service';

describe('ProvidersService', () => {
  let service: ServiceService;
  let httpMock: HttpTestingController;
  let params = new Params();
  params.pageSize = 10;
  params.pageNumber = 1;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [ProviderService],
    });

    service = TestBed.inject(ServiceService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  it('should fetch providers', () => {
    const mockProviders: Service[] = [
      { id: 1, name: 'Test Provider', providerId: 1, hourlyRate: 10, providerName: 'Test Provider' }
    ];

    service.getServices(params).subscribe(result => {
      expect(result).toHaveLength(1);
      expect(result[0].name).toBe('Test Provider');
    });

    const req = httpMock.expectOne('https://localhost:7026/api/services/getServices?pageNumber=1&pageSize=10&searchCriteria=');
    expect(req.request.method).toBe('GET');
    req.flush(mockProviders);
  });

  afterEach(() => httpMock.verify());
});
