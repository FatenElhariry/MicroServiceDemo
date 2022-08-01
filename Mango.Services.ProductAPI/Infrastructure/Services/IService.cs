using Mango.Kernal.DTOs;
using Mango.Kernal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mango.Services.ProductAPI.Infrastructure.Services
{
    public interface IService<TTDO, TEntity>
        where TTDO : class 
        where TEntity : Entity
    {
        ResponseDto<TTDO> Get(long Id);
        ResponseDto<IList<TTDO>> GetAll();
        ResponseDto<TTDO> Update(TTDO record);
        ResponseDto<bool> Delete(long Id);
        ResponseDto<bool> Create(TTDO record);
    }
}
