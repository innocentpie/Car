using Car.Data;
using Car.Mappers;
using Car.Shared;
using Microsoft.EntityFrameworkCore;

namespace Car.Services.Implementation.DB
{
    public class WorkServiceDB : IWorkService
    {
        private readonly WebApiDbContext _context;

        public WorkServiceDB(WebApiDbContext context)
        {
            _context = context;
        }

        public async Task Add(WorkPropertiesDTO newWork)
        {
            Work work = newWork.MapToNewWork();
            await _context.Works.AddAsync(work);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            Work? work = await GetWorkAsync(id);
            _context.Works.Remove(work);
            await _context.SaveChangesAsync();
        }

        public async Task<WorkGetUpdateDTO?> Get(Guid id)
        {
            Work? work = await GetWorkAsync(id);
            WorkGetUpdateDTO? dto = work?.MapToWorkGetUpdateDTO();
            return dto;
        }

        public async Task<List<WorkGetUpdateDTO>> GetAll()
        {
            var result = await _context.Works
                .Select(x => x.MapToWorkGetUpdateDTO())
                .ToListAsync();

            return result;
        }

        public async Task<List<WorkGetIncludeCustomerDTO>> GetAllIncludeCustomer()
        {
            var result = await _context.Works
                .Include(x => x.Customer)
                .Select(x => x.MapToWorkIncludingCustomerDTO())
                .ToListAsync();

            return result;
        }

        public async Task Update(WorkGetUpdateDTO newWork)
        {
            Work? work = await GetWorkAsync(newWork.Id);
            newWork.MapIntoWork(work);
            await _context.SaveChangesAsync();
        }


        private async Task<Work?> GetWorkAsync(Guid id)
        {
            return await _context.Works.FindAsync(id);
        }
    }
}
