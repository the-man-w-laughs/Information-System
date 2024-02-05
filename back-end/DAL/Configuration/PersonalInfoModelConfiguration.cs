using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configuration
{
    public class PersonalInfoModelConfiguration : IEntityTypeConfiguration<PersonalInfoModel>
    {
        public void Configure(EntityTypeBuilder<PersonalInfoModel> entity)
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.LastName).IsRequired().HasMaxLength(255);
            entity.Property(e => e.FirstName).IsRequired().HasMaxLength(255);
            entity.Property(e => e.Patronymic).IsRequired().HasMaxLength(255);
            entity.Property(e => e.DateOfBirth).IsRequired();
            entity.Property(e => e.PassportSeries).IsRequired().HasMaxLength(10);
            entity.Property(e => e.PassportNumber).IsRequired().HasMaxLength(20);
            entity.Property(e => e.PassportIssuedBy).IsRequired().HasMaxLength(255);
            entity.Property(e => e.PassportIssueDate).IsRequired();
            entity.Property(e => e.IdentificationNumber).IsRequired().HasMaxLength(20);
            entity.Property(e => e.PlaceOfBirth).IsRequired().HasMaxLength(255);
            entity.Property(e => e.CurrentAddress).IsRequired().HasMaxLength(500);
            entity.Property(e => e.HomePhone).IsRequired(false).HasMaxLength(20);
            entity.Property(e => e.MobilePhone).IsRequired(false).HasMaxLength(20);
            entity.Property(e => e.Email).IsRequired(false).HasMaxLength(255);
            entity.Property(e => e.Workplace).IsRequired(false).HasMaxLength(255);
            entity.Property(e => e.Position).IsRequired(false).HasMaxLength(255);
            entity.Property(e => e.MonthlyIncome).IsRequired(false).HasColumnType("decimal(18,2)");

            entity
                .HasOne(e => e.CurrentCity)
                .WithMany()
                .HasForeignKey(e => e.CurrentCityId)
                .IsRequired();

            entity
                .HasOne(e => e.RegistrationCity)
                .WithMany()
                .HasForeignKey(e => e.RegistrationCityId)
                .IsRequired();

            entity
                .HasOne(e => e.MaritalStatus)
                .WithMany()
                .HasForeignKey(e => e.MaritalStatusId)
                .IsRequired();

            entity
                .HasOne(e => e.Citizenship)
                .WithMany()
                .HasForeignKey(e => e.CitizenshipId)
                .IsRequired();

            entity
                .HasOne(e => e.Disability)
                .WithMany()
                .HasForeignKey(e => e.DisabilityId)
                .IsRequired();

            entity.ToTable("PersonalInfos");
        }
    }
}
