using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using People.Api.Controllers;
using People.Application.Interfaces;
using People.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace People.Api.Unit.Tests.Controllers
{
    [TestFixture]
    public class PeopleControllerTests
    {
        private PeopleController testPeopleController;
        private Mock<IPersonService> mockPersonService;

        [SetUp]
        public void SetUp()
        {
            mockPersonService = new Mock<IPersonService>();
            testPeopleController = new PeopleController(mockPersonService.Object);
        }

        [Test]
        public async Task GetAll_Success()
        {
            // Arrage
            List<Person> personsExpected = new List<Person>()
            {
                new Person { Id = 1, FirstName = "John", LastName= "Doe", DateOfBirth =new DateTime(1974, 10, 8), Sex= 'M'}
            };

            mockPersonService.Setup(m => m.GetAllAsync()).ReturnsAsync(personsExpected);

            // Act
            var result = await testPeopleController.GetAll() as ObjectResult;


            // Asserts
            Assert.IsNotNull(result);
            Assert.That(result.StatusCode, Is.EqualTo((int)HttpStatusCode.OK));
            var response = result.Value as List<Person>;
            Assert.IsNotNull(response);
            Assert.IsNotEmpty(response);
            Assert.That(response.Count, Is.EqualTo(1));

            mockPersonService.Verify(m => m.GetAllAsync(), Times.Once);
        }
    }
}

