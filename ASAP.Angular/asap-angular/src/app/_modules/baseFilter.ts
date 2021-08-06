export interface BaseFilter {
    pageNumber: number;
    range: number;
    orderByDescending: boolean;
    orderProperty: string;
    properties: string[];
    values: string[]
}