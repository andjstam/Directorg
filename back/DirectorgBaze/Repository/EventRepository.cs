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
        public async Task<Event> AddEvent(Event newEvent)
        {
            await _eventCollection.InsertOneAsync(newEvent);
            return newEvent;
        }

        public async Task<bool> DeleteEvent(string idEvent)
        {
            FilterDefinition<Event> filter = Builders<Event>.Filter.Eq(e => e.Id, idEvent);
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

        public async Task<Event> UpdateEvent(Event newEvent)
        {
            
            return await _eventCollection
                         .FindOneAndReplaceAsync(
                             filter: e => e.Id == newEvent.Id,
                             replacement: newEvent);
        }

        //EVENTSIGNED
        public async Task<EventSignedEmployed> AddEventSigned(EventSignedEmployed newEventSigned)
        {
            await _eventSignedCollection
                    .InsertOneAsync(newEventSigned);
            return newEventSigned;

        }

        public async Task<bool> DeleteEventSigned(string idEventSigned)
        {
            FilterDefinition<EventSignedEmployed> filter = Builders<EventSignedEmployed>.Filter.Eq(e => e.Id, idEventSigned);
            DeleteResult deleteResult = await _eventSignedCollection
                                              .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<IEnumerable<EventSignedEmployed>> GetAllEventsSigned()
        {
            return await _eventSignedCollection
                         .Find(p => true)
                         .ToListAsync();
        }

        public async Task<IEnumerable<EventSignedEmployed>> GetAllEventsSignedForUser(string userId)
        {
            return await _eventSignedCollection
                            .Find(ev => ev.UserId == userId)
                            .ToListAsync();
        }

        //EVENTEMPLYED
        public async Task<EventSignedEmployed> AddEventEmplyed(EventSignedEmployed newEventEmplyed)
        {
            await _eventEmployedCollection
                    .InsertOneAsync(newEventEmplyed);
            return newEventEmplyed;
        
        }
        public async Task<bool> DeleteEventEmplyed(string idEventEmplyed)
        {
            FilterDefinition<EventSignedEmployed> filter = Builders<EventSignedEmployed>.Filter.Eq(e => e.Id, idEventEmplyed);
            DeleteResult deleteResult = await _eventEmployedCollection
                                              .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<IEnumerable<EventSignedEmployed>> GetAllEventsEmployedForUser(string userId)
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
