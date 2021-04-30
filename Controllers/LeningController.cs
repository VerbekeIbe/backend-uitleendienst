using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using backend_uitleendienst.Models;
using Microsoft.AspNetCore.Mvc;
using backend_uitleendienst.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using backend_uitleendienst.Services;

namespace backend_uitleendienst.Controllers
{
    [ApiController]
    public class LeningController : ControllerBase
    {
        
        private ILeningService _leningService;

        public LeningController(LeningService LeningService)
        {
                   _leningService = LeningService;
        }


        [HttpGet]
        [Route("/lening/pending")]
        public async Task<ActionResult<List<Lening>>> GetPendingLeningen(){
            return await _leningService.GetPendingLeningen();
        }

        
        [HttpPost]
        [Route("/lening")]      
        public async Task<ActionResult<Lening>> AddLening(Lening newLening){
           return await _leningService.AddLening(newLening);  
        }


        [HttpPost]
        [Route("/lening/close/{leningIdToClose}")]
        public async  Task<ActionResult<Lening>> CloseLening(Guid leningIdToClose){
            return await _leningService.CloseLening(leningIdToClose);
        }
        
        
        [HttpGet]
        [Route("/leners")]
        public async Task<List<Lener>> GetLeners(){
            return await _leningService.GetLeners();
        }

        [HttpPost]
        [Route("/leners/update")]
        public async Task<ActionResult<List<Lener>>> UpdateLeners(Lener toAdd){
            return await _leningService.UpdateLeners(toAdd);
        }

        [HttpDelete]
        [Route("/leners/{lenerId}")]
        public async Task<ActionResult<List<Lener>>> DeleteLener(Guid lenerId){
            return await _leningService.DeleteLener(lenerId);
        }


        [HttpGet]
        [Route("/materiaal")]
        public async Task<List<Materiaal>> GetMateriaal(){
            return await _leningService.GetMateriaal();
        }

        [HttpGet]
        [Route("/materiaal/{categorie}")]
        public async Task<ActionResult<List<Materiaal>>> GetMateriaalByCategorie(string categorie){
            return await _leningService.GetMateriaalByCategorie(categorie);
        }


        [HttpPost]
        [Route("/materiaal/add")]
        public async Task<ActionResult<Materiaal>> AddMateriaal(Materiaal toAdd){
            return await _leningService.AddMateriaal(toAdd);
        }

        [HttpDelete]
        [Route("/materiaal/{materiaalId}")]
        public async Task<ActionResult<List<Materiaal>>> DeleteMateriaal(Guid materiaalId){
            return await _leningService.DeleteMateriaal(materiaalId);
        }


        [HttpPost]
        [Route("/materiaal/update")]
        public async Task<ActionResult<List<Materiaal>>> UpdateMateriaal(Materiaal toUpdate){
           return await _leningService.UpdateMateriaal(toUpdate);

        }

        [HttpGet]
        [Route("/materiaal/shoppinglist")]
        public ActionResult<List<Materiaal>> ShoppingList(){
            return _leningService.ShoppingList();
        }
            
    }
}
