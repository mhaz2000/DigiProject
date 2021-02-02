using Domain.Models;
using Infrastructure.DtoModels;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Services.Services
{
    public class ExternalHardService
    {
        private readonly DataContext _dataContext;
        public ExternalHardService()
        {
            _dataContext = new DataContext();
        }
        public ExternalHardDto Get(Expression<Func<ExternalHard, bool>> filter, params Expression<Func<ExternalHard, object>>[] includes)
        {
            var externalHard = _dataContext.ExternalHardRepository.Get(filter, includes);
            return Mapper.MapToDto.ExternalHardMapToDto(externalHard);
        }

        public List<ExternalHardDto> GetList(Expression<Func<ExternalHard, bool>> filter = null, Func<IQueryable<ExternalHard>, IOrderedQueryable<ExternalHard>> orderBy = null, params Expression<Func<ExternalHard, object>>[] includes)
        {
            var externalHards = _dataContext.ExternalHardRepository.GetList(filter, orderBy, includes);
            List<ExternalHardDto> externalHardDtos = new List<ExternalHardDto>();
            foreach (var item in externalHards)
            {
                externalHardDtos.Add(Mapper.MapToDto.ExternalHardMapToDto(item));
            }
            return externalHardDtos;
        }

        public void Insert(ExternalHard model)
        {
            _dataContext.ExternalHardRepository.Insert(model);
        }

        public Guid Update(ExternalHard model)
        {
            _dataContext.ExternalHardRepository.Update(model);
            return model.ID;
        }

        public void DeleteById(Guid id)
        {
            _dataContext.ExternalHardRepository.Delete(id);
        }

        public void Save()
        {
            _dataContext.Save();
        }
    }
}
