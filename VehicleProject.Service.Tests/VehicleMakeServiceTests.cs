using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using FluentAssertions;
using System.Linq.Expressions;
using VehicleProject.Repository.Common;
using System.Reflection;
using VehicleProject.Models;
using VehicleProject.Common.Extensions;

namespace VehicleProject.Service.Tests
{
   public class VehicleMakeServiceTests
    {
        private VehicleMakeService _service;
        private readonly Mock<IVehicleMakeRepository> _makeRepoMock = new Mock<IVehicleMakeRepository>();
        private readonly Mock<IUnitOfWork> _uowMock = new Mock<IUnitOfWork>();

        public VehicleMakeServiceTests()
        {
            _service = new VehicleMakeService(_makeRepoMock.Object, _uowMock.Object);

        }
        [Fact]
        public async Task MakeList_ShouldReturnList()
        {
            //Arrange
            var makes = new List<VehicleMake>
            {
                new VehicleMake {Id = 1, Name = "Mercedes-Benz", Abrv = "Mercedes"},
                new VehicleMake {Id = 2, Name = "Dacia", Abrv = "Dac"},


            }.AsEnumerable();
            string searchString = "";
            
            int page = 0;

            Filtering filter = new Filtering(searchString);
            Paging paging = new Paging(page);
            

            _makeRepoMock.Setup(x => x.GetAllMakes(filter, paging)).Returns(Task.FromResult(makes));
            //Act
            var result = await _service.GetMakesList(filter, paging);
            //Assert
            
            result.Should().BeEquivalentTo(makes);

        }

        [Fact]
        public async Task MakesList_ShouldNotReturnList()
        {
            //Arrange
            var makes = new List<VehicleMake>().AsEnumerable();

            string searchString = "";

            int page = 0;

            Filtering filter = new Filtering(searchString);
            Paging paging = new Paging(page);



            _makeRepoMock.Setup(x => x.GetAllMakes(filter, paging)).Returns(Task.FromResult(makes));
            //Act
            var result = await _service.GetMakesList(filter, paging);

            //Assert
            result.Should().BeEmpty();
        }
        [Fact]
        public async Task Make_ShouldReturnOne()
        {
            //Arrange
            var Id = 1;
            var make = new VehicleMake()
            {
                Id = Id,
                Name = "Mercedes-Benz",
                Abrv = "Mercedes"
               
            };

            _makeRepoMock.Setup(x => x.GetMakeById(Id)).ReturnsAsync(make);

            //Act
            VehicleMake vehicleMake = await _service.GetMakeById(Id);

            //Assert
            
            vehicleMake.Id.Should().Be(Id);
        }

        [Fact]
        public async Task Make_ShouldBeEdited()
        {
            //Arrange
            var vehicleMake = new VehicleMake()
            {
                Id = 1,
                Name = "Mercedes-Benz",
                Abrv = "Mercedes"
            };

            _makeRepoMock.Setup(x => x.Edit(vehicleMake)).ReturnsAsync(true);

            //Act
            var result = await _service.UpdateMake(vehicleMake);

            //Assert
            result.Should().BeTrue();
        }

        [Fact]
        public async Task Make_ShouldBeCreated()
        {
            
              //Arrange
            var vehicleMake = new VehicleMake()
            {
                Id = 1,
                Name = "Mercedes-Benz",
                Abrv = "Mercedes"
               
            };

            _makeRepoMock.Setup(x => x.AddMake(vehicleMake)).ReturnsAsync(true);

            //Act
            var result = await _service.InsertMake(vehicleMake);

            //Assert
            result.Should().BeTrue();
        }
        [Fact]
        public async Task Make_ShouldBeDeleted()
        {
            //Arrange
            var Id = 1;

            _makeRepoMock.Setup(x => x.DeleteMake(Id)).ReturnsAsync(true);

            //Act
            var result = await _service.DeleteMake(Id);

            //Assert
            result.Should().BeTrue();
        }

    }


}
