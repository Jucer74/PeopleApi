using People.Domain.Entities;
using People.Infrastructure.Common;
using People.Infrastructure.Context;

namespace People.Infrastructure.Repositories
{
   public class PersonRepository : Repository<Person>
   {
      public PersonRepository(AppDbContext appDbContext) : base(appDbContext)
      {
      }
   }
}