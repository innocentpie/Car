using Car.Data;
using Car.Mappers;
using Car.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Car.Services.Implementation.DB
{
    public class WorkServiceDB : IWorkService
    {
        private readonly ILogger<WorkServiceDB> _logger;
        private readonly WebApiDbContext _context;

        public WorkServiceDB(ILogger<WorkServiceDB> logger, WebApiDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task Add(WorkPropertiesDTO newWork)
        {
			Work work = newWork.MapToNewWork();
            await _context.Works.AddAsync(work);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Work added {@id}: {@work}", work.Id, newWork);
        }

        public async Task Delete(Guid id)
        {
            Work? work = await _context.Works.FindAsync(id);
            _context.Works.Remove(work);
            await _context.SaveChangesAsync();

			_logger.LogInformation("Work deleted with id: {@id}", id);
		}

		public async Task<WorkGetDTO?> Get(Guid id, bool includeCustomers = false)
        {
            IQueryable<Work> query = _context.Works;
            if (includeCustomers)
                query = query.Include(x => x.Customer);

            Work? work = await query.FirstOrDefaultAsync(x => x.Id == id);

			WorkGetDTO? dto = work?.MapToWorkGetDTO(includeCustomers);
			_logger.LogInformation("Work retrieved: {@work}", dto);
            return dto;
		}

        public async Task<List<WorkGetDTO>> GetAll(bool includeCustomers = false)
        {
			IQueryable<Work> query = _context.Works;
			if (includeCustomers)
				query = query.Include(x => x.Customer);
			var result = await query
                .Select(x => x.MapToWorkGetDTO(includeCustomers))
                .ToListAsync();

			_logger.LogInformation($"All {result.Count} works retrieved");
			return result;
        }

        public async Task Update(WorkDTO newWork)
        {
            Work? work = await _context.Works.FindAsync(newWork.Id);
            if (work == null)
                throw new InvalidOperationException();

            newWork.MapIntoWork(work);
            await _context.SaveChangesAsync();

			_logger.LogInformation("Work updated: {@work}", newWork);
		}
	}
}
