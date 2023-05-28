using Application.LogicInterfaces;
using Domain.Models;
using GrpcDataBaseAcces.GrpcServices;

namespace Application.Logic;

public class MatchLogic : IMatchLogic
{
    private MatchGrpcService service = new MatchGrpcService();

    public MatchLogic()
    {
    }

    public MatchDomainModel findById(int id)
    {
        return service.findById(id);
    }

    public void updateMatch(MatchDomainModel matchModel)
    {
        service.updateMatch(matchModel);
    }

    public void deleteMatch(int id)
    {
        service.deleteMatch(id);
    }

    public Task<IEnumerable<MatchDomainModel>> findByUserId(int id)
    {
        return service.findByUserId(id);
    }
}