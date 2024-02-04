using DAL.Contracts;
using DAL.DBContext;
using DAL.Models;
using Shared.Repository.Sql;

namespace DAL.Repositories
{
    public class CityModelRepository : BaseRepository<ClientDBContext, CityModel>, ICityModelRepository
    {
        public CityModelRepository(ClientDBContext clientDBContext)
            : base(clientDBContext) { }
    }
}