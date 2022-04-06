using People.Domain.Entities;
using System.Threading.Tasks;

namespace People.Domain.Interfaces.UseCases
{
   public interface IAddPersonUseCase
   {
      Task<int> ExecuteAsync(Person person);
   }
}