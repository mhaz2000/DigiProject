using Domain.Models;
using Infrastructure.DtoModels;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Services.Services
{
    public class PowerBankService
    {
        private readonly DataContext _dataContext;
        public PowerBankService()
        {
            _dataContext = new DataContext();
        }
        public PowerBankDto Get(Expression<Func<PowerBank, bool>> filter, params Expression<Func<PowerBank, object>>[] includes)
        {
            var powerBank = _dataContext.PowerBankRepository.Get(filter, includes);
            return Mapper.MapToDto.PowerBankMapToDto(powerBank);
        }

        public List<PowerBankDto> GetList(Expression<Func<PowerBank, bool>> filter = null, Func<IQueryable<PowerBank>, IOrderedQueryable<PowerBank>> orderBy = null, params Expression<Func<PowerBank, object>>[] includes)
        {
            var powerBanks = _dataContext.PowerBankRepository.GetList(filter, orderBy, includes);
            List<PowerBankDto> powerBankDtos = new List<PowerBankDto>();
            foreach (var item in powerBanks)
            {
                powerBankDtos.Add(Mapper.MapToDto.PowerBankMapToDto(item));
            }
            return powerBankDtos;
        }

        public void Insert(PowerBank model)
        {
            _dataContext.PowerBankRepository.Insert(model);
        }

        public Guid Update(PowerBank model)
        {
            _dataContext.PowerBankRepository.Update(model);
            return model.ID;
        }

        public void DeleteById(Guid id)
        {
            _dataContext.PowerBankRepository.Delete(id);
        }

        public void Save()
        {
            _dataContext.Save();
        }
    }
}
