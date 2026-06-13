using data;
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
            return _appDbContext.pets.ToList();
        }

        public Pet? FindById(int id) {
            return _appDbContext.pets.FirstOrDefault(p => p.Id == id);
        }

        public Pet Save(Pet pet) { 
            if (pet.Id != 0) {
                return _appDbContext.pets.Update(pet).Entity;
            } else {
                return _appDbContext.pets.Add(pet).Entity;
            }
        }

        public void DeleteById(int id) {
            Pet? pet = FindById(id);
            if (pet != null) {
                _appDbContext.pets.Remove(pet);
            }
        }
    }
}
