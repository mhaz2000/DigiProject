using Domain.Models;
using Infrastructure.DtoModels;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;



namespace Services.Services
{
    public class AccessoryService
    {
        private readonly DataContext _dataContext;
        public AccessoryService()
        {
            _dataContext = new DataContext();
        }
        public AccessoryDto Get(Expression<Func<Accessory, bool>> filter, params Expression<Func<Accessory, object>>[] includes)
        {
            var accessory = _dataContext.AccessoryRepository.Get(filter, includes);
            return Mapper.MapToDto.AccessoryMapToDto(accessory);
        }

        public List<AccessoryDto> GetList(Expression<Func<Accessory, bool>> filter = null, Func<IQueryable<Accessory>, IOrderedQueryable<Accessory>> orderBy = null, params Expression<Func<Accessory, object>>[] includes)
        {
            var accessories = _dataContext.AccessoryRepository.GetList(filter, orderBy, includes);
            List<AccessoryDto> accessoryDtos = new List<AccessoryDto>();
            foreach(var item in accessories)
            {
                accessoryDtos.Add(Mapper.MapToDto.AccessoryMapToDto(item));
            }
            return accessoryDtos;
        }

        public void Insert(Accessory model)
        {
            _dataContext.AccessoryRepository.Insert(model);
        }

        public void Update(Accessory model)
        {
            _dataContext.AccessoryRepository.Update(model);
        }

        public void DeleteById(Guid id)
        {
            _dataContext.AccessoryRepository.Delete(id);
        }

        public void Save()
        {
            _dataContext.Save();
        }
    }
}
