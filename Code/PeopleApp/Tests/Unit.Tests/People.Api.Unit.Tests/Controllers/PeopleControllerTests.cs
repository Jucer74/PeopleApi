using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using People.Api.Controllers;
using People.Api.Mapping;
using People.Application.Interfaces;
using People.Domain.Entities;
using PeopleApp.Unit.Tests.Library.Builders;
using PeopleApp.Unit.Tests.Library.Comparers;
using PeopleApp.Unit.Tests.Library.Mappers;
using PeopleApp.Unit.Tests.Library.Mothers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace People.Api.Unit.Tests.Controllers
{
    [TestFixture]
    public class PeopleControllerTests
    {
        private PeopleController testPeopleController;
        private Mock<IPersonService> mockPersonService;
        private IMapper autoMapper;

        [SetUp]
        public void SetUp()
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            autoMapper = mapperConfig.CreateMapper();


            mockPersonService = new Mock<IPersonService>();
            testPeopleController = new PeopleController(mockPersonService.Object, autoMapper);
        }

        [Test]
        public async Task GetAll_Success()
        {
            // Arrange
            //var person = new PersonBuilder()
            //                    .SetFixtureData()
            //                    //.WithFirstName("John")
            //                    //.WithLastName("Doe")
            //                    //.WithDateOfBirth(new DateTime(1974, 10, 8))
            //                    .WithSex('M')
            //                    .Build();


            //List<Person> personsExpected = new List<Person>()
            //{
            //    new Person { Id = 1, FirstName = "John", LastName= "Doe", DateOfBirth =new DateTime(1974, 10, 8), Sex= 'M'}
            //    person
            //    PersonMother.Default()
            //};

            int quantity = 3;
            List<Person> personsExpected = PersonMother.GetFixtureDataList(quantity);


            mockPersonService.Setup(m => m.GetAllAsync()).ReturnsAsync(personsExpected);

            // Act
            var result = await testPeopleController.GetAll() as ObjectResult;

            // Asserts
            Assert.IsNotNull(result);
            Assert.That(result.StatusCode, Is.EqualTo((int)HttpStatusCode.OK));
            var response = result.Value as List<Person>;
            Assert.IsNotNull(response);
            Assert.IsNotEmpty(response);
            Assert.That(response.Count, Is.EqualTo(quantity));

            Assert.IsTrue(response.SequenceEqual(personsExpected, PersonComparer.Comparer()));

            mockPersonService.Verify(m => m.GetAllAsync(), Times.Once);
        }

        [Test]
        public async Task GetById_Success()
        {
            // Arrange
            int id = 13;
            var personExpected = PersonMother.Default(id);


            mockPersonService.Setup(m => m.GetByIdAsync(id)).ReturnsAsync(personExpected);

            // Act
            var result = await testPeopleController.GetById(id) as ObjectResult;

            // Asserts
            Assert.IsNotNull(result);
            Assert.That(result.StatusCode, Is.EqualTo((int)HttpStatusCode.OK));
            var response = result.Value as Person;
            Assert.IsNotNull(response);
            Assert.That(response.Id, Is.EqualTo(id));

            mockPersonService.Verify(m => m.GetByIdAsync(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public async Task Post_Success()
        {
            // Arrange
            int id = 13;
            var personExpected = PersonMother.Default(id);
            var personRequest = PersonMother.Default();

            mockPersonService.Setup(m => m.AddAsync(personRequest)).ReturnsAsync(personExpected);

            // Act
            var result = await testPeopleController.Post(personRequest) as ObjectResult;

            // Asserts
            Assert.IsNotNull(result);
            Assert.That(result.StatusCode, Is.EqualTo((int)HttpStatusCode.OK));
            var response = result.Value as Person;
            Assert.IsNotNull(response);
            Assert.That(response, Is.EqualTo(personExpected));
            Assert.Multiple(() =>
            {
                Assert.That(response.Id, Is.EqualTo(personExpected.Id));
                Assert.That(response.FirstName, Is.EqualTo(personExpected.FirstName));
                Assert.That(response.LastName, Is.EqualTo(personExpected.LastName));
                Assert.That(response.DateOfBirth, Is.EqualTo(personExpected.DateOfBirth));
                Assert.That(response.Sex, Is.EqualTo(personExpected.Sex));
            });
            mockPersonService.Verify(m => m.AddAsync(It.IsAny<Person>()), Times.Once);
        }

        [Test]
        public async Task Put_Success()
        {
            // Arrange
            int id = 13;
            var personRequest = PersonMother.Default(id, firstName:"Mike");

            mockPersonService.Setup(m => m.UpdateAsync(id, personRequest)).Returns(Task.CompletedTask); 

            // Act
            var result = await testPeopleController.Put(id, personRequest) as OkResult;

            // Asserts
            Assert.IsNotNull(result);
            Assert.That(result.StatusCode, Is.EqualTo((int)HttpStatusCode.OK));

            mockPersonService.Verify(m => m.UpdateAsync(It.IsAny<int>(), It.IsAny<Person>()), Times.Once);
        }

        [Test]
        public async Task Delete_Success()
        {
            // Arrange
            int id = 13;

            mockPersonService.Setup(m => m.RemoveAsync(id)).Returns(Task.CompletedTask);

            // Act
            var result = await testPeopleController.Delete(id) as OkResult;

            // Asserts
            Assert.IsNotNull(result);
            Assert.That(result.StatusCode, Is.EqualTo((int)HttpStatusCode.OK));

            mockPersonService.Verify(m => m.RemoveAsync(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public async Task Create_Success()
        {
            // Arrange
            var personRequest = PersonRequestMother.Default();
            int id = 13;

            var personExpected = personRequest.ToPerson();
            personExpected.Id = id; 

            mockPersonService.Setup(m => m.AddAsync(It.IsAny<Person>())).ReturnsAsync(personExpected);

            // Act
            var result = await testPeopleController.Create(personRequest) as ObjectResult;

            // Asserts
            Assert.IsNotNull(result);
            Assert.That(result.StatusCode, Is.EqualTo((int)HttpStatusCode.OK));
            var response = result.Value as Person;
            
            Assert.IsNotNull(response);
            Assert.That(response, Is.EqualTo(personExpected));

            var personComparer = PersonMother.Default(id);

            //Assert.Multiple(() =>
            //{
            //    Assert.That(response.Id, Is.EqualTo(personExpected.Id));
            //    Assert.That(response.FirstName, Is.EqualTo(personExpected.FirstName));
            //    Assert.That(response.LastName, Is.EqualTo(personExpected.LastName));
            //    Assert.That(response.DateOfBirth, Is.EqualTo(personExpected.DateOfBirth));
            //    Assert.That(response.Sex, Is.EqualTo(personExpected.Sex));
            //});

            var comparer = PersonComparer.Comparer();
            Assert.IsTrue(personResponse.Equals(personComparer, personExpected ));

            mockPersonService.Verify(m => m.AddAsync(It.IsAny<Person>()), Times.Once);
        }
    }
}