export interface ProviderCustomFields{
    providerId: number;
    customField: CustomField;
}

export interface CustomField{
    fieldName: string;
    fieldValue: string;
}