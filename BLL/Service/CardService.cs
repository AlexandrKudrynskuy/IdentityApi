﻿using DLL.Models;
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

            await Task.Run(() => { _repository.CreateAsync(card); });
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



        public void Create(Card card)
        {

            _repository.Create(card);

        }
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
        public void Update(int id, Card card)
        {
            _repository.Update(id, card);
        }
        public IEnumerable<Card> GetFromCondition(Expression<Func<Card, bool>> condition)
        {
            return _repository.GetFromCondition(condition);
        }

    }
}
