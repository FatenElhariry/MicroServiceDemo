using Mango.Kernal.DTOs;
using MangoRestaurant.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoRestaurant.Web.Services.IServices
{
    public interface IGenericService<TDto>
    {

        Task<ResponseDto<TDto>> CreateAsync(TDto entity);

        Task<ResponseDto<bool>> DeleteAsync(long id);

        Task<ResponseDto<IList<TDto>>> GetAllAsync();

        Task<ResponseDto<TDto>> GetByIdAsync(long id);

        Task<ResponseDto<TDto>> UpdateAsync(TDto entity);
    }
}
