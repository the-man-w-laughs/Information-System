using DAL.Contracts;
using DAL.DBContext;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Shared.Repository.Sql;

namespace DAL.Repositories
{
    public class PersonalInfoModelRepository
        : BaseRepository<ClientDBContext, PersonalInfoModel>,
            IPersonalInfoModelRepository
    {
        private readonly ClientDBContext _clientDBContext;

        public PersonalInfoModelRepository(ClientDBContext clientDBContext)
            : base(clientDBContext)
        {
            _clientDBContext = clientDBContext;
        }

        public new async Task<PersonalInfoModel?> GetByIdAsync(
            int id,
            CancellationToken cancellationToken = default
        )
        {
            return await _clientDBContext
                .Set<PersonalInfoModel>()
                .Include(p => p.CurrentCity)
                .Include(p => p.RegistrationCity)
                .Include(p => p.MaritalStatus)
                .Include(p => p.Citizenship)
                .Include(p => p.Disability)
                .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        }

        public new async Task<PersonalInfoModel?> DeleteByIdAsync(
            int id,
            CancellationToken cancellationToken = default
        )
        {
            var entity = await GetByIdAsync(id, cancellationToken);

            if (entity != null)
            {
                Delete(entity);
            }

            return entity;
        }
    }
}
