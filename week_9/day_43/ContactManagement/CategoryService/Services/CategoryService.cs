using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CategoryService.Models;
using CategoryService.Repositories;

namespace CategoryService.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;

        public CategoryService(ICategoryRepository repo)
        {
            _repo = repo;
        }

        public List<Category> GetAll()
        {
            return _repo.GetAll();
        }

        public Category GetById(int id)
        {
            return _repo.GetById(id);
        }

        public void Add(Category category)
        {
            _repo.Add(category);
        }

        public void Update(Category category)
        {
            _repo.Update(category);
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }
    }
}