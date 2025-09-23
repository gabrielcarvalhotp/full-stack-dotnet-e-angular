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
        public List<Batch> Batchs { get; } = new List<Batch>();
        public List<SocialMedia> SocialMedias { get; } = new List<SocialMedia>();
        public List<EventSpeaker> EventSpeakers { get; } = new List<EventSpeaker>();
    }
}