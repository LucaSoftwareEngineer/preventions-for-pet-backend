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

        public List<Pet> findAll() {
            return _appDbContext.pets.ToList();
        }

        public Pet? findById(int id) {
            return _appDbContext.pets.FirstOrDefault(p => p.Id == id);
        }

        public Pet save(Pet pet) { 
            if (pet.Id != 0) {
                return _appDbContext.pets.Update(pet).Entity;
            } else {
                return _appDbContext.pets.Add(pet).Entity;
            }
        }

        public void deleteById(int id) {
            Pet? pet = findById(id);
            if (pet != null) {
                _appDbContext.pets.Remove(pet);
            }
        }
    }
}
