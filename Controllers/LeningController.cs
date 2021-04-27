using System;
using System.Collections.Generic;
using backend_uitleendienst.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend_uitleendienst.Controllers
{
    [ApiController]
    public class LeningController : ControllerBase
    {

        private static List<Lener> _leners;

        private static List<Materiaal> _materiaal;

        private static List<Lening> _leningen;


        public LeningController()
        {
            if(_leners == null){
                _leners = new List<Lener>();
                _leners.Add(new Lener(){
                    LenerId = Guid.NewGuid(),
                    Naam = "Verbeke",
                    Voornaam = "Ibe",
                    Email = "ibeverbeke@gmail.com"
                });
                _leners.Add(new Lener(){
                    LenerId = Guid.NewGuid(),
                    Naam = "Verbeke",
                    Voornaam = "Briek",
                    Email = "briekverbeke@gmail.com"
                });
                _leners.Add(new Lener(){
                    LenerId = Guid.NewGuid(),
                    Naam = "Verdonck",
                    Voornaam = "Robbe",
                    Email = "robbeverdonck003@gmail.com"
                });
            }

        
            if(_materiaal == null){
                _materiaal = new List<Materiaal>();
                _materiaal.Add(new Materiaal(){
                    MateriaalId = Guid.NewGuid(),
                    Naam = "Pak Wit Papier",
                    Stock = 4,
                    Categorie = "Klein Materiaal",
                    Drempel = 1
                });
                _materiaal.Add(new Materiaal(){
                    MateriaalId = Guid.NewGuid(),
                    Naam = "Pak Schuursponsjes",
                    Stock = 6,
                    Categorie = "Keuken",
                    Drempel = 1
                });
                _materiaal.Add(new Materiaal(){
                    MateriaalId = Guid.NewGuid(),
                    Naam = "Voetbal",
                    Stock = 5,
                    Categorie = "Klein Materiaal",
                    Drempel = 2
                });
            }
        
            if(_leningen == null){
                _leningen = new List<Lening>();
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
        
        
        
        [Route("/leners")]
        [HttpGet]
        public ActionResult<List<Lener>> GetLeners(){
            return new OkObjectResult(_leners);
        }

        [Route("/materiaal")]
        [HttpGet]
        public ActionResult<List<Materiaal>> GetMateriaal(){
            return new OkObjectResult(_materiaal);
        }




    }
}
