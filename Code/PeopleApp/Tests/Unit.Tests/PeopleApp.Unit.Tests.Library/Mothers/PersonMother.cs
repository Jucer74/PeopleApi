using People.Domain.Entities;
using PeopleApp.Unit.Tests.Library.Builders;
using System;
using System.Collections.Generic;

namespace PeopleApp.Unit.Tests.Library.Mothers
{
    public static class PersonMother
    {

        public static Person Default(int id = 0,
                                     string firstName = "John",
                                     string lastName = "Doe",
                                     DateTime? dateOfBirth = null,
                                     char sex = 'M')
        {
            return new PersonBuilder()
                    .WithId(id)
                    .WithFirstName(firstName)
                    .WithLastName(lastName)
                    .WithDateOfBirth(dateOfBirth??new DateTime(1974, 10, 8))
                    .WithSex(sex)
                    .Build();
        }

        public static Person WithFixtureData()
        {
            return new PersonBuilder()
                    .SetFixtureData()
                    .Build();
        }

        public static List<Person> GetFixtureDataList(int quantity)
        {
            return new PersonBuilder().GetFixtureDataList(quantity);
        }
    }
}