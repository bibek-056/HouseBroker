using AutoMapper;
using HouseBroker.Core.DTOs.PropertyDTOs;
using HouseBroker.Core.Models;
using HouseBroker.Infastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HouseBroker.WebAPIs.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController: ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepo _genericRepo;

        public PropertiesController(IGenericRepo genericRepo, IMapper mapper)
        {
            _genericRepo = genericRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<PropertyReadDTO>>> GetProperties()
        {
            var properties = await _genericRepo.GetAll<Property>(data => data.DateDeleted == null);
            var readProperties = _mapper.Map<List<PropertyReadDTO>>(properties);
            return Ok(readProperties);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<PropertyReadDTO>>> GetProperty(Guid id)
        {
            var property = await _genericRepo.GetById<Property>(data => data.PropertyId == id && data.DateDeleted == null);

            if (property == null)
            {
                return NotFound();
            }
            else
            {
                var returnProperty = _mapper.Map<PropertyReadDTO>(property);
                return Ok(returnProperty);
            }
        }

        [HttpPost]
        public async Task<ActionResult<PropertyReadDTO>> PostProperty(PropertyCreateDTO propertyCreateDTO)
        {
            var property = _mapper.Map<Property>(propertyCreateDTO); 
            property.DateCreated = DateTime.Now;
            var newProperty = await _genericRepo.AddInfo(property);
            var returnProperty = _mapper.Map<PropertyReadDTO>(newProperty);
            return CreatedAtAction("GetProperty", new { id = newProperty.PropertyId }, returnProperty);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PropertyReadDTO>> PutProperty(Guid id, PropertyUpdateDTO propertyUpdateDTO)
        {
            var prop = await _genericRepo.GetById<Property>(data => data.PropertyId == id && data.DateDeleted == null);

            if (id != propertyUpdateDTO.PropertyId)
            {
                return BadRequest();
            }
            if (prop == null)
            {
                throw new Exception($"Property {id} is not found.");
            }
            _mapper.Map(propertyUpdateDTO, prop);
            prop.DateModified = DateTime.Now;
            await _genericRepo.UpdateInfo(prop);
            var returnData = _mapper.Map<PropertyReadDTO>(prop);
            return Ok(returnData);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProperty(Guid id)
        {
            var property = await _genericRepo.GetById<Property>(data => data.PropertyId == id && data.DateDeleted == null);
            if (property == null)
            {
                return NotFound();
            }

            property.DateDeleted = DateTime.Now;
            property.DateModified = DateTime.Now;
            await _genericRepo.UpdateInfo(property);

            return NoContent();
        }

    }
}
