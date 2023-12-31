﻿using Core.API.Controllers;
using Core.Persistence.Pagination;
using Microsoft.AspNetCore.Mvc;
using TransportathonHackathon.Application.Features.DriverLicenses.Commands.Create;
using TransportathonHackathon.Application.Features.DriverLicenses.Commands.Delete;
using TransportathonHackathon.Application.Features.DriverLicenses.Commands.Update;
using TransportathonHackathon.Application.Features.DriverLicenses.Queries.GetById;
using TransportathonHackathon.Application.Features.DriverLicenses.Queries.GetList;
using TransportathonHackathon.WebAPI.Dtos.DriverLicense;

namespace TransportathonHackathon.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DriverLicensesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDriverLicenseDto command)
        {
            CreatedDriverLicenseResponse result = await Mediator.Send(Mapper.Map<CreateDriverLicenseCommand>(command));
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteDriverLicenseDto command)
        {
            DeletedDriverLicenseResponse result = await Mediator.Send(Mapper.Map<DeleteDriverLicenseCommand>(command));
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateDriverLicenseDto command)
        {
            UpdatedDriverLicenseResponse result = await Mediator.Send(Mapper.Map<UpdateDriverLicenseCommand>(command));
            return Ok(result);
        }

        [HttpGet("{DriverId}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdDriverLicenseQuery command)
        {
            GetByIdDriverLicenseResponse result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] GetListDriverLicenseQuery command)
        {
            Paginate<GetListDriverLicenseResponse> result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
