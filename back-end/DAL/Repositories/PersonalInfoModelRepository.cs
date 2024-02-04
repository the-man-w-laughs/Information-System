using DAL.Contracts;
using DAL.DBContext;
using DAL.Models;
using Shared.Repository.Sql;

namespace DAL.Repositories
{
    public class PersonalInfoModelRepository : BaseRepository<ClientDBContext, PersonalInfoModel>, IPersonalInfoModelRepository
    {
        public PersonalInfoModelRepository(ClientDBContext clientDBContext)
            : base(clientDBContext) { }
    }
}