﻿using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        IColorServices _colorServices;

        public ColorsController(IColorServices colorServices)
        {
            _colorServices = colorServices;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _colorServices.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Color color)
        {
            var result = _colorServices.Add(color);
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpPost("delete")]
        public IActionResult Delete(Color color)
        {
            var result = _colorServices.Delete(color);
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost("update")]
        public IActionResult Update(Color color)
        {
            var result = _colorServices.Update(color);
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpPost("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _colorServices.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
