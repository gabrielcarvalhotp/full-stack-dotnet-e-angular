using System;
using System.Collections.Generic;

namespace ProEvents.Domain.Entities
{
    public class Event : Entity
    {
        public string Location { get; set; }
        public DateTime? EventDate { get; set; }
        public string Theme { get; set; }
        public int NumberPeople { get; set; }
        public string ImageURL { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public IEnumerable<Batch> Batchs { get; set; }
        public IEnumerable<SocialMedia> SocialMedias { get; set; }
        public IEnumerable<EventSpeaker> EventSpeakers { get; set; }
    }
}