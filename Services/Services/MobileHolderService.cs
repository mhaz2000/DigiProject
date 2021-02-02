using Domain.Models;
using Infrastructure.DtoModels;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace Services.Services
{
    public class MobileHolderService
    {
        private readonly DataContext _dataContext;
        public MobileHolderService()
        {
            _dataContext = new DataContext();
        }
        public MobileHolderDto Get(Expression<Func<MobileHolder, bool>> filter, params Expression<Func<MobileHolder, object>>[] includes)
        {
            var mobileHolder = _dataContext.MobileHolderRepository.Get(filter, includes);
            return Mapper.MapToDto.MobileHolderMapToDto(mobileHolder);
        }

        public List<MobileHolderDto> GetList(Expression<Func<MobileHolder, bool>> filter = null, Func<IQueryable<MobileHolder>, IOrderedQueryable<MobileHolder>> orderBy = null, params Expression<Func<MobileHolder, object>>[] includes)
        {
            var mobileHolders = _dataContext.MobileHolderRepository.GetList(filter, orderBy, includes);
            List<MobileHolderDto> mobileHolderDtos = new List<MobileHolderDto>();
            foreach (var item in mobileHolders)
            {
                mobileHolderDtos.Add(Mapper.MapToDto.MobileHolderMapToDto(item));
            }
            return mobileHolderDtos;
        }

        public void Insert(MobileHolder model)
        {
            _dataContext.MobileHolderRepository.Insert(model);
        }

        public Guid Update(MobileHolder model)
        {
            _dataContext.MobileHolderRepository.Update(model);
            return model.ID;
        }

        public void DeleteById(Guid id)
        {
            _dataContext.MobileHolderRepository.Delete(id);
        }

        public void Save()
        {
            _dataContext.Save();
        }
    }
}
