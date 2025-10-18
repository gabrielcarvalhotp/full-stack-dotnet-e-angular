using System;

namespace ProEvents.Domain.Entities;

public class Entity
{
    public int Id { get; private set; }
    public DateTime CreatedAt { get; set; }
}