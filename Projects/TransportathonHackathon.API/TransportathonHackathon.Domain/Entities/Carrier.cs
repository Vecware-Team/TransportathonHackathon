﻿using Core.Persistence.Entities;
using TransportathonHackathon.Domain.Entities.Identity;

namespace TransportathonHackathon.Domain.Entities
{
    public class Carrier : Entity
    {
        public Guid EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }

    }
}