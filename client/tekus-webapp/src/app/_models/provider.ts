export interface Provider{
    id: number;
    nit: string;
    name: string;
    email: string;
    customFields: CustomFields[]
}

export interface CustomFields{
    fieldName: string;
    fieldValue: string;
}