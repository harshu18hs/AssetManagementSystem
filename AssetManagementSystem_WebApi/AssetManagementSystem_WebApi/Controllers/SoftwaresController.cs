using AssetManagementSystem_WebApi.Models;
using AssetManagementSystem_WebApi.Repositories;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using HttpPutAttribute = Microsoft.AspNetCore.Mvc.HttpPutAttribute;
using HttpPatchAttribute = Microsoft.AspNetCore.Mvc.HttpPatchAttribute;
using FromBodyAttribute = Microsoft.AspNetCore.Mvc.FromBodyAttribute;
using HttpDeleteAttribute = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;
using Microsoft.AspNetCore.Identity;
using System.Security;
using System.Security.Claims;
using Microsoft.IdentityModel.JsonWebTokens;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;

namespace AssetManagementSystem_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoftwaresController : ControllerBase
    {
        private readonly ISoftwareRepository _softwareRepository;

        public SoftwaresController(ISoftwareRepository softwareRepository)
        {
            _softwareRepository = softwareRepository;
        }


        [Authorize(Roles = UserRoles.Admin)]
        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<Software>>> Search(string Software_Id)
        {
            try
            {
                var result = await _softwareRepository.Search(Software_Id);
                if (result.Any())
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }
        }
        [Authorize(Roles = UserRoles.Admin)]
        [HttpGet]
        public async Task<IEnumerable<Software>> GetHardware()
        {
            return await _softwareRepository.Get();
        }
        [Authorize(Roles = UserRoles.Admin)]
        [HttpGet("{Software_Id:int}")]
        public async Task<ActionResult<Software>> GetSoftwares(int Software_Id)
        {
            var softwares = await _softwareRepository.Get(Software_Id);
            if (softwares == null)
            {
                return Ok("No Book Available");
            }
            return Ok(softwares);
        }
        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost("PostBooks")]
        public async Task<ActionResult<Software>> PostSoftwares([FromBody] Software Software)
        {
            var newHardware = await _softwareRepository.Create(Software);
            return CreatedAtAction(nameof(GetSoftwares), new { Software_Id = newHardware.Software_Id }, newHardware);
        }
        [Authorize(Roles = UserRoles.Admin)]
        [HttpPut]
        public async Task<ActionResult<Software>> PutSoftwares(int Software_Id, [FromBody] Software Software)
        {
            if (Software_Id != Software.Software_Id) 
            {
                return BadRequest();
            }
            await _softwareRepository.Update(Software);
            return Ok(Software);
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpDelete("{Software_Id}")]
        public async Task<ActionResult> Delete(int Software_Id)
        {
            var HardwareToDelete = await _softwareRepository.Get(Software_Id);
            if (HardwareToDelete == null)
                return NotFound();
            await _softwareRepository.Delete(HardwareToDelete.Software_Id);
            return NoContent();
        }


    }
}