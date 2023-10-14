using DLL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repository
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly Store_Identity_APIContext _context;

        public ProductRepository(Store_Identity_APIContext context)
        {
            _context = context;
        }

        public void Create(Product entity)
        {
            _context.Products.Add(entity);
            _context.SaveChanges();
        }

        public async void CreateAsync(Product entity)
        {
            await _context.Products.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var entity =  _context.Products.Find(id);
            _context.Products.Remove(entity);
            _context.SaveChanges();
        }

        public async void DeleteAsync(int id)
        {
            var entity=await _context.Products.FindAsync(id);
            _context.Products.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Product> GetFromCondition(Expression<Func<Product, bool>> condition)
        {
            return _context.Products.Where(condition).Include(x => x.Category).Include(x => x.Brand).ToList();
        }

        public async Task<IEnumerable<Product>> GetFromConditionAsync(Expression<Func<Product, bool>> condition)
        {
            return  await _context.Products.Where(condition).Include(x=>x.Category).Include(x=>x.Brand).ToListAsync();
        }

        public void Update(int id, Product entity)
        {
            var oldEntity = _context.Products.Find(id);
            oldEntity.Name = entity.Name;
            oldEntity.Price = entity.Price;
            _context.Entry(oldEntity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public async void UpdateAsync(int id, Product entity)
        {
            var oldEntity = await _context.Products.FindAsync(id);
            oldEntity.Name= entity.Name;
            oldEntity.Price=entity.Price;
            _context.Entry(oldEntity).State=EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
