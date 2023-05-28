using Domain.Models;
using Grpc.Core;
using Grpc.Net.Client;
using GrpcClasses.UserInEvents;
using GrpcDataBaseAcces.IGrpcServices;

namespace GrpcDataBaseAcces.GrpcServices;

public class UserInEventGrpcServices : IUserInEventGrpcService
{
    static GrpcChannel channel = GrpcChannel.ForAddress("http://localhost:8080");
    private UsersInEvents.UsersInEventsClient client = new UsersInEvents.UsersInEventsClient(channel);

    public async Task<IEnumerable<UserDomainModel>> findAllUsersForOneEvent(int id)
    {
        var req = new RequestUsersInEventId(){Id = id};
        using var call = client.findAllUsersForOneEvent(req);
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

    public void saveUsersInEvents(UserInEventDomainModel userInEventDomainModel)
    {
        var user = new UsersInEventsModel()
        {
            Id = userInEventDomainModel.id,
            EventId = userInEventDomainModel.eventId,
            UserId = userInEventDomainModel.userid
        };
    }

    public void deleteUser(UserInEventDomainModel userInEventDomainModel)
    {
        var req = new UsersInEventsModel()
        {
            Id = userInEventDomainModel.id,
            EventId = userInEventDomainModel.eventId,
            UserId = userInEventDomainModel.userid
        };
        client.deleteUserAsync(req);
    }
}