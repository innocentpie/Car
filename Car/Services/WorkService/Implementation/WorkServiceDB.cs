using Car.Data;
using Car.Shared;
using Microsoft.EntityFrameworkCore;

namespace Car.Services.Implementation.DB
{
    public class WorkServiceDB : IWorkService
    {
        private readonly DataContext _context;

        public WorkServiceDB(DataContext context)
        {
            _context = context;
        }

        public async Task Add(Work work)
        {
            _context.Entry(work).State = EntityState.Added;
            await _context.SaveChangesAsync();
            _context.Entry(work).State = EntityState.Detached;
        }

        public async Task Delete(Guid id)
        {
            await _context.Works
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();
        }

        public async Task<Work> Get(Guid id)
        {
            var work = await _context.Works.FirstOrDefaultAsync(x => x.Id == id);
            return work;
        }

        public async Task<List<Work>> GetAll()
        {
            return await _context.Works.ToListAsync();
        }

        public async Task Update(Work work)
        {
            await _context.Works
                .Where(x => x.Id == work.Id)
                .ExecuteUpdateAsync(s =>
                    s.SetProperty(x => x.CustomerId, work.CustomerId)
                    .SetProperty(x => x.LicensePlate, work.LicensePlate)
                    .SetProperty(x => x.ManufacturingDate, work.ManufacturingDate)
                    .SetProperty(x => x.Category, work.Category)
                    .SetProperty(x => x.Description, work.Description)
                    .SetProperty(x => x.Severity, work.Severity)
                    .SetProperty(x => x.Status, work.Status)
            );
        }
    }
}
