using Domain.Models;
using GrpcDataBaseAcces.IGrpcServices;

namespace GrpcDataBaseAcces.GrpcServices;

public class MatchGrpcService : IMatchGrpcService
{
    public MatchDomainModel findById(int id)
    {
        throw new NotImplementedException();
    }

    public void updateMatch()
    {
        throw new NotImplementedException();
    }

    public void deleteMatch()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<MatchDomainModel> findByUserId(int id)
    {
        throw new NotImplementedException();
    }
}