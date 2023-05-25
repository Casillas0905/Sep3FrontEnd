namespace Domain.Models;

public class MatchDomainModel
{
    public int id { get; set; }
    public bool matchUser1{ get; set; }
    public int userid1{ get; set; }
    public bool matchUser2{ get; set; }
    public int userid2{ get; set; }
    public bool match{ get; set; }

    public MatchDomainModel()
    {
    }

    public MatchDomainModel(int id, bool matchUser1, int userid1, bool matchUser2, int userid2, bool match)
    {
        this.id = id;
        this.matchUser1 = matchUser1;
        this.userid1 = userid1;
        this.matchUser2 = matchUser2;
        this.userid2 = userid2;
        this.match = match;
    }
}