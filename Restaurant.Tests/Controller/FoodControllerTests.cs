using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Restaurant_Common.Models;
using Restaurant_WebApiServer.Controllers;
using Restaurant_WebApiServer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Tests.Controller
{
    public class FoodControllerTests
    {
        private readonly IFoodRepository _foodRepository;
        private readonly IMapper _mapper; 
        public FoodControllerTests()
        {
            _foodRepository = A.Fake<IFoodRepository>();
            _mapper = A.Fake<IMapper>();
        }

        [Fact]
        public void FoodController_GetFoods_ReturnSuccess()
        {
            //Arrange
            var foods = A.Fake<ICollection<Food>>();
            var foodList = A.Fake<List<Food>>();
            A.CallTo(() => _mapper.Map<List<Food>>(foods)).Returns(foodList);
            var controller = new FoodController(_foodRepository, _mapper);

            //Act
            var result = controller.Get();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public void FoodController_CreateFood_ReturnSuccess()
        {
            //Arrange
            var food = A.Fake<Food>();
            var foodMap = A.Fake<Food>();
            var foodCreate = A.Fake<Food>(); 
            var foods = A.Fake<ICollection<Food>>();
            var foodList = A.Fake<ICollection<Food>>();

            //A.CallTo(() => _foodRepository.GetFoods().Where(c => c.Name.Trim().ToUpper() == foodCreate.Name.TrimEnd().ToUpper())
            //    .FirstOrDefault()).Returns(food);
            A.CallTo(() => _mapper.Map<Food>(foodCreate)).Returns(food);
            A.CallTo(() => _foodRepository.AddFood(foodMap));

            var controller = new FoodController(_foodRepository, _mapper);

            //Act
            var result = controller.Post(foodCreate);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(OkObjectResult));
        }
    }
}
