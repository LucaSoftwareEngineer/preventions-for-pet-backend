using dto;
using model;
using repository;
using service.interfaces;
using System;
using System.Collections.Generic;
using System.Net;
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

        public Task<PetResponse> FindById(int id)
        {
            Pet? pet = _petRepository.FindById(id);

            if (pet == null) throw new Exception("Pet non trovato");

            return Task.FromResult(new PetResponse
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
            });
        }

        public Task<PetResponse> Add(PetAddRequest petRequest)
        {
            var Proprietario = _proprietarioRepository.FindById(petRequest.IdProprietario);

            if (Proprietario == null) throw new Exception("Proprietario non trovato");

            Pet pet = new Pet
            {
                Id = 0,
                Nome = petRequest.Nome,
                Eta = petRequest.Eta,
                DataNascita = petRequest.DataNascita,
                ProprietarioId = petRequest.IdProprietario,
                Proprietario = Proprietario
            };

            return Task.FromResult(new PetResponse
            {
                Id = _petRepository.Save(pet).Id,
                Nome = pet.Nome,
                Eta = pet.Eta,
                DataNascita = pet.DataNascita,
                Proprietario = new ProprietarioNoPetsResponse
                {
                    Id = petRequest.IdProprietario,
                    Nome = Proprietario.Nome,
                    Cognome = Proprietario.Cognome
                }
            });
        }

        public Task<PetResponse> Update(PetUpdateRequest petRequest)
        {

            var Pet = _petRepository.FindById(petRequest.Id);
            if (Pet == null) throw new Exception("Pet non trovato");

            Pet.Id = petRequest.Id;

            if (petRequest.Nome != null) Pet.Nome = petRequest.Nome;
            if (petRequest.Eta != 0) Pet.Eta = petRequest.Eta;
            if (petRequest.DataNascita != DateTime.MinValue) Pet.DataNascita = petRequest.DataNascita;
            if (petRequest.IdProprietario != 0)
            {
                Pet.ProprietarioId = petRequest.IdProprietario;
                var Proprietario = _proprietarioRepository.FindById(petRequest.IdProprietario);
                if (Proprietario == null) throw new Exception("Proprietario non trovato");
            }

            return Task.FromResult(new PetResponse
            {
                Id = _petRepository.Save(Pet).Id,
                Nome = Pet.Nome,
                Eta = Pet.Eta,
                DataNascita = Pet.DataNascita,
                Proprietario = new ProprietarioNoPetsResponse
                {
                    Id = Pet.ProprietarioId,
                    Nome = Pet.Proprietario.Nome,
                    Cognome = Pet.Proprietario.Cognome
                }
            });
        }

        public Task<MessageResponse> Delete(int id)
        {
            var pet = _petRepository.FindById(id);

            if (pet == null) throw new Exception("Pet non trovato");

            try
            {
                _petRepository.DeleteById(id);
                return Task.FromResult(new MessageResponse { Message = "Pet con id " + id + " eliminato con successo" });
            }
            catch (Exception ex)
            {
                throw new Exception("Errore durante l'eliminazione del pet: " + ex.Message);
            }
        }
    }
}
