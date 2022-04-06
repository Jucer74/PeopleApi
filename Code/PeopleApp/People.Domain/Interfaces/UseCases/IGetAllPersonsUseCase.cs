using People.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace People.Domain.Interfaces.UseCases
{
   public interface IGetAllPersonsUseCase
   {
      Task<IEnumerable<Person>> ExecuteAsync();
   }
}