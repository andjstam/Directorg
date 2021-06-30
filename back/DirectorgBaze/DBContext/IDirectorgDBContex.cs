using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DirectorgBaze.Models;
using MongoDB.Driver;

namespace DirectorgBaze.DBContext
{
    public interface IDirectorgDBContex
    {
        IMongoCollection<LoggedUser> loggedUsersCollection { get; }
        IMongoCollection<Director> directorsCollection { get; }
        IMongoCollection<User> usersCollection { get; }
        IMongoCollection<Event> eventsCollection { get; }
        IMongoCollection<EventSignedEmployed> eventsSignedCollection { get; }
        IMongoCollection<EventSignedEmployed> eventsEmployedCollection { get; }

    }
}
