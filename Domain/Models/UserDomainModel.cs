namespace Domain.Models;

public class UserDomainModel
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Birthday { get; set; }
    public string Description { get; set; }
    public int Number_of_matches { get; set; }
    public string Note { get; set; }
    public string Photo1 { get; set; }
    public string Photo2 { get; set; }
    public string Photo3 { get; set; }
    public string Photo4 { get; set; }
    public string Photo5 { get; set; }
    public string Gender { get; set; }
    public string Preference { get; set; }
    public string Horoscope { get; set; }
    public string Occupation { get; set; }
    public string City { get; set; }
    public string Education { get; set; }
    public bool Drink { get; set; }
    public bool Administrator { get; set; }
    
    public UserDomainModel()
    {
    }
    
    public UserDomainModel(int id, string username, string password, string email, string firstName, string lastName, string birthday, string description, int number_of_matches, string note, string photo1, string photo2, string photo3, string photo4, string photo5, string gender, string preference, string horoscope, string occupation, string city, string education, bool drink, bool administrator)
    {
        Id = id;
        Username = username;
        Password = password;
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        Birthday = birthday;
        Description = description;
        Number_of_matches = number_of_matches;
        Note = note;
        Photo1 = photo1;
        Photo2 = photo2;
        Photo3 = photo3;
        Photo4 = photo4;
        Photo5 = photo5;
        Gender = gender;
        Preference = preference;
        Horoscope = horoscope;
        Occupation = occupation;
        City = city;
        Education = education;
        Drink = drink;
        Administrator = administrator;
    }
}