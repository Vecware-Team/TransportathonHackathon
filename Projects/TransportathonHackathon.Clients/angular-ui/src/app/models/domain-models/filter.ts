export interface Filter {
  field: string;
  value: string | null;
  operator: string;
  logic: string | null;
  filters: Filter[] | null;
}
