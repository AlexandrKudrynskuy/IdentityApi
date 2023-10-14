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
    public class CategoryRepository
    {
        private readonly Store_Identity_APIContext _context;

        public CategoryRepository(Store_Identity_APIContext context)
        {
            _context = context;
        }

        public void Create(Category entity)
        {
            _context.Categories.Add(entity);

            _context.SaveChanges();
        }


        public async void CreateAsync(Category entity)
        {
            await _context.Categories.AddAsync(entity);

            await _context.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var entity = _context.Categories.Find(id);
            _context.Categories.Remove(entity);
            _context.SaveChanges();
        }

        public async void DeleteAsync(int id)
        {

            var entity = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(entity);
            await _context.SaveChangesAsync();

        }

        public IEnumerable<Category> GetFromCondition(Expression<Func<Category, bool>> condition)
        {
            return _context.Categories.Where(condition).Include(x => x.Products).ToList();
        }



        public async Task<IEnumerable<Category>> GetFromConditionAsync(Expression<Func<Category, bool>> condition)
        {
            return await _context.Categories.Where(condition).Include(x => x.Products).ToListAsync();
        }

        public void Update(int id, Category entity)
        {
            var oldEntity = _context.Categories.Find(id);
            oldEntity.Name= entity.Name;
            oldEntity.Photo = entity.Photo;

            _context.Entry(oldEntity).State = EntityState.Modified;
            _context.SaveChanges();

        }

        public async void UpdateAsync(int id, Category entity)
        {
            var oldEntity = await _context.Categories.FindAsync(id);

            _context.Entry(oldEntity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
