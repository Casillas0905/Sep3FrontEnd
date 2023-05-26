namespace Domain.Models;

public class EventDomainModel
{
    public int id { get; set; }
    
    public String description{ get; set; }
    
    public String title{ get; set; }
    
    public int madeById{ get; set; }

    public EventDomainModel(int id, String description, String title, int madeById) {
        this.id = id;
        this.description = description;
        this.title = title;
        this.madeById = madeById;
    }

    public EventDomainModel() {
    }
}