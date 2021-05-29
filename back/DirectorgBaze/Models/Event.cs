using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DirectorgBaze.Models
{
    public class Event
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } //string?

        public string Name { get; set; }

        public string Description { get; set; }

        public string UserType { get; set; }

        public int UserCount { get; set; }

        //strani kljuc??
        [BsonRepresentation(BsonType.ObjectId)]
        public string DirectorId { get; set; }


    }
}
