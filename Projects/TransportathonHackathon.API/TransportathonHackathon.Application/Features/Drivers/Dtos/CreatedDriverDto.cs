﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportathonHackathon.Application.Features.Drivers.Dtos
{
    public class CreatedDriverDto
    {
        public Guid EmployeeId { get; set; }
        public bool IsOnTransitNow { get; set; }
    }
}
