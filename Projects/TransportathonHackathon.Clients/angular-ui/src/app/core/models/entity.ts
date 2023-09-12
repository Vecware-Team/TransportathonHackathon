export interface BaseEntity {
    createdDate: string;
    updatedDate: string | null;
    deletedDate: string | null;
}

export interface Entity<TId> extends BaseEntity {
    id: TId;
}