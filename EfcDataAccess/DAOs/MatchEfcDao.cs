using Application.DaoInterfaces;
using Domain.Models;
using GrpcDataBaseAcces.IGrpcServices;

namespace EfcDataAccess.DAOs;

public class MatchEfcDao : IMatchDao
{
    public MatchDomainModel findById(int id)
    {
        throw new NotImplementedException();
    }

    public void updateMatch(MatchDomainModel matchModel)
    {
        throw new NotImplementedException();
    }

    public void deleteMatch(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<MatchDomainModel>> findByUserId(int id)
    {
        throw new NotImplementedException();
    }
}