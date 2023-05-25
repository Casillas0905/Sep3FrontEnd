using Domain.Models;
using Grpc.Core;
using Grpc.Net.Client;
using GrpcClasses.Event;
using GrpcClasses.User;
using GrpcDataBaseAcces.IGrpcServices;
using Empty = GrpcClasses.User.Empty;


namespace GrpcDataBaseAcces.GrpcServices;

public class UserGrpcService : IUserGrpcService
{
    static GrpcChannel channel = GrpcChannel.ForAddress("http://localhost:8080");
    private UserGrpc.UserGrpcClient userClient = new UserGrpc.UserGrpcClient(channel);

    public void saveUser(UserDomainModel user)
    {
        Console.WriteLine("grpc called");
        UserModel userModel = new UserModel()
        {
            Id = user.Id,
            Username = user.Username,
            Password = user.Password,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Birthday = user.Birthday,
            Description = user.Description,
            NumberOfMatches = user.Number_of_matches,
            Note = user.Note,
            Photo1 = user.Photo1,
            Photo2 = user.Photo2,
            Photo3 = user.Photo3,
            Photo4 = user.Photo4,
            Photo5 = user.Photo5,
            Gender = user.Gender,
            Preference = user.Preference,
            Horoscope = user.Horoscope,
            Occupation = user.Occupation,
            City = user.City,
            Education = user.Education,
            Drink = user.Drink,
            Administrator = user.Administrator
        };
        userClient.saveUserAsync(userModel);
    }

    public UserDomainModel findById(int id)
    {
        var req = new GetById() { Id = id };
        var user= userClient.findById(req);
        UserDomainModel newUser = new UserDomainModel(user.Id, user.Username, user.Password, user.Email, user.FirstName,
            user.LastName, user.Birthday, user.Description, user.NumberOfMatches, user.Note, user.Photo1, user.Photo2,
            user.Photo3, user.Photo4, user.Photo5, user.Gender,user.Preference, user.Horoscope, user.Occupation, user.City,
            user.Education, user.Drink, user.Administrator);
        return newUser;
    }

    public async Task<IEnumerable<UserDomainModel>> getAllUsers()
    {
        var req = new Empty();
        using var call = userClient.findAll(req);
        List<UserDomainModel> list = new List<UserDomainModel>();

        while (await call.ResponseStream.MoveNext())
        {
            var user = call.ResponseStream.Current;
            UserDomainModel userDomain = new UserDomainModel(user.Id, user.Username, user.Password, user.Email, user.FirstName,
                user.LastName, user.Birthday, user.Description, user.NumberOfMatches, user.Note, user.Photo1, user.Photo2,
                user.Photo3, user.Photo4, user.Photo5, user.Gender,user.Preference, user.Horoscope, user.Occupation, user.City,
                user.Education, user.Drink, user.Administrator);
            list.Add(userDomain);
        }

        return list;
    }

    public void updateUser(UserDomainModel user)
    {
        UserModel userModel = new UserModel()
        {
            Id = user.Id,
            Username = user.Username,
            Password = user.Password,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Birthday = user.Birthday,
            Description = user.Description,
            NumberOfMatches = user.Number_of_matches,
            Note = user.Note,
            Photo1 = user.Photo1,
            Photo2 = user.Photo2,
            Photo3 = user.Photo3,
            Photo4 = user.Photo4,
            Photo5 = user.Photo5,
            Gender = user.Gender,
            Preference = user.Preference,
            Horoscope = user.Horoscope,
            Occupation = user.Occupation,
            City = user.City,
            Education = user.Education,
            Drink = user.Drink,
            Administrator = user.Administrator
        };
        userClient.updateUserAsync(userModel);
    }

    public void deleteUser(int id)
    {
        var req = new GetById() { Id = id };
        userClient.deleteUserAsync(req);
    }

    public UserDomainModel findByUsername(string username)
    {
        var req = new GetByUsername() { Username = username};
        var user= userClient.findByUsername(req);
        UserDomainModel newUser = new UserDomainModel(user.Id, user.Username, user.Password, user.Email, user.FirstName,
            user.LastName, user.Birthday, user.Description, user.NumberOfMatches, user.Note, user.Photo1, user.Photo2,
            user.Photo3, user.Photo4, user.Photo5, user.Gender,user.Preference, user.Horoscope, user.Occupation, user.City,
            user.Education, user.Drink, user.Administrator);
        return newUser;
    }
}