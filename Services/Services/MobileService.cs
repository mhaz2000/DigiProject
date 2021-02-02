using Domain.Models;
using Infrastructure.DtoModels;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace Services.Services
{
    public class MobileService
    {
        private readonly DataContext _dataContext;
        public MobileService()
        {
            _dataContext = new DataContext();
        }
        public MobileDto Get(Expression<Func<Mobile, bool>> filter, params Expression<Func<Mobile, object>>[] includes)
        {
            var mobile = _dataContext.MobileRepository.Get(filter, includes);
            return Mapper.MapToDto.MobileMapToDto(mobile);
        }

        public List<MobileDto> GetList(Expression<Func<Mobile, bool>> filter = null, Func<IQueryable<Mobile>, IOrderedQueryable<Mobile>> orderBy = null, params Expression<Func<Mobile, object>>[] includes)
        {
            var mobiles = _dataContext.MobileRepository.GetList(filter, orderBy, includes);
            List<MobileDto> mobileDtos = new List<MobileDto>();
            foreach (var item in mobiles)
            {
                mobileDtos.Add(Mapper.MapToDto.MobileMapToDto(item));
            }
            return mobileDtos;
        }

        public void Insert(Mobile model)
        {
            _dataContext.MobileRepository.Insert(model);
        }

        public Guid Update(Mobile model)
        {
            _dataContext.MobileRepository.Update(model);
            return model.ID;
        }

        public void DeleteById(Guid id)
        {
            _dataContext.MobileRepository.Delete(id);
        }

        public void Save()
        {
            _dataContext.Save();
        }
    }
}
