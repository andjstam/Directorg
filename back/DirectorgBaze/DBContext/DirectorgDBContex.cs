using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using DirectorgBaze.Models;

namespace DirectorgBaze.DBContext
{
    public class DirectorgDBContex: IDirectorgDBContex
    {
        private readonly IMongoDatabase _db;
       
        public DirectorgDBContex(IConfiguration config)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            _db = client.GetDatabase("DirectorgDB");
        }

        public IMongoCollection<LoggedUser> loggedUsersCollection => _db.GetCollection<LoggedUser>("LoggedUsers");

        public IMongoCollection<Director> directorsCollection => _db.GetCollection<Director>("Directors");

        public IMongoCollection<User> usersCollection => _db.GetCollection<User>("Users");

        public IMongoCollection<Event> eventsCollection => _db.GetCollection<Event>("Events");

        public IMongoCollection<EventSignedEmployed> eventsSignedCollection => _db.GetCollection<EventSignedEmployed>("EventsSigned");

        public IMongoCollection<EventSignedEmployed> eventsEmployedCollection => _db.GetCollection<EventSignedEmployed>("EventsEmployed");
    }
}
