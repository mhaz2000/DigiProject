using Domain.Models;
using Infrastructure.DtoModels;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Services.Services
{
    public class CommodityService
    {
        private readonly DataContext _dataContext;
        public CommodityService()
        {
            _dataContext = new DataContext();
        }
        public CommodityDto Get(Expression<Func<Commodity, bool>> filter, params Expression<Func<Commodity, object>>[] includes)
        {
            var commodity = _dataContext.CommodityRepository.Get(filter, includes);
            return Mapper.MapToDto.CommodityMapToDto(commodity);
        }

        public List<CommodityDto> GetList(Expression<Func<Commodity, bool>> filter = null, Func<IQueryable<Commodity>, IOrderedQueryable<Commodity>> orderBy = null, params Expression<Func<Commodity, object>>[] includes)
        {
            var commodities = _dataContext.CommodityRepository.GetList(filter, orderBy, includes);
            List<CommodityDto> commodityDtos= new List<CommodityDto>();
            foreach (var item in commodities)
            {
                commodityDtos.Add(Mapper.MapToDto.CommodityMapToDto(item));
            }
            return commodityDtos;
        }

        public void Insert(Commodity model)
        {
            _dataContext.CommodityRepository.Insert(model);
        }

        public void Update(Commodity model)
        {
            _dataContext.CommodityRepository.Update(model);
        }

        public void DeleteById(Guid id)
        {
            _dataContext.CommodityRepository.Delete(id);
        }

        public void Save()
        {
            _dataContext.Save();
        }
    }
}
