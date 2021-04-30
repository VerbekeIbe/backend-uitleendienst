using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_uitleendienst.Data;
using backend_uitleendienst.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_uitleendienst.Repositories
{
    public interface ILeningRepository
    {
        Task<ActionResult<Lening>> AddLening(Lening newLening);
        Task<ActionResult<Lening>> CloseLening(Guid leningIdToClose);
        Task<ActionResult<List<Lening>>> GetPendingLeningen();
    }

    public class LeningRepository : ILeningRepository
    {

        private IRegistrationContext _context;
        public LeningRepository(IRegistrationContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<List<Lening>>> GetPendingLeningen()
        {

            try
            {
                return await _context.Leningen.Include(l => l.Materiaal).Include(l => l.Lener).Where(l => l.Pending == true).ToListAsync();
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }

        public async Task<ActionResult<Lening>> AddLening(Lening newLening)
        {

            newLening.LeningId = Guid.NewGuid();
            newLening.Pending = true;
            newLening.Date = DateTime.Today;

            try
            {
                await _context.Leningen.AddAsync(newLening);
                await _context.SaveChangesAsync();
                return newLening;
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }

        public async Task<ActionResult<Lening>> CloseLening(Guid leningIdToClose)
        {
            Lening toClose = _context.Leningen.Where(l => l.LeningId == leningIdToClose).SingleOrDefault();

            if (toClose.Pending == true)
            {
                toClose.Pending = false;
                await _context.SaveChangesAsync();
            }

            return new OkObjectResult(toClose);
        }
    }
}
