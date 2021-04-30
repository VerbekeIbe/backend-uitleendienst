using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using backend_uitleendienst.Models;
using Microsoft.AspNetCore.Mvc;
using backend_uitleendienst.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace backend_uitleendienst.Controllers
{
    [ApiController]
    public class LeningController : ControllerBase
    {
        
    private RegistrationContext _context;

        public LeningController(RegistrationContext context)
        {
            _context = context;        
        }


        [HttpGet]
        [Route("/lening/pending")]
        public  ActionResult<List<Lening>> GetPendingLeningen(){
            var pending = new List<Lening>();
            foreach(Lening l in _context.Leningen){
                if(l.Pending == true){
                    pending.Add(l);
                }
            }

            if(pending == null){
                return new NotFoundResult();
            }else {
                return pending;
            }

        }

        
        [HttpPost]
        [Route("/lening")]      
        public async Task<ActionResult<Lening>> AddLening(Lening newLening){

            newLening.LeningId = Guid.NewGuid();
            newLening.Pending = true;
            newLening.Date = DateTime.Today;

            try{
                await _context.Leningen.AddAsync(newLening);
                await _context.SaveChangesAsync();
                return newLening;
            }
            catch(Exception ex){
                return new StatusCodeResult(500);
            }
            
        }


        [HttpPost]
        [Route("/lening/close/{leningIdToClose}")]
        public async  Task<ActionResult<Lening>> CloseLening(Guid leningIdToClose){
            Lening toClose = _context.Leningen.Where(l => l.LeningId == leningIdToClose).SingleOrDefault();
            
            if(toClose.Pending == true){
                toClose.Pending = false;
                await _context.SaveChangesAsync();
            }

            return new OkObjectResult(toClose);
        }
        
        
        [HttpGet]
        [Route("/leners")]
        public async Task<List<Lener>> GetLeners(){
            return await _context.Leners.ToListAsync();
        }

        [HttpPost]
        [Route("/leners/update")]
        public async Task<ActionResult<List<Lener>>> UpdateLeners(Lener toAdd){
            if(toAdd == null){
                return new BadRequestResult();
            }

            Lener exists = _context.Leners.Where(l => l.LenerId == toAdd.LenerId).SingleOrDefault();

            if(exists != null){
                exists.Naam = toAdd.Naam;
                exists.Voornaam = toAdd.Voornaam;
                exists.Email = toAdd.Email;
                await _context.SaveChangesAsync();
                
                return await _context.Leners.ToListAsync();

            }else{
                try{
                    await _context.Leners.AddAsync(toAdd);
                    await _context.SaveChangesAsync();
                    return await _context.Leners.ToListAsync();
                }
                catch(Exception ex){
                    return new StatusCodeResult(500);
                }
            }


        }

        [HttpDelete]
        [Route("/leners/{lenerId}")]

        public async Task<ActionResult<List<Lener>>> DeleteLener(Guid lenerId){

            Lener toRemove = _context.Leners.Where(l => l.LenerId == lenerId).SingleOrDefault();

            if(toRemove != null){
                _context.Leners.Remove(toRemove);
                await _context.SaveChangesAsync();
            }else
            {
                return new BadRequestResult();
            }

            return await _context.Leners.ToListAsync();
        }


        [HttpGet]
        [Route("/materiaal")]
        public async Task<List<Materiaal>> GetMateriaal(){
            return await _context.Materiaal.ToListAsync();
        }

        [HttpGet]
        [Route("/materiaal/{categorie}")]
        public async Task<ActionResult<List<Materiaal>>> GetMateriaalByCategorie(string categorie){

            try{
                return await _context.Materiaal.Where(m => m.Categorie == categorie).ToListAsync();
            }
            catch(Exception ex){
                return new StatusCodeResult(500);
            }
        }


        [HttpPost]
        [Route("/materiaal/add")]
        public async Task<ActionResult<Materiaal>> AddMateriaal(Materiaal toAdd){
            if(toAdd == null){
                return new BadRequestResult();
            }

            Materiaal exists = _context.Materiaal.Where(m => m.MateriaalId == toAdd.MateriaalId).SingleOrDefault();


            if(exists != null){
                exists.Stock += toAdd.Stock;
                await _context.SaveChangesAsync();
                return toAdd;

            }else{
                try{
                    await _context.Materiaal.AddAsync(toAdd);
                    await _context.SaveChangesAsync();
                    return toAdd;
                }
                catch(Exception ex){
                    return new StatusCodeResult(500);
                }
            }

            
        }

        [HttpDelete]
        [Route("/materiaal/{materiaalId}")]
        public async Task<ActionResult<List<Materiaal>>> DeleteMateriaal(Guid materiaalId){

            Materiaal toRemove = _context.Materiaal.Where(m => m.MateriaalId == materiaalId).SingleOrDefault();

            if(toRemove != null){
                _context.Materiaal.Remove(toRemove);
                await _context.SaveChangesAsync();
            }else
            {
                return new BadRequestResult();
            }

            return await _context.Materiaal.ToListAsync();

        }


        [HttpPost]
        [Route("/materiaal/update")]
        public async Task<ActionResult<List<Materiaal>>> UpdateMateriaal(Materiaal toUpdate){
            if(toUpdate == null){
                return new BadRequestResult();
            }

            Materiaal exists = _context.Materiaal.Where(m => m.MateriaalId == toUpdate.MateriaalId).SingleOrDefault();

            if(exists != null)
            {
                exists.Stock -= toUpdate.Stock;
                await _context.SaveChangesAsync();
                return await _context.Materiaal.ToListAsync();

            }else
            {
                return new BadRequestResult();
            }

        }

        [HttpGet]
        [Route("/materiaal/shoppinglist")]

        public ActionResult<List<Materiaal>> ShoppingList(){

            var ShoppingList = new List<Materiaal>();

            foreach(Materiaal i in _context.Materiaal)
            {
                if(i.Stock <= i.Drempel){
                    ShoppingList.Add(i);
                }
            }

            if(ShoppingList == null){
                 return new NotFoundObjectResult(ShoppingList);
            }else {
                 return ShoppingList;
            }

            
        }
            
    }
}
