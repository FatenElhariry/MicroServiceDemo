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
        ResponseDto Get(long Id);
        ResponseDto GetAll();
        ResponseDto Update(TTDO record);
        ResponseDto Delete(long Id);
        ResponseDto Create(TTDO record);
    }
}
