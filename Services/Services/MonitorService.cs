using Domain.Models;
using Infrastructure.DtoModels;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace Services.Services
{
    public class MonitorService
    {
        private readonly DataContext _dataContext;
        public MonitorService()
        {
            _dataContext = new DataContext();
        }
        public MonitorDto Get(Expression<Func<Monitor, bool>> filter, params Expression<Func<Monitor, object>>[] includes)
        {
            var monitor = _dataContext.MonitorRepository.Get(filter, includes);
            return Mapper.MapToDto.MonitorMapToDto(monitor);
        }

        public List<MonitorDto> GetList(Expression<Func<Monitor, bool>> filter = null, Func<IQueryable<Monitor>, IOrderedQueryable<Monitor>> orderBy = null, params Expression<Func<Monitor, object>>[] includes)
        {
            var monitors = _dataContext.MonitorRepository.GetList(filter, orderBy, includes);
            List<MonitorDto> monitorDtos = new List<MonitorDto>();
            foreach (var item in monitors)
            {
                monitorDtos.Add(Mapper.MapToDto.MonitorMapToDto(item));
            }
            return monitorDtos;
        }

        public void Insert(Monitor model)
        {
            _dataContext.MonitorRepository.Insert(model);
        }

        public Guid Update(Monitor model)
        {
            _dataContext.MonitorRepository.Update(model);
            return model.ID;
        }

        public void DeleteById(Guid id)
        {
            _dataContext.MonitorRepository.Delete(id);
        }

        public void Save()
        {
            _dataContext.Save();
        }
    }
}
