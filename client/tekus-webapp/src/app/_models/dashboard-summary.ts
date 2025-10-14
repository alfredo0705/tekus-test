export interface DashboardSummary{
    totalProviders: number;
    totalServices: number;
    servicesByCountry: CountryCountDto;
    providersByCountry: CountryCountDto;
}

export interface CountryCountDto{
    country: string;
    count: number;
}