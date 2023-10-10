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
    public class CardService
    {
            private readonly CardRepository _repository;

            public CardService(CardRepository repository)
            {
                _repository = repository;
            }

            public async void CreateAsync(Card card)
            {
                _repository.CreateAsync(card);
            }
            public async void DeleteAsync(int id)
            {
                _repository.DeleteAsync(id);
            }
            public async void UpdateAsync(int id, Card card)
            {
                _repository.UpdateAsync(id, card);
            }
            public async Task<IEnumerable<Card>> GetFromConditionAsync(Expression<Func<Card, bool>> condition)
            {
                return await _repository.GetFromConditionAsync(condition);
            }
        }
}
