using AutoFixture;
using People.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PeopleApp.Unit.Tests.Library.Builders
{
    public class PersonBuilder
    {
        private Person person;
        private Fixture fixture;

        public PersonBuilder()
        {
            person = new Person();
            fixture = new Fixture();    
        }

        public PersonBuilder SetFixtureData()
        {
            this.person = fixture.Create<Person>(); 
            return this;
        }

        public List<Person> GetFixtureDataList(int quantity)
        {
            return fixture.Build<Person>().CreateMany<Person>(quantity).ToList();
        }

        public PersonBuilder WithId(int id)
        {
            this.person.Id = id;
            return this;
        }

        public PersonBuilder WithFirstName(string firstName) 
        {
            this.person.FirstName= firstName;
            return this;
        }

        public string LastName { get; set; }

        public PersonBuilder WithLastName(string lastName)
        {
            this.person.LastName = lastName;
            return this;
        }

        public PersonBuilder WithDateOfBirth(DateTime dateOfBirth)
        {
            this.person.DateOfBirth = dateOfBirth;
            return this;
        }

        public PersonBuilder WithSex(char sex)
        {
            this.person.Sex = sex;
            return this;
        }

        public Person Build()
        {
            return this.person;
        }
    }
}