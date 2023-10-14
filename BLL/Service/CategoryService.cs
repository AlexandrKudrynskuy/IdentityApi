using DLL.Models;
using DLL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class CategoryService
    {
        private readonly CategoryRepository _repository;

        public CategoryService(CategoryRepository repository)
        {
            _repository = repository;
        }

        public async void CreateAsync(Category category)
        {

            await Task.Run(() => { _repository.CreateAsync(category); });
        }
        public async void DeleteAsync(int id)
        {
            _repository.DeleteAsync(id);
        }
        public async void UpdateAsync(int id, Category category)
        {
            _repository.UpdateAsync(id, category);
        }
        public async Task<IEnumerable<Category>> GetFromConditionAsync(Expression<Func<Category, bool>> condition)
        {
            return await _repository.GetFromConditionAsync(condition);
        }



        public void Create(Category category)
        {

            _repository.Create(category);

        }
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
        public void Update(int id, Category category)
        {
            _repository.Update(id, category);
        }
        public IEnumerable<Category> GetFromCondition(Expression<Func<Category, bool>> condition)
        {
            return _repository.GetFromCondition(condition);
        }
    }
}
