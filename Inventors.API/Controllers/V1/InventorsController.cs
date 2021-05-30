using AutoMapper;
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
        private readonly IMapper _mapper;

        public InventorsController(IInventorService inventorService, IMapper mapper)
        {
            _inventorService = inventorService;
            _mapper = mapper;
        }

        [HttpGet(ApiRoutes.Inventors.GetAll)]
        public async Task<IActionResult> GetAllAsync()
        {
            var inventors = await _inventorService.GetInventorsAsync();
            var result = _mapper.Map<IEnumerable<Inventor>, IEnumerable<InventorResponse>>(inventors);
            return Ok(result);
        }

        [HttpGet(ApiRoutes.Inventors.Get)]
        public async Task<IActionResult> GetInventor([FromRoute] long id)
        {
            var inventor = await _inventorService.GetInventorByIdAsync(id);

            if (inventor == null)
            {
                return NotFound();
            }

            var inventorResponse = _mapper.Map<Inventor, InventorResponse>(inventor);

            return Ok(inventorResponse);
        }

        [HttpPost(ApiRoutes.Inventors.Create)]
        public async Task<IActionResult> CreateInventor([FromBody] InventorRequest request)
        {
            if (!request.IsValid(out var errorMessages))
            {
                return BadRequest(errorMessages);
            }
            var inventor = new Inventor
            {
                FirstName = request.FirstName,
                LastName = request.LastName
            };

            var success = await _inventorService.Create(inventor);

            if (!success)
            {
                return BadRequest("Something went wrong");
            }

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUrl = baseUrl + "/" + ApiRoutes.Inventors.Get.Replace("{id}", inventor.Id.ToString());

            var inventorResponse = _mapper.Map<Inventor, InventorResponse>(inventor);

            return Created(locationUrl, inventorResponse);
        }
    }
}
