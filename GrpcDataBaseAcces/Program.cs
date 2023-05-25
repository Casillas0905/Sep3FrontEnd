// See https://aka.ms/new-console-template for more information

using Domain.Models;
using Grpc.Net.Client;
using GrpcClasses.Event;
using GrpcClasses.User;

Console.WriteLine("Hello, World!");
var channel = GrpcChannel.ForAddress("http://localhost:8080");
var eventClient = new UserGrpc.UserGrpcClient(channel);
//var logic= new UserLogic
var input = new EventModel() { Id = 78, Description = "me llamo juan", MadeById = 1, Title = "mi culo" };
var user = new UserModel() {
    //Id = 5, 
    Username = "iker4",
    Password = "iker",
    Email = "email",
    FirstName = "firstName",
    LastName = "lastName",
    Birthday = "birthday",
    Description = "description",
    NumberOfMatches = 5,
    Note = "note",
    Photo1 = "photo",
    Photo2 = "photo",
    Photo4 = "photo",
    Photo3 = "photo",
    Photo5 = "photo",
    Gender = "gender",
    Preference = "prefrenece",
    Horoscope = "horoscope",
    Occupation = "occupation",
    City = "city",
    Education = "education",
    Drink = true,
    Administrator = false
};
eventClient.saveUserAsync(user);
//var reply = eventClient.saveEventAsync(input);
Console.WriteLine("methods done");
//var reply2 = await userClient.saveUserAsync(user);
//Console.WriteLine(reply2.ToString());
Console.ReadLine();