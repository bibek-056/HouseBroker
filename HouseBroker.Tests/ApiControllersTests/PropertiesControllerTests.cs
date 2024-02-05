using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using HouseBroker.Core.DTOs.PropertyDTOs;
using HouseBroker.Core.Models;
using HouseBroker.Infastructure.Repositories;
using HouseBroker.WebAPIs.APIControllers;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace HouseBroker.Tests.ApiControllersTests
{
    public class PropertiesControllerTests
    {
        private readonly IGenericRepo _genericRepo;
        private readonly IMapper _mapper;
        public PropertiesControllerTests()
        {
            _genericRepo = A.Fake<IGenericRepo>();
            _mapper = A.Fake<IMapper>();
        }

        [Fact]
        public void PropertiesController_GetProperties_ReturnOk()
        {
            //Arrange
            var property = A.Fake<Property>();
            var propertyReadDTO = A.Fake<List<PropertyReadDTO>>();
            var propertiesList= A.Fake<List<Property>>();

            A.CallTo(() => _genericRepo.GetAll<Property>(A<Expression<Func<Property, bool>>>._))
           .Returns(propertiesList);

            A.CallTo(() => _mapper.Map<List<PropertyReadDTO>>(A<List<Property>>._))
                .Returns(propertyReadDTO);

            var controller = new PropertiesController(_genericRepo, _mapper);

            //Act
            var result = controller.GetProperties();
            //Assert
            result.Should().BeOfType<List<PropertyReadDTO>>();
        }

        [Fact]
        public async Task GetProperty_Returns_OkObjectResult_When_PropertyExists()
        {
            // Arrange
            var fakeProperty = A.Fake<Property>();
            var fakePropertyReadDTO = A.Fake<PropertyReadDTO>();

            A.CallTo(() => _genericRepo.GetById<Property>(A<Expression<Func<Property, bool>>>._))
                .Returns(Task.FromResult(fakeProperty));

            A.CallTo(() => _mapper.Map<PropertyReadDTO>(A<Property>._))
                .Returns(fakePropertyReadDTO);

            var controller = new PropertiesController(_genericRepo, _mapper);

            // Act
            var actionResult = await controller.GetProperty(fakeProperty.PropertyId);

            //Assert
            actionResult.Result.Should().BeAssignableTo<ActionResult<List<PropertyReadDTO>>>();
        }

    }
}
