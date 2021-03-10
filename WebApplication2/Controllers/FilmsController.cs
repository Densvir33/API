using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;
using WebApplication2.Models.DTO.Result;
using WebApplication2.Models.Entites;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FilmsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ResultDTO GetFilms()
        {
            try
            {
                var result = _context.Films.Select(x => new FilmDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Year = x.Year,
                    GenreName = x.Genre.Name,
                    GenreId = x.GenreId
                }).ToList();
                return new CollectionResultDTO<FilmDTO>
                {
                    IsSuccessful = true,
                    ResultCollection = result
                };
            }
            catch (Exception ex)
            {
                return new ErorDTO
                {
                    IsSuccessful = false,
                    Message = "Bablabla 404 ... "
                };
            }
        }

        [HttpPost("AddFilm")]
        public ResultDTO Add([FromBody] AddFilmDto dto)
        {
            try
            {
                Film film = new Film()
                {
                    Name = dto.Name,
                    Year = dto.Year,
                    GenreId = _context.Genres.FirstOrDefault(x => x.Name == dto.GenreName).Id
                };
                _context.Films.Add(film);
                _context.SaveChangesAsync();
                return new ResultDTO
                {
                    IsSuccessful = true,
                    Message = "Successfully created"
                };
            }
            catch (Exception ex)
            {
                return new ErorDTO
                {
                    IsSuccessful = false,
                    Message = "Something goes wrong!"
                };
            }
        }



    }
}

