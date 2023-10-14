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
    public class BrandService
    {
        private readonly BrandRepository _repository;

        public BrandService(BrandRepository repository)
        {
            _repository = repository;
        }

        public async void CreateAsync(Brand brand)
        {

            await Task.Run(() => { _repository.CreateAsync(brand); });
        }
        public async void DeleteAsync(int id)
        {
            _repository.DeleteAsync(id);
        }
        public async void UpdateAsync(int id, Brand brand)
        {
            _repository.UpdateAsync(id, brand);
        }
        public async Task<IEnumerable<Brand>> GetFromConditionAsync(Expression<Func<Brand, bool>> condition)
        {
            return await _repository.GetFromConditionAsync(condition);
        }



        public void Create(Brand brand)
        {

            _repository.Create(brand);

        }
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
        public void Update(int id, Brand brand)
        {
            _repository.Update(id, brand);
        }
        public IEnumerable<Brand> GetFromCondition(Expression<Func<Brand, bool>> condition)
        {
            return _repository.GetFromCondition(condition);
        }
    }
}
