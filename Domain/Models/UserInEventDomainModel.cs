namespace Domain.Models;

public class UserInEventDomainModel
{
    public int eventId;
    public int userid;
    public int id;

    public UserInEventDomainModel(int id, int eventId, int userid) {
        this.id = id;
        this.eventId = eventId;
        this.userid = userid;
    }

    public UserInEventDomainModel() {

    }
}