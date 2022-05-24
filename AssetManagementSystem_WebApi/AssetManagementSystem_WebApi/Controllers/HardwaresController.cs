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
    public class HardwaresController : ControllerBase
    {
        private readonly IHardwareRepository _hardwareRepository;

        public HardwaresController(IHardwareRepository hardwareRepository)
        {
            _hardwareRepository = hardwareRepository;
        }


        [Authorize(Roles = UserRoles.Admin)]
        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<Hardware>>> Search(string Hardware_Type)
        {
            try
            {
                var result = await _hardwareRepository.Search(Hardware_Type);
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
        public async Task<IEnumerable<Hardware>> GetHardware()
        {
            return await _hardwareRepository.Get();
        }
        [Authorize(Roles = UserRoles.Admin)]
        [HttpGet("{Model_No:int}")]
        public async Task<ActionResult<Hardware>> GetHardwares(int Model_No)
        {
            var hardwares = await _hardwareRepository.Get(Model_No);
            if (hardwares == null)
            {
                return Ok("No Book Available");
            }
            return Ok(hardwares);
        }
        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost("PostBooks")]
        public async Task<ActionResult<Hardware>> PostHardwares([FromBody] Hardware hardware)
        {
            var newHardware = await _hardwareRepository.Create(hardware);
            return CreatedAtAction(nameof(GetHardwares), new { Model_No = newHardware.Model_No }, newHardware);
        }
        [Authorize(Roles = UserRoles.Admin)]
        [HttpPut]
        public async Task<ActionResult<Hardware>> PutHardwares(int Model_No, [FromBody] Hardware hardware)
        {
            if (Model_No != hardware.Model_No)
            {
                return BadRequest();
            }
            await _hardwareRepository.Update(hardware);
            return Ok(hardware);
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpDelete("{Model_No}")]
        public async Task<ActionResult> Delete(int Model_No)
        {
            var HardwareToDelete = await _hardwareRepository.Get(Model_No);
            if (HardwareToDelete == null)
                return NotFound();
            await _hardwareRepository.Delete(HardwareToDelete.Model_No);
            return NoContent();
        }


    }
}