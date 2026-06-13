using data;
using Microsoft.EntityFrameworkCore;
using model;
using System;
using System.Collections.Generic;
using System.Text;

namespace repository
{
    public class ProprietarioRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProprietarioRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<Proprietario> findAll()
        {
            return _appDbContext.proprietari.ToList();
        }

        public Proprietario? findById(int id)
        {
            return _appDbContext.proprietari.Include(p => p.Pets).FirstOrDefault(p => p.Id == id);
        }

        public Proprietario save(Proprietario proprietario)
        {
            if (proprietario.Id != 0)
            {
                return _appDbContext.proprietari.Update(proprietario).Entity;
            }
            else
            {
                return _appDbContext.proprietari.Add(proprietario).Entity;
            }
        }

        public void deleteById(int id)
        {
            Proprietario? proprietario = findById(id);
            if (proprietario != null)
            {
                _appDbContext.proprietari.Remove(proprietario);
            }
        }
    }
}
