using Car.Data;
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

        public async Task Add(Work work)
        {
            await _context.Works.AddAsync(work);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var work = await Get(id);
            _context.Works.Remove(work);
            await _context.SaveChangesAsync();
        }

        public async Task<Work> Get(Guid id)
        {
            var work = await _context.Works.FindAsync(id);
            return work;
        }

        public async Task<List<Work>> GetAll()
        {
            return await _context.Works.ToListAsync();
        }

        public async Task Update(Work newWork)
        {
            var x = await Get(newWork.Id);

            x.CustomerId = newWork.CustomerId;
            x.LicensePlate = newWork.LicensePlate;
            x.ManufacturingDate = newWork.ManufacturingDate;
            x.Category = newWork.Category;
            x.Description = newWork.Description;
            x.Severity = newWork.Severity;
            x.Status = newWork.Status;

            await _context.SaveChangesAsync();
        }
    }
}
