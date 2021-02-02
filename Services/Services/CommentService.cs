using Domain.Models;
using Infrastructure.DtoModels;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace Services.Services
{
    public class CommentService
    {
        private readonly DataContext _dataContext;
        public CommentService()
        {
            _dataContext = new DataContext();
        }
        public CommentDto Get(Expression<Func<Comment, bool>> filter, params Expression<Func<Comment, object>>[] includes)
        {
            var comment = _dataContext.CommentRepository.Get(filter, includes);
            return Mapper.MapToDto.CommentMapToDto(comment);
        }

        public List<CommentDto> GetList(Expression<Func<Comment, bool>> filter = null, Func<IQueryable<Comment>, IOrderedQueryable<Comment>> orderBy = null, params Expression<Func<Comment, object>>[] includes)
        {
            var comments = _dataContext.CommentRepository.GetList(filter, orderBy, includes);
            List<CommentDto> commentDtos= new List<CommentDto>();
            foreach (var item in comments)
            {
                commentDtos.Add(Mapper.MapToDto.CommentMapToDto(item));
            }
            return commentDtos;
        }

        public void Insert(Comment model)
        {
            _dataContext.CommentRepository.Insert(model);
        }

        public void Update(Comment model)
        {
            _dataContext.CommentRepository.Update(model);
        }

        public void DeleteById(Guid id)
        {
            _dataContext.CommentRepository.Delete(id);
        }

        public void Save()
        {
            _dataContext.Save();
        }
    }
}
