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

        public LeningController(ILeningService LeningService)
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
        public async Task<ActionResult<Lening>> AddNewLening(Lening newLening){
           return await _leningService.AddLening(newLening);  
        }


        [HttpPost]
        [Route("/lening/close/{leningIdToClose}")]
        public async  Task<ActionResult<Lening>> CloseThisLening(Guid leningIdToClose){
            return await _leningService.CloseLening(leningIdToClose);
        }
        
        
        [HttpGet]
        [Route("/leners")]
        public async Task<List<Lener>> GetAllLeners(){
            return await _leningService.GetLeners();
        }

        [HttpPost]
        [Route("/leners/update")]
        public async Task<ActionResult<List<Lener>>> UpdateThisLener(Lener toAdd){
            return await _leningService.UpdateLeners(toAdd);
        }

        [HttpDelete]
        [Route("/leners/{lenerId}")]
        public async Task<ActionResult<List<Lener>>> DeleteThisLener(Guid lenerId){
            return await _leningService.DeleteLener(lenerId);
        }


        [HttpGet]
        [Route("/materiaal")]
        public async Task<List<Materiaal>> GetAllMateriaal(){
            return await _leningService.GetMateriaal();
        }

        [HttpGet]
        [Route("/materiaal/{categorie}")]
        public async Task<ActionResult<List<Materiaal>>> GetAllMateriaalByCategorie(string categorie){
            return await _leningService.GetMateriaalByCategorie(categorie);
        }


        [HttpPost]
        [Route("/materiaal/add")]
        public async Task<ActionResult<Materiaal>> AddNewMateriaal(Materiaal toAdd){
            return await _leningService.AddMateriaal(toAdd);
        }

        [HttpDelete]
        [Route("/materiaal/{materiaalId}")]
        public async Task<ActionResult<List<Materiaal>>> DeleteThisMateriaal(Guid materiaalId){
            return await _leningService.DeleteMateriaal(materiaalId);
        }


        [HttpPost]
        [Route("/materiaal/update")]
        public async Task<ActionResult<List<Materiaal>>> UpdateThisMateriaal(Materiaal toUpdate){
           return await _leningService.UpdateMateriaal(toUpdate);

        }

        [HttpGet]
        [Route("/materiaal/shoppinglist")]
        public ActionResult<List<Materiaal>> GetShoppingList(){
            return _leningService.ShoppingList();
        }
            
    }
}
