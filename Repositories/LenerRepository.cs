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
    public interface ILenerRepository
    {
        Task<ActionResult<List<Lener>>> DeleteLener(Guid lenerId);
        Task<List<Lener>> GetLeners();
        Task<ActionResult<List<Lener>>> UpdateLeners(Lener toAdd);
    }

    public class LenerRepository : ILenerRepository
    {

        private IRegistrationContext _context;
        public LenerRepository(IRegistrationContext context)
        {
            _context = context;
        }

        public async Task<List<Lener>> GetLeners()
        {
            return await _context.Leners.ToListAsync();
        }

        public async Task<ActionResult<List<Lener>>> UpdateLeners(Lener toAdd)
        {
            if (toAdd == null)
            {
                return new BadRequestResult();
            }

            Lener exists = _context.Leners.Where(l => l.LenerId == toAdd.LenerId).SingleOrDefault();

            if (exists != null)
            {
                exists.Naam = toAdd.Naam;
                exists.Voornaam = toAdd.Voornaam;
                exists.Email = toAdd.Email;
                await _context.SaveChangesAsync();

                return await _context.Leners.ToListAsync();

            }
            else
            {
                try
                {
                    await _context.Leners.AddAsync(toAdd);
                    await _context.SaveChangesAsync();
                    return await _context.Leners.ToListAsync();
                }
                catch (Exception ex)
                {
                    return new StatusCodeResult(500);
                }
            }


        }

        public async Task<ActionResult<List<Lener>>> DeleteLener(Guid lenerId)
        {

            Lener toRemove = _context.Leners.Where(l => l.LenerId == lenerId).SingleOrDefault();

            if (toRemove != null)
            {
                _context.Leners.Remove(toRemove);
                await _context.SaveChangesAsync();
            }
            else
            {
                return new BadRequestResult();
            }

            return await _context.Leners.ToListAsync();
        }



    }
}
