using People.Domain.Entities;

namespace PeopleApp.Unit.Tests.Library.Comparers
{
    public static class PersonComparer
    {
        public static GenericComparer<Person> Comparer()
        {
            return new GenericComparer<Person>(x =>
            (
                x.Id,
                x.FirstName,
                x.LastName,
                x.DateOfBirth,
                x.Sex
            ));
        }
    }
}