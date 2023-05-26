namespace Domain.Models;

public class MessageDomainModel
{
    public int id { get; set; }
    public int userSentId{ get; set; }
    public int chatId{ get; set; }
    public String date{ get; set; }
    public String message{ get; set; }

    public MessageDomainModel(int id, int userSentId, int chatId, String date, String message) {
        this.id = id;
        this.userSentId = userSentId;
        this.chatId = chatId;
        this.date = date;
        this.message = message;
    }

    public MessageDomainModel() {
    }
}