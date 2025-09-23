using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEvents.Domain.Entities
{
    public class EventSpeaker
    {
        public int SpeakerId { get; set; }
        public Speaker Speaker { get; set; } = null;
        public int EventId { get; set; }
        public Event Event { get; set; } = null;
    }
}