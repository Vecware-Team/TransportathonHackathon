using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TransportathonHackathon.Domain.Entities.Identity;
using TransportathonHackathon.WebAPI.Dtos;

namespace TransportathonHackathon.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly RoleManager<AppRole> _roleManager;

        public RolesController(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] string roleName)
        {
            AppRole role = new AppRole() { Name = roleName };
           IdentityResult result =  await _roleManager.CreateAsync(role);
            if(!result.Succeeded)
                return BadRequest(result);

            return Ok(role);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            AppRole? role = await _roleManager.FindByIdAsync(id.ToString());
            if (role is null)
                return BadRequest();

            IdentityResult result = await _roleManager.DeleteAsync(role);
            if (!result.Succeeded)
                return BadRequest(result);

            return Ok(role);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteByName([FromQuery] string name)
        {
            AppRole? role = await _roleManager.FindByNameAsync(name);
            if (role is null)
                return BadRequest();

            IdentityResult result = await _roleManager.DeleteAsync(role);
            if (!result.Succeeded)
                return BadRequest(result);

            return Ok(role);
        }
        
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] RoleUpdateDto roleUpdateDto)
        {
            AppRole? role = await _roleManager.FindByIdAsync(roleUpdateDto.Id.ToString());
            if (role is null)
                return BadRequest();

            role.Name = roleUpdateDto.Name;
            IdentityResult result = await _roleManager.UpdateAsync(role);
            if (!result.Succeeded)
                return BadRequest(result);

            return Ok(role);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            AppRole? role = await _roleManager.FindByIdAsync(id.ToString());
            if (role is null)
                return BadRequest(role);

            return Ok(role);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetByName([FromRoute] string name)
        {
            AppRole? role = await _roleManager.FindByNameAsync(name);
            if (role is null)
                return BadRequest(role);

            return Ok(role);
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            List<AppRole> role = _roleManager.Roles.ToList();
            return Ok(role);
        }
    }
}
