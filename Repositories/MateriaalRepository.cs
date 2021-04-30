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
    public interface IMateriaalRepository
    {
        Task<ActionResult<Materiaal>> AddMateriaal(Materiaal toAdd);
        Task<ActionResult<List<Materiaal>>> DeleteMateriaal(Guid materiaalId);
        Task<List<Materiaal>> GetMateriaal();
        Task<ActionResult<List<Materiaal>>> GetMateriaalByCategorie(string categorie);
        ActionResult<List<Materiaal>> ShoppingList();
        Task<ActionResult<List<Materiaal>>> UpdateMateriaal(Materiaal toUpdate);
    }

    public class MateriaalRepository : IMateriaalRepository
    {

        private IRegistrationContext _context;
        public MateriaalRepository(IRegistrationContext context)
        {
            _context = context;
        }



        public async Task<List<Materiaal>> GetMateriaal()
        {
            return await _context.Materiaal.ToListAsync();
        }

        public async Task<ActionResult<List<Materiaal>>> GetMateriaalByCategorie(string categorie)
        {

            try
            {
                return await _context.Materiaal.Where(m => m.Categorie == categorie).ToListAsync();
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }

        public async Task<ActionResult<Materiaal>> AddMateriaal(Materiaal toAdd)
        {
            if (toAdd == null)
            {
                return new BadRequestResult();
            }

            Materiaal exists = _context.Materiaal.Where(m => m.MateriaalId == toAdd.MateriaalId).SingleOrDefault();


            if (exists != null)
            {
                exists.Stock += toAdd.Stock;
                await _context.SaveChangesAsync();
                return toAdd;

            }
            else
            {
                try
                {
                    await _context.Materiaal.AddAsync(toAdd);
                    await _context.SaveChangesAsync();
                    return toAdd;
                }
                catch (Exception ex)
                {
                    return new StatusCodeResult(500);
                }
            }
        }

        public async Task<ActionResult<List<Materiaal>>> DeleteMateriaal(Guid materiaalId)
        {

            Materiaal toRemove = _context.Materiaal.Where(m => m.MateriaalId == materiaalId).SingleOrDefault();

            if (toRemove != null)
            {
                _context.Materiaal.Remove(toRemove);
                await _context.SaveChangesAsync();
            }
            else
            {
                return new BadRequestResult();
            }

            return await _context.Materiaal.ToListAsync();

        }

        public async Task<ActionResult<List<Materiaal>>> UpdateMateriaal(Materiaal toUpdate)
        {
            if (toUpdate == null)
            {
                return new BadRequestResult();
            }

            Materiaal exists = _context.Materiaal.Where(m => m.MateriaalId == toUpdate.MateriaalId).SingleOrDefault();

            if (exists != null)
            {
                exists.Stock -= toUpdate.Stock;
                await _context.SaveChangesAsync();
                return await _context.Materiaal.ToListAsync();

            }
            else
            {
                return new BadRequestResult();
            }
        }

        public ActionResult<List<Materiaal>> ShoppingList()
        {

            var ShoppingList = new List<Materiaal>();

            foreach (Materiaal i in _context.Materiaal)
            {
                if (i.Stock <= i.Drempel)
                {
                    ShoppingList.Add(i);
                }
            }

            if (ShoppingList == null)
            {
                return new NotFoundObjectResult(ShoppingList);
            }
            else
            {
                return ShoppingList;
            }


        }
    }
}
