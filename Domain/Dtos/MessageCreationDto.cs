namespace Domain.DTOs;

public class MessageCreationDto
{
    public int Ownerid { get; }
    public int PostOwnerId { get; }
    public string message { get; }

    public MessageCreationDto(string message,int ownerid, int postOwnerId)
    {
        Ownerid = ownerid;
        PostOwnerId = postOwnerId;
        this.message = message;
    }
}
