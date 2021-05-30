using Inventors.API.Contracts.V1.Requests;
using Inventors.API.Contracts.V1.Responses;
using Inventors.API.Domain;
using Inventors.API.Services;
using Inventors.API.V1.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inventors.API.V1.Controllers
{
    [ApiController]
    public class InventorsController : ControllerBase
    {

        private readonly IInventorService _inventorService;

        public InventorsController(IInventorService inventorService)
        {
            _inventorService = inventorService;
        }

        [HttpGet(ApiRoutes.Inventors.GetAll)]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _inventorService.GetInventorsAsync());
        }

        [HttpGet(ApiRoutes.Inventors.Get)]
        public async Task<IActionResult> GetInventor([FromRoute] long id)
        {
            var inventor = await _inventorService.GetInventorByIdAsync(id);

            if (inventor == null)
            {
                return NotFound();
            }

            var inventorResponse = new InventorResponse
            {
                FirstName = inventor.FirstName,
                LastName = inventor.LastName
            };

            return Ok(inventorResponse);
        }

        [HttpPost(ApiRoutes.Inventors.Create)]
        public async Task<IActionResult> GetInventor([FromBody] InventorRequest request)
        {
            var inventor = new Inventor
            {
                FirstName = request.FirstName,
                LastName = request.LastName
            };

            var success = await _inventorService.Create(inventor);

            if (!success)
            {
                return BadRequest(new ApiResponse<Inventor>(new List<string>() { "Something went wrong" }));
            }
            return Created("", new ApiResponse<Inventor>(inventor));
        }
    }
}
