using DAL.Contracts;
using DAL.DBContext;
using DAL.Models;
using Shared.Repository.Sql;

namespace DAL.Repositories
{
    public class MaritalStatusModelRepository : BaseRepository<ClientDBContext, MaritalStatusModel>, IMaritalStatusModelRepository
    {
        public MaritalStatusModelRepository(ClientDBContext clientDBContext)
            : base(clientDBContext) { }
    }
}