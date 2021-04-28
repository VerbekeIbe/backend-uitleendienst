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

        private static List<Lener> _leners;

        private static List<Materiaal> _materiaal;

        private static List<Lening> _leningen;


    private RegistrationContext _context;

        public LeningController(RegistrationContext context)
        {
            _context = context;        
        }


        [HttpGet]
        [Route("/lening/pending")]
        public async Task<ActionResult<List<Lening>>> GetPendingLeningen(){
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
        public ActionResult<Lening> CloseLening(Guid leningIdToClose){
            Lening toClose = (Lening)_context.Leningen.Where(l => l.LeningId == leningIdToClose);
            return toClose;
            // if(toClose.Pending == true){
            //     toClose.Pending = false;
            // }

            // return new OkObjectResult(toClose);
        }
        
        
        [HttpGet]
        [Route("/leners")]
        public async Task<List<Lener>> GetLeners(){
            return await _context.Leners.ToListAsync();
        }

        [HttpPost]
        [Route("/leners/update")]
        public ActionResult<List<Lener>> UpdateLeners(Lener toAdd){
            if(toAdd == null){
                return new BadRequestResult();
            }

            Lener exists = (Lener)_context.Leners.Where(l => l.LenerId == toAdd.LenerId);

            if(exists != null){
                exists.Naam = toAdd.Naam;
                exists.Voornaam = toAdd.Voornaam;
                exists.Email = toAdd.Email;
            }else{
                toAdd.LenerId = Guid.NewGuid();
                _leners.Add(toAdd);
            }

            return _leners;

        }

        [HttpDelete]
        [Route("/leners/{lenerId}")]

        public async Task<ActionResult<List<Lener>>> DeleteLener(Guid lenerId){

            Lener toRemove = (Lener)_context.Leners.Where(l => l.LenerId == lenerId);

            if(toRemove != null){
                _leners.Remove(toRemove);
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






            // var materiaal = new List<Materiaal>();
            // foreach(Materiaal i in _materiaal)
            // {
            //     if(i.Categorie == categorie){
            //         materiaal.Add(i);
            //     }
            // }
            
            // if(materiaal == null){
            //     return new NotFoundObjectResult(categorie);
            // }else {
            //     return materiaal;
            // }
        }


        [HttpPost]
        [Route("/materiaal/add")]
        public async Task<ActionResult<Materiaal>> AddMateriaal(Materiaal toAdd){
            if(toAdd == null){
                return new BadRequestResult();
            }

            Materiaal exists = (Materiaal)_context.Materiaal.Where(m => m.MateriaalId == toAdd.MateriaalId).First();

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
        public ActionResult<List<Materiaal>> DeleteMateriaal(Guid materiaalId){

            Materiaal toRemove = _materiaal.Find(m => m.MateriaalId == materiaalId);

            if(toRemove != null){
                _materiaal.Remove(toRemove);
            }else
            {
                return new BadRequestResult();
            }

            return _materiaal;

        }


        [HttpPost]
        [Route("/materiaal/update")]
        public ActionResult<List<Materiaal>> UpdateMateriaal(Materiaal toUpdate){
            if(toUpdate == null){
                return new BadRequestResult();
            }

            Materiaal exists = _materiaal.Find(m => m.MateriaalId == toUpdate.MateriaalId);

            if(exists != null)
            {
                exists.Stock -= toUpdate.Stock;

            }else
            {
                return new BadRequestResult();
            }

            return _materiaal;
        }

        [HttpGet]
        [Route("/materiaal/shoppinglist")]

        public async Task<ActionResult<List<Materiaal>>> ShoppingList(){

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
