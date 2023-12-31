﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Persistence.EntityConfigurations
{
    public class TransportRequestConfiguration : IEntityTypeConfiguration<TransportRequest>
    {
        public void Configure(EntityTypeBuilder<TransportRequest> builder)
        {
            builder.ToTable("TransportRequests").HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("Id").IsRequired();
            builder.Property(e => e.CustomerId).HasColumnName("CustomerId").IsRequired();
            builder.Property(e => e.CompanyId).HasColumnName("CompanyId").IsRequired();
            builder.Property(e => e.TransportTypeId).HasColumnName("TransportTypeId").IsRequired();
            builder.Property(e => e.VehicleId).HasColumnName("VehicleId").IsRequired(false);
            builder.Property(e => e.CountryFrom).HasColumnName("CountryFrom").IsRequired();
            builder.Property(e => e.CountryTo).HasColumnName("CountryTo").IsRequired();
            builder.Property(e => e.CityFrom).HasColumnName("CityFrom").IsRequired();
            builder.Property(e => e.CityTo).HasColumnName("CityTo").IsRequired();
            builder.Property(e => e.PlaceSize).HasColumnName("PlaceSize").IsRequired();
            builder.Property(e => e.ApprovedByCompany).HasColumnName("ApprovedByCompany");
            builder.Property(e => e.IsFinished).HasColumnName("IsFinished").IsRequired();
            builder.Property(e => e.StartDate).HasColumnName("StartDate").IsRequired();
            builder.Property(e => e.FinishDate).HasColumnName("FinishDate");

            builder.HasOne(e => e.Customer);
            builder.HasOne(e => e.Company);
            builder.HasOne(e => e.TransportType);
            builder.HasOne(e => e.Comment);
            builder.HasOne(e => e.Vehicle).WithOne(e => e.TransportRequest).IsRequired(false);
            builder.HasOne(e => e.PaymentRequest);
        }
    }
}
