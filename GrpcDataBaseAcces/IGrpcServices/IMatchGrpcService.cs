using Domain.Models;

namespace GrpcDataBaseAcces.IGrpcServices;

public interface IMatchGrpcService
{
    public MatchDomainModel findById(int id);
    public void updateMatch();
    public void deleteMatch();
    public IEnumerable<MatchDomainModel> findByUserId(int id);
}