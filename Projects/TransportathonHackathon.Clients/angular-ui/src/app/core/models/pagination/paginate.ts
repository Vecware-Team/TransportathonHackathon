export interface Paginate<TEntity> {
  size: number;
  index: number;
  count: number;
  pages: number;
  items: TEntity[];
  hasPrevious: boolean;
  hasNext: boolean;
}
