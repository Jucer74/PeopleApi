using People.Domain.Entities;
using System.Threading.Tasks;

namespace People.Domain.Interfaces.UseCases
{
   public interface IGetByIdPersonUseCase
   {
      Task<Person> ExecuteAsync(int id);
   }
}