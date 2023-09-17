using Core.API.Controllers;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using Core.Security.Jwt;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TransportathonHackathon.Application.Features.Carriers.Commands.Create;
using TransportathonHackathon.Application.Features.Companies.Commands.Create;
using TransportathonHackathon.Application.Features.Customers.Commands.Create;
using TransportathonHackathon.Application.Features.Drivers.Commands.CreateDriver;
using TransportathonHackathon.Domain.Entities.Identity;
using TransportathonHackathon.WebAPI.Dtos.Auth;
using TransportathonHackathon.WebAPI.Dtos.Carrier;
using TransportathonHackathon.WebAPI.Dtos.Company;
using TransportathonHackathon.WebAPI.Dtos.Customer;
using TransportathonHackathon.WebAPI.Dtos.Driver;

namespace TransportathonHackathon.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenHelper<Guid> _tokenHelper;

        public AuthController(UserManager<AppUser> userManager, ITokenHelper<Guid> tokenHelper)
        {
            _userManager = userManager;
            _tokenHelper = tokenHelper;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterCompany([FromBody] CreateCompanyDto command)
        {
            CreatedCompanyResponse response = await Mediator.Send(Mapper.Map<CreateCompanyCommand>(command));
            AppUser user = await _userManager.FindByIdAsync(response.AppUserId.ToString());
            bool result = await _userManager.CheckPasswordAsync(user, command.Password);
            if (!result)
                throw new Exception("Giriş bilgileri hatalı");


            await _userManager.AddClaimAsync(user, new System.Security.Claims.Claim("UserType", "Company"));
            AccessToken token = _tokenHelper.CreateToken(user, await _userManager.GetClaimsAsync(user), await _userManager.GetRolesAsync(user));
            return Ok(token);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterCustomer([FromBody] CreateCustomerDto command)
        {
            CreatedCustomerResponse response = await Mediator.Send(Mapper.Map<CreateCustomerCommand>(command));
            AppUser user = await _userManager.FindByIdAsync(response.AppUserId.ToString());
            bool result = await _userManager.CheckPasswordAsync(user, command.Password);
            if (!result)
                throw new Exception("Giriş bilgileri hatalı");

            await _userManager.AddClaimAsync(user, new System.Security.Claims.Claim("UserType", "Customer"));
            AccessToken token = _tokenHelper.CreateToken(user, await _userManager.GetClaimsAsync(user), await _userManager.GetRolesAsync(user));
            return Ok(token);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterDriver([FromBody] CreateDriverDto command)
        {
            CreatedDriverResponse response = await Mediator.Send(Mapper.Map<CreateDriverCommand>(command));
            AppUser user = await _userManager.FindByIdAsync(response.EmployeeId.ToString());
            bool result = await _userManager.CheckPasswordAsync(user, command.Password);
            if (!result)
                throw new Exception("Giriş bilgileri hatalı");

            await _userManager.AddClaimAsync(user, new System.Security.Claims.Claim("UserType", "Driver"));
            AccessToken token = _tokenHelper.CreateToken(user, await _userManager.GetClaimsAsync(user), await _userManager.GetRolesAsync(user));
            return Ok(token);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterCarrier([FromBody] CreateCarrierDto command)
        {
            CreatedCarrierResponse response = await Mediator.Send(Mapper.Map<CreateCarrierCommand>(command));
            AppUser user = await _userManager.FindByIdAsync(response.EmployeeId.ToString());
            bool result = await _userManager.CheckPasswordAsync(user, command.Password);
            if (!result)
                throw new Exception("Giriş bilgileri hatalı");

            await _userManager.AddClaimAsync(user, new System.Security.Claims.Claim("UserType", "Carrier"));
            AccessToken token = _tokenHelper.CreateToken(user, await _userManager.GetClaimsAsync(user), await _userManager.GetRolesAsync(user));
            return Ok(token);
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            AppUser? user = await _userManager.FindByEmailAsync(loginDto.EmailorUserName) ?? await _userManager.FindByNameAsync(loginDto.EmailorUserName);
            if (user is null)
                throw new NotFoundException("Giriş bilgileri hatalı");

            bool result = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (!result)
                throw new Exception("Giriş bilgileri hatalı");

            AccessToken token = _tokenHelper.CreateToken(user, await _userManager.GetClaimsAsync(user), await _userManager.GetRolesAsync(user));
            return Ok(token);
        }
    }
}
