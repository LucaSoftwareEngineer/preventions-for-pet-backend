using dto;
using model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Numerics;
using System.Text;

namespace service.interfaces
{
    public interface IPetService
    {
        public Task<PetResponse> Add(PetAddRequest petRequest);
        public Task<PetResponse> Update(PetUpdateRequest petRequest);
        public Task<PetResponse> FindById(int id);
        public Task<List<PetResponse>> FindAll();
        public Task<List<PetFindAllByProprietarioResponse>> FindAllByProprietario(int idProprietario);
    }
}
