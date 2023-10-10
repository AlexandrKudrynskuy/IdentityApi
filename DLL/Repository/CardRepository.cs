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

        public async void CreateAsync(Card entity)
        {
            await _context.Cards.AddAsync(entity);         
            await _context.SaveChangesAsync();
        }

        public async void DeleteAsync(int id)
        {
            var entity = await _context.Cards.FindAsync(id);
            _context.Cards.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Card>> GetFromConditionAsync(Expression<Func<Card, bool>> condition)
        {
            return await _context.Cards.Where(condition).Include(x => x.User).Include(x => x.Product).ToListAsync();
        }

        public async void UpdateAsync(int id, Card entity)
        {
            var oldEntity = await _context.Cards.FindAsync(id);

            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
