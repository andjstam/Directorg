using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DirectorgBaze.Models;

namespace DirectorgBaze.Repository
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetAllEvents();
        Task<IEnumerable<Event>> GetEventsByDirectorsId(string directorsId);
        Task<Event> AddEvent(Event newEvent);
        Task<Event> UpdateEvent(Event newEvent);
        Task<bool> DeleteEvent(string idEvent);

        Task<IEnumerable<EventSignedEmployed>> GetAllEventsSigned();
        Task<IEnumerable<EventSignedEmployed>> GetAllEventsSignedForUser(string userId);
        Task<EventSignedEmployed> AddEventSigned(EventSignedEmployed newEventSigned);
        Task<bool> DeleteEventSigned(string idEventSigned);

        Task<IEnumerable<EventSignedEmployed>> GetAllEventsEmployed();
        Task<IEnumerable<EventSignedEmployed>> GetAllEventsEmployedForUser(string userId);
        Task<EventSignedEmployed> AddEventEmplyed(EventSignedEmployed newEventSigned);
        Task<bool> DeleteEventEmplyed(string idEventEmplyed);

    }
}
