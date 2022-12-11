using Calculator.Models;
using System.Linq.Expressions;

namespace BasicCalculatorAPI
{
    public interface ICalculationRepository
    {
        Task<IEnumerable<Calculation>> GetAll();

        Task<Calculation> FindByIdAsync(int id);

        Task UpdateAsync(Calculation calculation);

        Task<Calculation> CreateAsync(Calculation calculation);

        Task DeleteAsync(int? id);
    }
}
