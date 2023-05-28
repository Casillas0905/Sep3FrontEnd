namespace Domain.Models;

public class MatchDomainModel
{
    public int id { get; set; }
    public string matchUser1{ get; set; }
    public int userid1{ get; set; }
    public string matchUser2{ get; set; }
    public int userid2{ get; set; }
    public string match{ get; set; }

    public MatchDomainModel()
    {
    }

    public MatchDomainModel(int id, string matchUser1, int userid1, string matchUser2, int userid2, string match)
    {
        this.id = id;
        this.matchUser1 = matchUser1;
        this.userid1 = userid1;
        this.matchUser2 = matchUser2;
        this.userid2 = userid2;
        this.match = match;
    }
}