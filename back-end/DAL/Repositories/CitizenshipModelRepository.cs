using DAL.Contracts;
using DAL.DBContext;
using DAL.Models;
using Shared.Repository.Sql;

namespace DAL.Repositories
{
    public class CitizenshipModelRepository : BaseRepository<ClientDBContext, CitizenshipModel>, ICitizenshipModelRepository
    {
        public CitizenshipModelRepository(ClientDBContext clientDBContext)
            : base(clientDBContext) { }
    }
}