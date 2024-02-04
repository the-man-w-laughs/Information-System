using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.DBSetup
{
    public class DisabilityModelSetup : IEntityTypeConfiguration<DisabilityModel>
    {
        public void Configure(EntityTypeBuilder<DisabilityModel> entity)
        {
            var disabilities = new List<DisabilityModel>()
            {
                new() { Id = 1, Name = "Отсутствует" },
                new() { Id = 2, Name = "Первая группа" },
                new() { Id = 3, Name = "Вторая группа" },
                new() { Id = 4, Name = "Третья группа" }
            };
            entity.HasData(disabilities);
        }
    }
}
