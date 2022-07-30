using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mango.Kernal.DTOs
{
    public class ResponseDto
    {
        public ResponseDto()
        {

        }
        public ResponseDto(Object result)
        {
            Result = result;
            if (result != null)
            {
                IsSuccess = true;
                DisplayMessage = "Done Successfully";
            }
        }
        public bool IsSuccess { get; set; }
        public object Result { get; set; }
        public string DisplayMessage { get; set; }
        public List<string> ErrorMessages { get; set; }
    }
}
