using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using backend_uitleendienst.Data;
using backend_uitleendienst.Models;
using backend_uitleendienst.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace backend_uitleendienst.Services
{
    public interface ILeningService
    {
        Task<ActionResult<Lening>> AddLening(Lening newLening);
        Task<ActionResult<Materiaal>> AddMateriaal(Materiaal toAdd);
        Task<ActionResult<Lening>> CloseLening(Guid leningIdToClose);
        Task<ActionResult<List<Lener>>> DeleteLener(Guid lenerId);
        Task<ActionResult<List<Materiaal>>> DeleteMateriaal(Guid materiaalId);
        Task<List<Lener>> GetLeners();
        Task<List<Materiaal>> GetMateriaal();
        Task<ActionResult<List<Materiaal>>> GetMateriaalByCategorie(string categorie);
        Task<ActionResult<List<Lening>>> GetPendingLeningen();
        ActionResult<List<Materiaal>> ShoppingList();
        Task<ActionResult<List<Lener>>> UpdateLeners(Lener toAdd);
        Task<ActionResult<List<Materiaal>>> UpdateMateriaal(Materiaal toUpdate);
    }

    public class LeningService : ILeningService
    {
        private ILeningRepository _leningRepository;
        private ILenerRepository _lenerRepository;
        private IMateriaalRepository _materiaalRepository;
        public LeningService(
            ILeningRepository leningRepository,
            ILenerRepository lenerRepository,
            IMateriaalRepository materiaalRepository)
        {
            _leningRepository = leningRepository;
            _lenerRepository = lenerRepository;
            _materiaalRepository = materiaalRepository;
        }

        public async Task<List<Materiaal>> GetMateriaal()
        {
            return await _materiaalRepository.GetMateriaal();
        }

        public async Task<ActionResult<List<Materiaal>>> GetMateriaalByCategorie(string categorie)
        {
            return await _materiaalRepository.GetMateriaalByCategorie(categorie);
        }

        public async Task<ActionResult<Materiaal>> AddMateriaal(Materiaal toAdd)
        {
            return await _materiaalRepository.AddMateriaal(toAdd);
        }

        public async Task<ActionResult<List<Materiaal>>> DeleteMateriaal(Guid materiaalId)
        {
            return await _materiaalRepository.DeleteMateriaal(materiaalId);
        }

        public async Task<ActionResult<List<Materiaal>>> UpdateMateriaal(Materiaal toUpdate)
        {
            return await _materiaalRepository.UpdateMateriaal(toUpdate);
        }

        public ActionResult<List<Materiaal>> ShoppingList()
        {
            return _materiaalRepository.ShoppingList();
        }

        public async Task<ActionResult<List<Lening>>> GetPendingLeningen()
        {
            return await _leningRepository.GetPendingLeningen();
        }

        public async Task<ActionResult<Lening>> AddLening(Lening newLening)
        {
            return await _leningRepository.AddLening(newLening);
        }

        public async Task<ActionResult<Lening>> CloseLening(Guid leningIdToClose)
        {
            return await _leningRepository.CloseLening(leningIdToClose);
        }

        public async Task<List<Lener>> GetLeners()
        {
            return await _lenerRepository.GetLeners();
        }

        public async Task<ActionResult<List<Lener>>> UpdateLeners(Lener toAdd)
        {
            return await _lenerRepository.UpdateLeners(toAdd);
        }

        public async Task<ActionResult<List<Lener>>> DeleteLener(Guid lenerId)
        {
            return await _lenerRepository.DeleteLener(lenerId);
        }

    }
}
