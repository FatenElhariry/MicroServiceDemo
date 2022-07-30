using Mango.Kernal.DTOs;
using Mango.Kernal.Models;
using Mango.Services.ProductAPI.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mango.Services.ProductAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<TDto, TEntity> where TDto : class where TEntity : Entity
    {
        IService<TDto, TEntity> _service;
        public BaseController(IService<TDto, TEntity> service)
        {
            _service = service;
        }

        [Route("{id}")]
        [HttpGet]
        [Produces(typeof(ResponseDto))]
        public ActionResult<ResponseDto> get(long id)
        {
            return _service.Get(id);
        }
        [HttpGet]
        public ActionResult<ResponseDto> get()
        {
            return _service.GetAll();
        }

        [HttpPost]
        public ActionResult<ResponseDto> Post(TDto entity)
        {
            return _service.Create(entity);
        }

        [HttpPut]   
        public ActionResult<ResponseDto> Put(TDto entity)
        {
            return _service.Update(entity);
        }

        [HttpDelete]
        public ActionResult<ResponseDto> Delete(long id)
        {
            return _service.Delete(id);
        }


    }
}
