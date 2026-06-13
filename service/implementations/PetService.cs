using dto;
using model;
using repository;
using service.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace service.implementations
{
    public class PetService : IPetService
    {
        private readonly PetRepository _petRepository;
        private readonly ProprietarioRepository _proprietarioRepository;

        public PetService(PetRepository petRepository, ProprietarioRepository proprietarioRepository)
        {
            _petRepository = petRepository;
            _proprietarioRepository = proprietarioRepository;
        }

        public Task<List<PetFindAllByProprietarioResponse>> FindAllByProprietario(int idProprietario)
        {
            Proprietario? proprietario = _proprietarioRepository.findById(idProprietario);
            List<PetFindAllByProprietarioResponse> petResponses = new List<PetFindAllByProprietarioResponse>();

            if (proprietario == null) throw new Exception("Proprietario non trovato");

            petResponses = proprietario.Pets.Select(pet => new PetFindAllByProprietarioResponse
            {
                Id = pet.Id,
                Nome = pet.Nome,
                Eta = pet.Eta,
                DataNascita = pet.DataNascita
            }).ToList();

            return Task.FromResult(petResponses);
        }
    }
}
