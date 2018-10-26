using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Domain
{
    public class Organizer
    {
        public int OrganizerId { get; set; }
        public string OrganizerName { get; set; }
        public string OrganizerPicture { get; set; }
        public int NumPastEvents { get; set; }
        public int NumFutureEvents { get; set; }
    }
}
