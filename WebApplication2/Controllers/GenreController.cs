using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class GenreController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GenreController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ResultDTO GetGenres()
        {
            try
            {
                var result = _context.Genres.Select(x => new GenreDTO
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList();
                return new CollectionResultDTO<GenreDTO>
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
                    Message = "abra cadabra maybe 404 ..."
                };
            }
        }

        [HttpPost("AddGenre")]
        public ResultDTO Add([FromBody] AddGenreDTO dto)
        {
            try
            {
                Genre genre = new Genre()
                {
                    Name = dto.Name
                };
                _context.Genres.Add(genre);
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
