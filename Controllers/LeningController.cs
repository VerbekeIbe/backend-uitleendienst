using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using backend_uitleendienst.Models;
using Microsoft.AspNetCore.Mvc;
using backend_uitleendienst.Data;

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
        public ActionResult<List<Lening>> GetPendingLeningen(){
            var pending = new List<Lening>();
            foreach(Lening l in _leningen){
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
        public ActionResult<Lening> AddLening(Lening newLening){

            newLening.LeningId = Guid.NewGuid();
            newLening.Pending = true;
            newLening.Date = DateTime.Today;
            _leningen.Add(newLening);
            return newLening;
        }


        [HttpPost]
        [Route("/lening/close/{leningIdToClose}")]
        public ActionResult<Lening> CloseLening(Guid leningIdToClose){
            Lening toClose = _leningen.Find(lening => lening.LeningId == leningIdToClose);
            if(toClose.Pending == true){
                toClose.Pending = false;
            }

            return new OkObjectResult(toClose);
        }
        
        
        [HttpGet]
        [Route("/leners")]
        public ActionResult<List<Lener>> GetLeners(){
            return new OkObjectResult(_leners);
        }

        [HttpPost]
        [Route("/leners/update")]
        public ActionResult<List<Lener>> UpdateLeners(Lener toAdd){
            if(toAdd == null){
                return new BadRequestResult();
            }

            Lener exists = _leners.Find(l => l.LenerId == toAdd.LenerId);

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

        public ActionResult<List<Lener>> DeleteLener(Guid lenerId){

            Lener toRemove = _leners.Find(l => l.LenerId == lenerId);

            if(toRemove != null){
                _leners.Remove(toRemove);
            }else
            {
                return new BadRequestResult();
            }

            return _leners;
        }


        [HttpGet]
        [Route("/materiaal")]
        public ActionResult<List<Materiaal>> GetMateriaal(){
            return new OkObjectResult(_materiaal);
        }

        [HttpGet]
        [Route("/materiaal/{categorie}")]
        public ActionResult<List<Materiaal>> GetMateriaalByCategorie(string categorie){
            var materiaal = new List<Materiaal>();
            foreach(Materiaal i in _materiaal)
            {
                if(i.Categorie == categorie){
                    materiaal.Add(i);
                }
            }
            
            if(materiaal == null){
                return new NotFoundObjectResult(categorie);
            }else {
                return materiaal;
            }
        }


        [HttpPost]
        [Route("/materiaal/add")]
        public ActionResult<List<Materiaal>> AddMateriaal(Materiaal toAdd){
            if(toAdd == null){
                return new BadRequestResult();
            }

            Materiaal exists = _materiaal.Find(m => m.MateriaalId == toAdd.MateriaalId);

            if(exists != null){
                 
                exists.Stock += toAdd.Stock;
            }else
            {
                toAdd.MateriaalId = Guid.NewGuid();
                _materiaal.Add(toAdd);
            }
            

            return _materiaal;
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

        public ActionResult<List<Materiaal>> ShoppingList(){

            var ShoppingList = new List<Materiaal>();

            foreach(Materiaal i in _materiaal)
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
