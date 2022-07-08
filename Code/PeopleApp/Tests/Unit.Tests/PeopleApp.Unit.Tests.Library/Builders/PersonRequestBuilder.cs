using AutoFixture;
using People.Api.Requests;
using People.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PeopleApp.Unit.Tests.Library.Builders
{
    public class PersonRequestBuilder
    {
        private PersonRequest PersonRequest;
        private Fixture fixture;

        public PersonRequestBuilder()
        {
            PersonRequest = new PersonRequest();
            fixture = new Fixture();    
        }

        public PersonRequestBuilder SetFixtureData()
        {
            this.PersonRequest = fixture.Create<PersonRequest>(); 
            return this;
        }

        public List<PersonRequest> GetFixtureDataList(int quantity)
        {
            return fixture.Build<PersonRequest>().CreateMany<PersonRequest>(quantity).ToList();
        }

        public PersonRequestBuilder WithFirstName(string firstName) 
        {
            this.PersonRequest.FirstName= firstName;
            return this;
        }

        public string LastName { get; set; }

        public PersonRequestBuilder WithLastName(string lastName)
        {
            this.PersonRequest.LastName = lastName;
            return this;
        }

        public PersonRequestBuilder WithDateOfBirth(DateTime dateOfBirth)
        {
            this.PersonRequest.DateOfBirth = dateOfBirth;
            return this;
        }

        public PersonRequestBuilder WithSex(char sex)
        {
            this.PersonRequest.Sex = sex;
            return this;
        }

        public PersonRequest Build()
        {
            return this.PersonRequest;
        }
    }
}