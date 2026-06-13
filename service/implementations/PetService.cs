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

        public Task<List<PetResponse>> FindAll()
        {
            List<PetResponse> petResponses = new List<PetResponse>();
            petResponses = _petRepository.FindAll().Select(pet => new PetResponse
                {
                    Id = pet.Id,
                    Nome = pet.Nome,
                    Eta = pet.Eta,
                    DataNascita = pet.DataNascita,
                    Proprietario = new ProprietarioNoPetsResponse
                    {
                        Id = pet.ProprietarioId,
                        Nome = pet.Proprietario.Nome,
                        Cognome = pet.Proprietario.Cognome
                    }
                }).ToList();

            return Task.FromResult(petResponses);
        }

        public Task<List<PetFindAllByProprietarioResponse>> FindAllByProprietario(int idProprietario)
        {
            Proprietario? proprietario = _proprietarioRepository.FindById(idProprietario);
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
