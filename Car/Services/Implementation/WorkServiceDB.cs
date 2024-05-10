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
            Work? work = await _context.Works.FindAsync(id);
            _context.Works.Remove(work);
            await _context.SaveChangesAsync();
        }

        public async Task<WorkGetUpdateDTO?> Get(Guid id)
        {
            Work? work = await _context.Works.FindAsync(id);
            WorkGetUpdateDTO? dto = work?.MapToWorkGetUpdateDTO();
            return dto;
        }

        public async Task<WorkGetIncludeCustomerDTO?> GetIncludeCustomer(Guid id)
        {
            Work? work = await _context.Works
                .Include(x => x.Customer)
                .FirstOrDefaultAsync(x => x.Id == id);
            return work?.MapToWorkGetIncludeCustomerDTO();
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
                .Select(x => x.MapToWorkGetIncludeCustomerDTO())
                .ToListAsync();

            return result;
        }

        public async Task Update(WorkGetUpdateDTO newWork)
        {
            Work? work = await _context.Works.FindAsync(newWork.Id);
            newWork.MapIntoWork(work);
            await _context.SaveChangesAsync();
        }
    }
}
