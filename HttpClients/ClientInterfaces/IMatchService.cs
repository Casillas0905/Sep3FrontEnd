using Domain.Models;

namespace HttpClients.ClientInterfaces;

public interface IMatchService
{
    public Task<MatchDomainModel> findById(int id);
    public Task updateMatch(MatchDomainModel matchModel);
    public Task deleteMatch(int id);
    public Task<IEnumerable<MatchDomainModel>> findByUserId(int id);
}