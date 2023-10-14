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
    public class CardRepository:IRepository<Card>
    {
        private readonly Store_Identity_APIContext _context;

        public CardRepository(Store_Identity_APIContext context)
        {
            _context = context;
        }

        public void Create(Card entity)
        {
           _context.Cards.Add(entity);

           _context.SaveChanges();
        }
    

        public async void CreateAsync(Card entity)
        {
            await _context.Cards.AddAsync(entity);

            await _context.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var entity = _context.Cards.Find(id);
            _context.Cards.Remove(entity);
            _context.SaveChanges();
        }

        public async void DeleteAsync(int id)
        {
           
                var entity = await _context.Cards.FindAsync(id);
                _context.Cards.Remove(entity);
                await _context.SaveChangesAsync();

            }

        public IEnumerable<Card> GetFromCondition(Expression<Func<Card, bool>> condition)
        {  return _context.Cards.Where(condition).Include(x => x.User).Include(x => x.Product).Include(x=>x.Product.Brand).Include(x => x.Product.Category).ToList();
        }          



        public async Task<IEnumerable<Card>> GetFromConditionAsync(Expression<Func<Card, bool>> condition)
        {
            return await _context.Cards.Where(condition).Include(x => x.User).Include(x => x.Product).ToListAsync();
        }

        public void Update(int id, Card entity)
        {
            var oldEntity = _context.Cards.Find(id);
            oldEntity.StatusPaid=entity.StatusPaid;
          
                _context.Entry(oldEntity).State = EntityState.Modified;
                _context.SaveChanges();
          
        }

        public async void UpdateAsync(int id, Card entity)
        {
            var oldEntity = await _context.Cards.FindAsync(id);

            _context.Entry(oldEntity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
