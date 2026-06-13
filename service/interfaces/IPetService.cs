using dto;
using model;
using System;
using System.Collections.Generic;
using System.Text;

namespace service.interfaces
{
    interface IPetService
    {
        public Task<List<PetFindAllByProprietarioResponse>> FindAllByProprietario(int idProprietario);
    }
}
