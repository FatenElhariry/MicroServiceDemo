using AutoMapper;
using Mango.Kernal.DTOs;
using Mango.Kernal.Models;
using Mango.Services.ProductAPI.Persistence.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mango.Services.ProductAPI.Infrastructure.Services
{
    public class Service<TTDO, TEntity> : IService<TTDO, TEntity> where TTDO : class where TEntity : Entity
    {
        protected IRepository<TEntity> _repository;
        protected IMapper _mapper;
        protected ILogger _logger;
        public Service(IRepository<TEntity> repository, IMapper mapper, ILogger logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }
        public virtual ResponseDto Create(TTDO record)
        {
            _repository.Create(_mapper.Map<TTDO, TEntity>(record));
            return new ResponseDto(true);
        }

        public virtual ResponseDto Delete(long Id)
        {
            _repository.Delete(Id);
            return new ResponseDto(true);
        }

        public virtual ResponseDto Get(long Id)
        {
            return new ResponseDto(_repository.Get(Id));
        }

        public virtual ResponseDto GetAll()
        {
            return new ResponseDto(_repository.GetAll());
        }

        public virtual ResponseDto Update(TTDO record)
        {
            var entity = _repository.Update(_mapper.Map<TTDO, TEntity>(record));
            return new ResponseDto(entity);
        }
    }
}
