using Domain.Models;
using Infrastructure.DtoModels;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Services.Services
{
    public class PromotionService
    {
        private readonly DataContext _dataContext;
        public PromotionService()
        {
            _dataContext = new DataContext();
        }
        public PromotionDto Get(Expression<Func<Promotion, bool>> filter, params Expression<Func<Promotion, object>>[] includes)
        {
            var promotion = _dataContext.PromotionRepository.Get(filter, includes);
            return Mapper.MapToDto.PromotionMapToDto(promotion);
        }

        public List<PromotionDto> GetList(Expression<Func<Promotion, bool>> filter = null, Func<IQueryable<Promotion>, IOrderedQueryable<Promotion>> orderBy = null, params Expression<Func<Promotion, object>>[] includes)
        {
            var promotions = _dataContext.PromotionRepository.GetList(filter, orderBy, includes);
            List<PromotionDto> promotionDtos = new List<PromotionDto>();
            foreach (var item in promotions)
            {
                promotionDtos.Add(Mapper.MapToDto.PromotionMapToDto(item));
            }
            return promotionDtos;
        }

        public void Insert(Promotion model)
        {
            _dataContext.PromotionRepository.Insert(model);
        }

        public void Update(Promotion model)
        {
            _dataContext.PromotionRepository.Update(model);
        }

        public void DeleteById(Guid id)
        {
            _dataContext.PromotionRepository.Delete(id);
        }

        public void Save()
        {
            _dataContext.Save();
        }
    }
}
