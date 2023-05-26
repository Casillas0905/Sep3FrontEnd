namespace Domain.Models;

public class ChatDomainModel
{
    public int id { get; set; }
    public int userId1{ get; set; }
    public int userId2{ get; set; }

    public ChatDomainModel(int id, int userId1, int userId2) {
        this.id = id;
        this.userId1 = userId1;
        this.userId2 = userId2;
    }

    public ChatDomainModel()
    {
    }
}