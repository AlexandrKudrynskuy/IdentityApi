using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DLL;
using DLL.Models;
using DLL.Repository;

namespace BLL.Service
{
    public class ProductService
    {
        private readonly ProductRepository _repository;

        public ProductService(ProductRepository repository)
        {
            _repository = repository;
        }

        public async void CreateAsync(Product product)
        {
            _repository.CreateAsync(product);
        }
        public async void DeleteAsync(int id)
        { 
            _repository.DeleteAsync(id);
        }
        public async void UpdateAsync(int id,Product product) 
        {
            _repository.UpdateAsync(id, product);
        }
        public  async Task<IEnumerable<Product>> GetFromConditionAsync(Expression<Func<Product, bool>> condition)
        { 
            return await _repository.GetFromConditionAsync(condition);
        }
    }
}
