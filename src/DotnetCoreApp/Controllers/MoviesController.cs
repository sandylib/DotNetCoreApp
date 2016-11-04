using System;
using AutoMapper;
using DotnetCoreApp.Entities;
using DotnetCoreApp.Services;
using DotnetCoreApp.ViewModal;
using Microsoft.AspNetCore.Mvc;

namespace DotnetCoreApp.Controllers
{
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {
        private readonly IDataRepository _repo;

        public MoviesController(IDataRepository dataSrc)
        {
            _repo = dataSrc;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var movies = _repo.GetAll();
                return Ok(movies);
            }
            catch (Exception ex)
            {

                return new ObjectResult(this.Response)
                {
                    StatusCode = 500,
                    DeclaredType = typeof(Exception)
                };
            }

        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                if (id > 0)
                {
                    var movie = _repo.Get(id);
                    var result = Mapper.Map<MovieDataViewModel>(movie);
                    if (result != null) return Ok(result);

                    return this.NotFound();
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                
                return new ObjectResult(Response)
                {
                    StatusCode = 500,
                    DeclaredType = typeof(Exception)
                };
            }
        }


        [HttpPost]
        public IActionResult Post([FromBody]MovieDataViewModel newMovie)
        {
            try
            {

                if (newMovie == null)
                    return BadRequest("Movie can not be null");

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var movie = Mapper.Map<MovieData>(newMovie);

                if (_repo.Create(movie) != null) return Ok(newMovie);

                return BadRequest("Movie already existing");

            }
            catch (Exception ex)
            {
                return new ObjectResult(Response)
                {
                    StatusCode = 500,
                    DeclaredType = typeof(Exception)
                };
            }
        }
    }
}
