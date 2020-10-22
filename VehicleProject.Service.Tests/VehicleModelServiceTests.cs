using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using Moq;
using VehicleProject.Repository.Common;
using VehicleProject.Models;
using VehicleProject.Common.Extensions;

namespace VehicleProject.Service.Tests
{
    public class VehicleModelServiceTests
    {
        private readonly VehicleModelService _service;
        private readonly Mock<IVehicleModelRepository> _mockRepo = new Mock<IVehicleModelRepository>();
        private readonly Mock<IUnitOfWork> _unitOfWork = new Mock<IUnitOfWork>();
        public VehicleModelServiceTests()
        {
            _service = new VehicleModelService(_mockRepo.Object, _unitOfWork.Object);
        }
        [Fact]
        public async Task Models_ShouldReturn()
        {
            //Arrange
            var vehicleModels = new List<VehicleModel>()
            {
                new VehicleModel()
                {
                    Id = 1,
                    Name = "E-Class 220",
                    Abrv = "E-220",
                    VehicleMakeId = 1
                },
                new VehicleModel()
                {
                    Id = 2,
                    Name = "A-Class 180",
                    Abrv = "A-180",
                    VehicleMakeId = 2
                },
            }.AsEnumerable();
            string searchString = "";

            int page = 0;

            Filtering filter = new Filtering(searchString);
            Paging paging = new Paging(page);


            _mockRepo.Setup(x => x.GetAllModels(filter, paging)).Returns(Task.FromResult(vehicleModels));
            //Act
            var result = await _service.GetModelsList(filter, paging);

            //Assert
            result.Should().BeEquivalentTo(vehicleModels);
        }
        [Fact]
        public async Task Model_ShouldNotReturn()
        {
            //Arrange
            var vehicleModels = new List<VehicleModel>().AsEnumerable();
            string searchString = "";

            int page = 0;

            Filtering filter = new Filtering(searchString);
            Paging paging = new Paging(page);


            _mockRepo.Setup(x => x.GetAllModels(filter, paging)).Returns(Task.FromResult(vehicleModels));
            //Act
            var result = await _service.GetModelsList(filter, paging);

            //Assert
            result.Should().BeEmpty();
        }

        [Fact]
        public async Task Model_ShouldGetbyId()
        {
            //Arrange
            var modelId = 2;
            var vehicleModel = new VehicleModel()
            {
                Id = modelId,
                Name = "E-Class 220",
                Abrv = "E-220",
                VehicleMakeId = 1
            };

            _mockRepo.Setup(x => x.GetModelById(modelId)).ReturnsAsync(vehicleModel);

            //Act
            VehicleModel model = await _service.GetModelById(modelId);

            //Assert
            //Assert.Equal(modelId, model.Id);
            model.Id.Should().Be(modelId);
        }

        [Fact]
        public async Task Model_ShouldBeCreated()
        {
            //Arrange
            var vehicleModel = new VehicleModel()
            {
                Id = 1,
                Name = "E-Class 220",
                Abrv = "E-220",
                VehicleMakeId = 1
            };

            _mockRepo.Setup(x => x.AddModel(vehicleModel)).ReturnsAsync(true);

            //Act
            var result = await _service.InsertModel(vehicleModel);

            //Assert
            result.Should().BeTrue();
        }

        [Fact]
        public async Task Model_ShouldBeEdited()
        {
            //Arrange
            var vehicleModel = new VehicleModel()
            {
                Id = 1,
                Name = "E-Class 220",
                Abrv = "E-220",
                VehicleMakeId = 1
            };

            _mockRepo.Setup(x => x.Edit(vehicleModel)).ReturnsAsync(true);

            //Act
            var result = await _service.UpdateModel(vehicleModel);

            //Assert
            result.Should().BeTrue();
        }

        [Fact]
        public async Task Model_ShouldBeDeleted()
        {
            //Arrange
            var modelId = 2;

            _mockRepo.Setup(x => x.Delete(modelId)).ReturnsAsync(true);

            //Act
            var result = await _service.DeleteModel(modelId);

            //Assert
            result.Should().BeTrue();
        }
    }

}
