using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mango.Kernal.DTOs
{
    public class ResponseDto<TResult> 
    {
        public ResponseDto()
        {

        }
        public ResponseDto(TResult result)
        {
            Result = result;
            if (result != null)
            {
                IsSuccess = true;
                DisplayMessage = "Done Successfully";
            }
        }
        public bool IsSuccess { get; set; }
        public TResult Result { get; set; }
        public string DisplayMessage { get; set; }
        public List<string> ErrorMessages { get; set; }
    }
}
