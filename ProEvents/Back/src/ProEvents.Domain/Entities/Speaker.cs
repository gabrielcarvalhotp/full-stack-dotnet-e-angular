using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEvents.Domain.Entities
{
    public class Speaker : Entity
    {
        public string Name { get; set; }
        public string MiniCurriculum { get; set; }
        public string ImageURL { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public List<SocialMedia> SocialMedias { get; } = new List<SocialMedia>();
        public List<EventSpeaker> EventSpeakers { get; } = new List<EventSpeaker>();
    }
}