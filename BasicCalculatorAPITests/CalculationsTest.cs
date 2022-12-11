﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using BasicCalculatorAPI.Controllers;
using Xunit;
using BasicCalculatorAPI;
using BasicCalculatorAPI.Services;
using Calculator.Data;
using Calculator.Models;

namespace BasicCalculatorAPITests
{
    public class CalculationsTest
    {
        private readonly Mock<ICalculationRepository> _mockRepository;
        private readonly Mock<ICalculator> _mockCalculator;
        private readonly Mock<CalculatorContext> _mockDbContext;
        private List<Calculation> _listOfCalculations;
        private CalculationsController _calculationsController;
        private readonly DbContextOptions _options;

        public CalculationsTest()
        {
            _options = new DbContextOptions<CalculatorContext>();
            _mockCalculator = new Mock<ICalculator>();
            _mockDbContext = new Mock<CalculatorContext>(_options);
            _mockRepository = new Mock<ICalculationRepository>();
            _listOfCalculations = new List<Calculation>();
            _calculationsController = new CalculationsController(_mockDbContext.Object, _mockRepository.Object, _mockCalculator.Object);
        }

        private IEnumerable<Calculation> GetTestCalculations()
        {
            _listOfCalculations.Add(new Calculation { Id = 1, Type = "Add", Expression = "3 + 5", CreateDate = DateTime.Now.ToLongDateString(), Result = 8 });
            _listOfCalculations.Add(new Calculation { Id = 2, Type = "Subtract", Expression = "12 - 9", CreateDate = DateTime.Now.ToLongDateString(), Result = 3 });
            _listOfCalculations.Add(new Calculation { Id = 3, Type = "Multiply", Expression = "7 * 4", CreateDate = DateTime.Now.ToLongDateString(), Result = 28 });
            _listOfCalculations.Add(new Calculation { Id = 4, Type = "Divide", Expression = "8 / 2", CreateDate = DateTime.Now.ToLongDateString(), Result = 4 });

            return _listOfCalculations;
        }

        [Fact]
        public void CreateReturnsCreatedAtActionAndAddsCalculation()
        {
            var controller = new CalculationsController(_mockDbContext.Object, _mockRepository.Object, _mockCalculator.Object);
            var newCalculation = new Calculation()
            {
                Type = "Add",
                Expression = "88 + 11",
                CreateDate = DateTime.Now.ToLongDateString(),
                Result = 99
            };

            var result = controller.Create(newCalculation, newCalculation.Expression).Result;

            var createdAtActionResult = Xunit.Assert.IsType<CreatedAtActionResult>(result);
            Assert.Null(createdAtActionResult.ControllerName);
            Assert.Equal("GetById", createdAtActionResult.ActionName);
            _mockRepository.Verify(r => r
                .CreateAsync(newCalculation));
        }
    }
}
