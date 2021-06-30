using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DirectorgBaze.Models
{
    public class EventSignedEmployed
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        //oba ova su strani kljucevi???

        public string EventId { get; set; }

        public string UserId { get; set; }
    }
}
