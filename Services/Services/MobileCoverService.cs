using Domain.Models;
using Infrastructure.DtoModels;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace Services.Services
{
    public class MobileCoverService
    {
        private readonly DataContext _dataContext;
        public MobileCoverService()
        {
            _dataContext = new DataContext();
        }
        public MobileCoverDto Get(Expression<Func<MobileCover, bool>> filter, params Expression<Func<MobileCover, object>>[] includes)
        {
            var mobileCover = _dataContext.MobileCoverRepository.Get(filter, includes);
            return Mapper.MapToDto.MobileCoverMapToDto(mobileCover);
        }

        public List<MobileCoverDto> GetList(Expression<Func<MobileCover, bool>> filter = null, Func<IQueryable<MobileCover>, IOrderedQueryable<MobileCover>> orderBy = null, params Expression<Func<MobileCover, object>>[] includes)
        {
            var mobileCovers = _dataContext.MobileCoverRepository.GetList(filter, orderBy, includes);
            List<MobileCoverDto> mobileCoverDtos = new List<MobileCoverDto>();
            foreach (var item in mobileCovers)
            {
                mobileCoverDtos.Add(Mapper.MapToDto.MobileCoverMapToDto(item));
            }
            return mobileCoverDtos;
        }

        public void Insert(MobileCover model)
        {
            _dataContext.MobileCoverRepository.Insert(model);
        }

        public Guid Update(MobileCover model)
        {
            _dataContext.MobileCoverRepository.Update(model);
            return model.ID;
        }

        public void DeleteById(Guid id)
        {
            _dataContext.MobileCoverRepository.Delete(id);
        }

        public void Save()
        {
            _dataContext.Save();
        }
    }
}
