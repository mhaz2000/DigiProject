using Domain.Models;
using Infrastructure.DtoModels;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Services.Services
{
    public class KeyboardService
    {
        private readonly DataContext _dataContext;
        public KeyboardService()
        {
            _dataContext = new DataContext();
        }
        public KeyboardDto Get(Expression<Func<Keyboard, bool>> filter, params Expression<Func<Keyboard, object>>[] includes)
        {
            var keyboard = _dataContext.keyboardRepository.Get(filter, includes);
            return Mapper.MapToDto.KeyboardMapToDto(keyboard);
        }

        public List<KeyboardDto> GetList(Expression<Func<Keyboard, bool>> filter = null, Func<IQueryable<Keyboard>, IOrderedQueryable<Keyboard>> orderBy = null, params Expression<Func<Keyboard, object>>[] includes)
        {
            var keyboards = _dataContext.keyboardRepository.GetList(filter, orderBy, includes);
            List<KeyboardDto> keyboardDtos = new List<KeyboardDto>();
            foreach (var item in keyboards)
            {
                keyboardDtos.Add(Mapper.MapToDto.KeyboardMapToDto(item));
            }
            return keyboardDtos;
        }

        public void Insert(Keyboard model)
        {
            _dataContext.keyboardRepository.Insert(model);
        }

        public Guid Update(Keyboard model)
        {
            _dataContext.keyboardRepository.Update(model);
            return model.ID;
        }

        public void DeleteById(Guid id)
        {
            _dataContext.keyboardRepository.Delete(id);
        }

        public void Save()
        {
            _dataContext.Save();
        }
    }
}
