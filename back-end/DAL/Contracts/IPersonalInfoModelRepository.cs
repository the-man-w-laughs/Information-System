using DAL.Models;
using Shared.Repository.Sql;

namespace DAL.Contracts
{
    public interface IPersonalInfoModelRepository : IBaseRepository<PersonalInfoModel>
    {
        new Task<PersonalInfoModel?> GetByIdAsync(
            int id,
            CancellationToken cancellationToken = default
        );
    }
}
