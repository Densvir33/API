using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models.DTO.Result
{
    public class CollectionResultDTO<T> : ResultDTO
    {
       public ICollection<T> ResultCollection { get; set; }
    }
}
