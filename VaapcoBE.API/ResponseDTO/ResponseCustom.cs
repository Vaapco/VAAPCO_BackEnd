using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VaapcoBE.API.ResponseDTO
{
    public class ResponseCustom<T>
    {
        public T Data { get; set; }
        public List<string> Message { get; set; } = new List<string>();
    }
    public class ResponseCustom
    {
        public List<string> Message { get; set; } = new List<string>();
    }
}
