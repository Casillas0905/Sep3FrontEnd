using Domain.Models;

namespace Application.LogicInterfaces;

public interface IMatchLogic
{
    public MatchDomainModel findById(int id);
    public void updateMatch(MatchDomainModel matchModel);
    public void deleteMatch(int id);
    public Task<IEnumerable<MatchDomainModel>> findByUserId(int id);
}