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
    public class ServiceDecorator<TTDO, TEntity> : Service<TTDO, TEntity> where TTDO : class where TEntity : Entity
    {
        // Service<TTDO, TEntity> _service;
        public ServiceDecorator(IRepository<TEntity> repository, IMapper mapper, ILogger<ServiceDecorator<TTDO, TEntity>> logger) : base(repository, mapper, logger)
        {
           // _service = ;
        }

        public override ResponseDto Create(TTDO record)
        {
            try
            {
                return base.Create(record);

            }
            catch (Exception e)
            {
                return _handleException(e);
            }
        }

        public override ResponseDto Delete(long Id)
        {
            try
            {
                return base.Delete(Id);
            }
            catch (Exception e)
            {

                return _handleException(e);
            }
        }

        public override ResponseDto Get(long Id)
        {
            try
            {
                return base.Get(Id);
            }
            catch (Exception e)
            {
                return _handleException(e);
                throw;
            }
        }

        public override ResponseDto GetAll()
        {
            try
            {
                return base.GetAll();
            }
            catch (Exception e)
            {

                return _handleException(e);
            }
        }

        public override ResponseDto Update(TTDO record)
        {
            try
            {
                return base.Update(record);
            }
            catch (Exception e)
            {
                return _handleException(e);
            }
        }

        ResponseDto _handleException(Exception exception)
        {
            return new ResponseDto() { IsSuccess = false, ErrorMessages = new List<string>() { "Something wrong happened." } };
        }
    }
}
