using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models.DTO.Result
{
    public class SingleResultDTO<T> :ResultDTO
    {
        public T Result { get; set; }
    }
}
