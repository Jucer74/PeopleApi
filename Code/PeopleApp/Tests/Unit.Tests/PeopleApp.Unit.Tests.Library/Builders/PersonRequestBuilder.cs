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
        private PersonRequest personRequest;
        private Fixture fixture;

        public PersonRequestBuilder()
        {
            personRequest = new PersonRequest();
            fixture = new Fixture();    
        }

        public PersonRequestBuilder SetFixtureData()
        {
            this.personRequest = fixture.Create<PersonRequest>(); 
            return this;
        }

        public List<PersonRequest> GetFixtureDataList(int quantity)
        {
            return fixture.Build<PersonRequest>().CreateMany<PersonRequest>(quantity).ToList();
        }


        public PersonRequestBuilder WithFirstName(string firstName) 
        {
            this.personRequest.FirstName= firstName;
            return this;
        }

        public string LastName { get; set; }

        public PersonRequestBuilder WithLastName(string lastName)
        {
            this.personRequest.LastName = lastName;
            return this;
        }

        public PersonRequestBuilder WithDateOfBirth(DateTime dateOfBirth)
        {
            this.personRequest.DateOfBirth = dateOfBirth;
            return this;
        }

        public PersonRequestBuilder WithSex(char sex)
        {
            this.personRequest.Sex = sex;
            return this;
        }

        public PersonRequest Build()
        {
            return this.personRequest;
        }
    }
}