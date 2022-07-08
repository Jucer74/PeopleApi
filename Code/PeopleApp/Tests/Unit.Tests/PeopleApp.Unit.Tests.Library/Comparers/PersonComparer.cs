using People.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
