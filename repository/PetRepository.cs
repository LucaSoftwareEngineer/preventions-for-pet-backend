using data;
using Microsoft.EntityFrameworkCore;
using model;
using System;
using System.Collections.Generic;
using System.Text;

namespace repository
{
    public class PetRepository
    {
        private readonly AppDbContext _appDbContext;

        public PetRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<Pet> FindAll() {
            return _appDbContext.pets.Include(p => p.Proprietario).ToList();
        }

        public Pet? FindById(int id) {
            return _appDbContext.pets.Include(p => p.Proprietario).FirstOrDefault(p => p.Id == id);
        }

        public Pet Save(Pet pet) {
            if (pet.Id != 0) {
                pet = _appDbContext.pets.Update(pet).Entity;
            } else {
                pet = _appDbContext.pets.Add(pet).Entity;
            }
            _appDbContext.SaveChanges();
            return pet;
        }

        public void DeleteById(int id) {
            Pet? pet = FindById(id);
            if (pet != null) {
                _appDbContext.pets.Remove(pet);
            }
        }
    }
}
