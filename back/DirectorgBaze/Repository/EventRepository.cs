using DirectorgBaze.DBContext;
using DirectorgBaze.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirectorgBaze.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly IDirectorgDBContex _context;
        private readonly IMongoCollection<Event> _eventCollection;
        private readonly IMongoCollection<EventSignedEmployed> _eventSignedCollection;
        private readonly IMongoCollection<EventSignedEmployed> _eventEmployedCollection;

        public EventRepository(IDirectorgDBContex context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _eventCollection = _context.eventsCollection;
            _eventSignedCollection = _context.eventsSignedCollection;
            _eventEmployedCollection = _context.eventsEmployedCollection;
        }

        //EVENT
        public async Task AddEvent(Event newEvent)
        {
            await _eventCollection.InsertOneAsync(newEvent);
        }

        public async Task<bool> DeleteEvent(Event ev)
        {
            FilterDefinition<Event> filter = Builders<Event>.Filter.Eq(e => e.Id, ev.Id);
            DeleteResult deleteResult = await _eventCollection
                                              .DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<IEnumerable<Event>> GetAllEvents()
        {
            return await _eventCollection
                           .Find(p => true)
                           .ToListAsync();
        }
        public async Task<IEnumerable<Event>> GetEventsByDirectorsId(string directorsId)
        {
            return await _eventCollection
                            .Find(ev => ev.DirectorId == directorsId)
                            .ToListAsync();
        }

        public async Task<bool> UpdateEvent(Event newEvent)
        {
            ReplaceOneResult updateResult =
                 await _eventCollection
                         .ReplaceOneAsync(
                             filter: e => e.Id == newEvent.Id,
                             replacement: newEvent);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

        //EVENTSIGNED
        public async Task AddEventSigned(EventSignedEmployed newEventSigned)
        {
            await _eventSignedCollection
                    .InsertOneAsync(newEventSigned);

        }

        public async Task<bool> DeleteEventSigned(string idEventSigned)
        {
            FilterDefinition<EventSignedEmployed> filter = Builders<EventSignedEmployed>.Filter.Eq(e => e.Id, idEventSigned);
            DeleteResult deleteResult = await _eventSignedCollection
                                              .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<IEnumerable<EventSignedEmployed>> GetAllEventSignedForUser(string userId)
        {
            return await _eventSignedCollection
                            .Find(ev => ev.UserId == userId)
                            .ToListAsync();
        }

        public async Task<IEnumerable<EventSignedEmployed>> GetAllEventsSigned()
        {
            return await _eventSignedCollection
                         .Find(p => true)
                         .ToListAsync();
        }

        //EVENTEMPLYED
        public async Task AddEventEmplyed(EventSignedEmployed newEventEmplyed)
        {
            await _eventEmployedCollection
                    .InsertOneAsync(newEventEmplyed);
        }
        public async Task<bool> DeleteEventEmplyed(string idEventEmplyed)
        {
            FilterDefinition<EventSignedEmployed> filter = Builders<EventSignedEmployed>.Filter.Eq(e => e.Id, idEventEmplyed);
            DeleteResult deleteResult = await _eventEmployedCollection
                                              .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<IEnumerable<EventSignedEmployed>> GetAllEventEmployedForUser(string userId)
        {
            return await _eventEmployedCollection
                            .Find(ev => ev.UserId == userId)
                            .ToListAsync();
        }

        public async Task<IEnumerable<EventSignedEmployed>> GetAllEventsEmployed()
        {
            return await _eventEmployedCollection
                          .Find(p => true)
                          .ToListAsync();
        }


    }
}
