using Microsoft.AspNetCore.Mvc;
using HouseBroker.Core.Models;
using HouseBroker.Infastructure.Repositories;
using AutoMapper;
using HouseBroker.Core.DTOs.PropertyDTOs;
using Microsoft.AspNetCore.Authorization;

namespace HouseBroker.WebAPIs.Controllers
{
    [Authorize]
    public class PropertiesController : Controller
    {
        private readonly IGenericRepo _genericRepo;
        private readonly IMapper _mapper;

        public PropertiesController(IGenericRepo genericRepo, IMapper mapper)
        {
            _genericRepo = genericRepo;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index(string searchString)
        {
            var properties = _mapper.Map<List<PropertyReadDTO>>(
                await _genericRepo.GetAll<Property>(data => data.DateDeleted == null));

            if (!string.IsNullOrEmpty(searchString))
            {
                return View(properties.Where(p => p.PropertyName.ToLower().Contains(searchString.ToLower()) || p.PropertyType.ToLower().Contains(searchString.ToLower())));
            } else
            {
                return View(properties);
            }
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @property = _mapper.Map<PropertyReadDTO>(
                await _genericRepo.GetById<Property>(data => data.PropertyId == id && data.DateDeleted == null));
            if (@property == null)
            {
                return NotFound();
            }

            return View(@property);
        }
        [Authorize (Roles ="House Broker")]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "House Broker")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PropertyName,State,District,Municipality,WardNo,Location,PhotoURL,PropertyDescription,PropertyType,AskingPrice,BrokerContact")] PropertyCreateDTO @propertyCreateDTO)
        {
            var newProperty = _mapper.Map<Property>(@propertyCreateDTO);
            if (ModelState.IsValid)
            {
                newProperty.DateCreated = DateTime.Now;
                await _genericRepo.AddInfo<Property>(newProperty);
                return RedirectToAction(nameof(Index));
            }
            return View(newProperty);
        }
        [Authorize(Roles = "House Broker")]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @property = _mapper.Map<PropertyUpdateDTO>(
                await _genericRepo.GetById<Property>(data => data.PropertyId == id && data.DateDeleted == null)
                );
            if (@property == null)
            {
                return NotFound();
            }
            return View(@property);
        }
        [Authorize(Roles = "House Broker")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("PropertyId,PropertyName,State,District,Municipality,WardNo,Location,PhotoURL,PropertyDescription,PropertyType,AskingPrice,BrokerContact")] PropertyUpdateDTO @propertyUpdateDTO)
        {
            if (id != propertyUpdateDTO.PropertyId)
            {
                return NotFound();
            }

            var updateProperty = _mapper.Map<Property>(propertyUpdateDTO);
            if (ModelState.IsValid)
            {
                try
                {
                    updateProperty.DateModified = DateTime.Now;
                    await _genericRepo.UpdateInfo<Property>(updateProperty);
                }
                catch
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(updateProperty);
        }
        [Authorize(Roles = "House Broker")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @property = _mapper.Map<PropertyReadDTO>(
                await _genericRepo.GetById<Property>(data => data.PropertyId == id && data.DateDeleted == null)
                );
            if (@property == null)
            {
                return NotFound();
            }

            return View(@property);
        }
        [Authorize(Roles = "House Broker")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var @property = await _genericRepo.GetById<Property>(data => data.PropertyId == id && data.DateDeleted == null);
            if (@property != null)
            {
                await _genericRepo.DeleteInfo<Property>(@property);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
