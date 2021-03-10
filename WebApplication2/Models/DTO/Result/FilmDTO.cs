using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models.DTO.Result
{
    public class FilmDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }

        /*Navigation Properties*/
        public string GenreName { get; set; }
        public int? GenreId { get; set; }
    }

    public class AddFilmDto
    {
        public string Name { get; set; }
        public int Year { get; set; }

        /*Navigation Properties*/
        public string GenreName { get; set; }
    }
}
