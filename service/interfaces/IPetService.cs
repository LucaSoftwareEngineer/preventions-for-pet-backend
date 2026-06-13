using dto;
using model;
using System;
using System.Collections.Generic;
using System.Text;

namespace service.interfaces
{
    public interface IPetService
    {
        public Task<List<PetResponse>> FindAll();
        public Task<List<PetFindAllByProprietarioResponse>> FindAllByProprietario(int idProprietario);
    }
}
