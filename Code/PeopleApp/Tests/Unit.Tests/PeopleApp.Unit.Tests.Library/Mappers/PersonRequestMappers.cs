using People.Api.Requests;
using People.Domain.Entities;

namespace PeopleApp.Unit.Tests.Library.Mappers
{
    public static class PersonRequestMapper
    {
        public static Person ToPerson(this PersonRequest personRequest)
        {
            return new Person
            {
                FirstName = personRequest.FirstName,
                LastName = personRequest.LastName,
                DateOfBirth = personRequest.DateOfBirth,
                Sex = personRequest.Sex
            };
        }
    }
}