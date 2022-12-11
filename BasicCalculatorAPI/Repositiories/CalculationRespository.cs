using Calculator.Data;
using Calculator.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BasicCalculatorAPI
{
    public class CalculationRespository : ICalculationRepository
    {
        private readonly CalculatorContext _dbContext;
        private readonly DbSet<Calculation> _calculationDbSet;

        public CalculationRespository(CalculatorContext dbContext)
        {
            _dbContext = dbContext;
            _calculationDbSet = _dbContext.Set<Calculation>();
        }

        async Task<Calculation> ICalculationRepository.CreateAsync(Calculation calculation)
        {
            if (_dbContext != null)
            {
                if (_dbContext.Calculations != null)
                {
                    await _dbContext.Calculations.AddAsync(calculation);
                }
                else
                {
                    throw new ArgumentNullException(nameof(calculation));
                }
            }
            else
            {
                throw new ArgumentNullException(nameof(calculation));
            }
            await _dbContext.SaveChangesAsync();
            return calculation;
        }

        async Task ICalculationRepository.DeleteAsync(int? id)
        {
            if (_dbContext.Calculations is null) return;
            var calculation = await _dbContext.Calculations.FindAsync(id);

            if (calculation is null) return;
            _dbContext.Calculations.Remove(calculation);
            await _dbContext.SaveChangesAsync();
        }

        async Task<Calculation> ICalculationRepository.FindByIdAsync(int id)
        {
            var result = await _calculationDbSet.FindAsync(id);
            
            return result;
        }

        async Task<IEnumerable<Calculation>> ICalculationRepository.GetAll()
        {
            return await _calculationDbSet.OrderByDescending(c => c.CreateDate).ToListAsync();
        }

        async Task ICalculationRepository.UpdateAsync(Calculation calculation)
        {
            _dbContext.Entry(calculation).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
