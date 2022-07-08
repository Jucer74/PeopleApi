using Mapster;
using People.Api.Requests;
using People.Domain.Entities;

namespace PeopleApp.Unit.Tests.Library.Mappers
{
    public static class PersonRequestMapper
    {
        public static Person ToPerson(this PersonRequest personRequest)
        {
            var result = personRequest.Adapt<Person>();
            return result;
        }
    }
}