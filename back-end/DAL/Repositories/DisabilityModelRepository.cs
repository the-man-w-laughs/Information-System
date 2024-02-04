using DAL.Contracts;
using DAL.DBContext;
using DAL.Models;
using Shared.Repository.Sql;

namespace DAL.Repositories
{
    public class DisabilityModelRepository : BaseRepository<ClientDBContext, DisabilityModel>, IDisabilityModelRepository
    {
        public DisabilityModelRepository(ClientDBContext clientDBContext)
            : base(clientDBContext) { }
    }
}