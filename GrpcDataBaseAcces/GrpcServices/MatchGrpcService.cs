using Domain.Models;
using Grpc.Core;
using Grpc.Net.Client;
using GrpcDataBaseAcces.IGrpcServices;
using GrpcClasses.Match;
namespace GrpcDataBaseAcces.GrpcServices;

public class MatchGrpcService : IMatchGrpcService
{
    static GrpcChannel channel = GrpcChannel.ForAddress("http://localhost:8080");
    private Matches.MatchesClient client = new Matches.MatchesClient(channel);
    
    public MatchDomainModel findById(int id)
    {
        var req = new MatchIdRequest() { Id = id };
        var match = client.findById(req);
        MatchDomainModel newMatch = new MatchDomainModel(match.Id, match.MatchUser1, match.UserId1, match.MatchUser2,
            match.UserId2, match.Match);
        return newMatch;

    }

    public void updateMatch(MatchDomainModel match)
    {
        MatchModel matchModel = new MatchModel()
        {
            Id = match.id,
            UserId1 = match.userid1,
            UserId2 = match.userid2,
            MatchUser1 = match.matchUser1,
            MatchUser2 = match.matchUser1,
            Match = match.match
        };
        client.updateMatch(matchModel);
    }

    public void deleteMatch(int id)
    {
        var req = new MatchIdRequest() { Id = id };
        client.deleteMatchAsync(req);
        
    }

    public async Task<IEnumerable<MatchDomainModel>> findByUserId(int id)
    {
        var req = new UserIdRequest() { UserId = id };
        using var call = client.findByUserId(req);
        List<MatchDomainModel> list = new List<MatchDomainModel>();
        while (await call.ResponseStream.MoveNext())
        {
            var match = call.ResponseStream.Current;
            MatchDomainModel matchModel = new MatchDomainModel()
                    {
                        id = match.Id,
                        userid1 = match.UserId1,
                        userid2 = match.UserId2,
                        matchUser1 = match.MatchUser1,
                        matchUser2 = match.MatchUser2,
                        match = match.Match
                    };
            list.Add(matchModel);
        }

        return list;
    }
}