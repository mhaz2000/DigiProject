using Domain.Models;
using Infrastructure.DtoModels;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace Services.Services
{
    public class LaptopService
    {
        private readonly DataContext _dataContext;
        public LaptopService()
        {
            _dataContext = new DataContext();
        }
        public LaptopDto Get(Expression<Func<Laptop, bool>> filter, params Expression<Func<Laptop, object>>[] includes)
        {
            var laptop = _dataContext.LaptopsRepository.Get(filter, includes);
            return Mapper.MapToDto.LaptopMapToDto(laptop);
        }

        public List<LaptopDto> GetList(Expression<Func<Laptop, bool>> filter = null, Func<IQueryable<Laptop>, IOrderedQueryable<Laptop>> orderBy = null, params Expression<Func<Laptop, object>>[] includes)
        {
            var laptops = _dataContext.LaptopsRepository.GetList(filter, orderBy, includes);
            List<LaptopDto> laptopDtos = new List<LaptopDto>();
            foreach (var item in laptops)
            {
                laptopDtos.Add(Mapper.MapToDto.LaptopMapToDto(item));
            }
            return laptopDtos;
        }

        public void Insert(Laptop model)
        {
            _dataContext.LaptopsRepository.Insert(model);
        }

        public Guid Update(Laptop model)
        {
            _dataContext.LaptopsRepository.Update(model);
            return model.ID;
        }

        public void DeleteById(Guid id)
        {
            _dataContext.LaptopsRepository.Delete(id);
        }

        public void Save()
        {
            _dataContext.Save();
        }
    }
}
