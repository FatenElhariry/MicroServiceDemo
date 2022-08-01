using Mango.Kernal.DTOs;
using MangoRestaurant.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangoRestaurant.Web.Services.IServices
{
    public interface IBaseService
    {
        Task<ResponseDto<T>> SendAsync<T>(ApiRequest request);


    }
}
