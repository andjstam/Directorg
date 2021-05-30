using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DirectorgBaze.Models;

namespace DirectorgBaze.Repository
{
    interface IEventRepository
    {
        Task<IEnumerable<Event>> GetAllEvents();
        Task<IEnumerable<Event>> GetEventsByDirectorsId(string directorsId);
        Task AddEvent(Event newEvent);
        Task<bool> UpdateEvent(Event newEvent);
        Task<bool> DeleteEvent(Event ev);

        Task<IEnumerable<EventSignedEmployed>> GetAllEventsSigned();
        Task<IEnumerable<EventSignedEmployed>> GetAllEventSignedForUser(string userId);
        Task AddEventSigned(EventSignedEmployed newEventSigned);
        Task<bool> DeleteEventSigned(string idEventSigned);

        Task<IEnumerable<EventSignedEmployed>> GetAllEventsEmployed();
        Task<IEnumerable<EventSignedEmployed>> GetAllEventEmployedForUser(string userId);
        Task AddEventEmplyed(EventSignedEmployed newEventSigned);
        Task<bool> DeleteEventEmplyed(string idEventEmplyed);

    }
}
