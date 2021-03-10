using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models.DTO.Result
{
    public class GenreDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class AddGenreDTO
    {
        public string Name { get; set; }
    }
}

