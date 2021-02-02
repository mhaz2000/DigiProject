using Domain.Models;
using Infrastructure.DtoModels;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Services.Services
{
    class PersonService
    {
        private readonly DataContext _dataContext;
        public PersonService()
        {
            _dataContext = new DataContext();
        }
        public PersonDto Get(Expression<Func<Person, bool>> filter, params Expression<Func<Person, object>>[] includes)
        {
            var person = _dataContext.PersonRepository.Get(filter, includes);
            return Mapper.MapToDto.PersonMapToDto(person);
        }

        public List<PersonDto> GetList(Expression<Func<Person, bool>> filter = null, Func<IQueryable<Person>, IOrderedQueryable<Person>> orderBy = null, params Expression<Func<Person, object>>[] includes)
        {
            var people = _dataContext.PersonRepository.GetList(filter, orderBy, includes);
            List<PersonDto> personDtos= new List<PersonDto>();
            foreach (var item in people)
            {
                personDtos.Add(Mapper.MapToDto.PersonMapToDto(item));
            }
            return personDtos;
        }

        public void Insert(Person model)
        {
            _dataContext.PersonRepository.Insert(model);
        }

        public void Update(Person model)
        {
            _dataContext.PersonRepository.Update(model);
        }

        public void DeleteById(Guid id)
        {
            _dataContext.PersonRepository.Delete(id);
        }

        public void Save()
        {
            _dataContext.Save();
        }
    }
}
