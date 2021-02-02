using Domain.Models;
using Infrastructure.DtoModels;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Services.Services
{
    public class AssembledCaseService
    {
        private readonly DataContext _dataContext;
        public AssembledCaseService()
        {
            _dataContext = new DataContext();
        }
        public AssembledCaseDto Get(Expression<Func<AssembledCase, bool>> filter, params Expression<Func<AssembledCase, object>>[] includes)
        {
            var assembledCase = _dataContext.AssembledCaseRepository.Get(filter, includes);
            return Mapper.MapToDto.AssembledCaseMapToDto(assembledCase);
        }

        public List<AssembledCaseDto> GetList(Expression<Func<AssembledCase, bool>> filter = null, Func<IQueryable<AssembledCase>, IOrderedQueryable<AssembledCase>> orderBy = null, params Expression<Func<AssembledCase, object>>[] includes)
        {
            var assembledCases = _dataContext.AssembledCaseRepository.GetList(filter, orderBy, includes);
            List<AssembledCaseDto> assembledCaseDtos= new List<AssembledCaseDto>();
            foreach (var item in assembledCases)
            {
                assembledCaseDtos.Add(Mapper.MapToDto.AssembledCaseMapToDto(item));
            }
            return assembledCaseDtos;
        }

        public void Insert(AssembledCase model)
        {
            _dataContext.AssembledCaseRepository.Insert(model);
        }

        public Guid Update(AssembledCase model)
        {
            _dataContext.AssembledCaseRepository.Update(model);
            return model.ID;
        }

        public void DeleteById(Guid id)
        {
            _dataContext.AssembledCaseRepository.Delete(id);
        }

        public void Save()
        {
            _dataContext.Save();
        }
    }
}
