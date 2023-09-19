using Domain_Layer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.Interfaces
{
    public interface IBaseService<TEntity> where TEntity : BaseEntitie
    {
        TEntity Add<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>;

        void Delete(int id);

        IList<TEntity> Get();

        TEntity GetById(int id);

        TEntity Update<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>;
    }
}
