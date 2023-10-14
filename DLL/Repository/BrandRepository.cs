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
    public class BrandRepository
    {
        private readonly Store_Identity_APIContext _context;

        public BrandRepository(Store_Identity_APIContext context)
        {
            _context = context;
        }

        public void Create(Brand entity)
        {
            _context.Brands.Add(entity);

            _context.SaveChanges();
        }


        public async void CreateAsync(Brand entity)
        {
            await _context.Brands.AddAsync(entity);

            await _context.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var entity = _context.Brands.Find(id);
            _context.Brands.Remove(entity);
            _context.SaveChanges();
        }

        public async void DeleteAsync(int id)
        {

            var entity = await _context.Brands.FindAsync(id);
            _context.Brands.Remove(entity);
            await _context.SaveChangesAsync();

        }

        public IEnumerable<Brand> GetFromCondition(Expression<Func<Brand, bool>> condition)
        {
            return _context.Brands.Where(condition).Include(x => x.Products).ToList();
        }



        public async Task<IEnumerable<Brand>> GetFromConditionAsync(Expression<Func<Brand, bool>> condition)
        {
            return await _context.Brands.Where(condition).Include(x => x.Products).ToListAsync();
        }

        public void Update(int id, Brand entity)
        {
            var oldEntity = _context.Brands.Find(id);
            oldEntity.Name = entity.Name;

            oldEntity.Photo = entity.Photo;

            _context.Entry(oldEntity).State = EntityState.Modified;
            _context.SaveChanges();

        }

        public async void UpdateAsync(int id, Brand entity)
        {
            var oldEntity = await _context.Brands.FindAsync(id);

            _context.Entry(oldEntity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
