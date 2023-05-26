using Domain.Models;
using GrpcClasses.Match;

namespace GrpcDataBaseAcces.IGrpcServices;

public interface IMatchGrpcService
{
    public MatchDomainModel findById(int id);
    public void updateMatch(MatchDomainModel matchModel);
    public void deleteMatch(int id);
    public Task<IEnumerable<MatchDomainModel>> findByUserId(int id);
}