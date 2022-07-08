using People.Api.Requests;
using People.Domain.Entities;
using PeopleApp.Unit.Tests.Library.Builders;
using System;
using System.Collections.Generic;

namespace PeopleApp.Unit.Tests.Library.Mothers
{
    public static class PersonRequestMother
    {

        public static PersonRequest Default(
                                     string firstName = "John",
                                     string lastName = "Doe",
                                     DateTime? dateOfBirth = null,
                                     char sex = 'M')
        {
            return new PersonRequestBuilder()
                    .WithFirstName(firstName)
                    .WithLastName(lastName)
                    .WithDateOfBirth(dateOfBirth??new DateTime(1974, 10, 8))
                    .WithSex(sex)
                    .Build();
        }

        public static PersonRequest WithFixtureData()
        {
            return new PersonRequestBuilder()
                    .SetFixtureData()
                    .Build();
        }

        public static List<PersonRequest> GetFixtureDataList(int quantity)
        {
            return new PersonRequestBuilder().GetFixtureDataList(quantity);
        }
    }
}