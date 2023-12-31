﻿using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        IcustomerServices _customerServices;

        public CustomersController(IcustomerServices customerServices)
        {
            _customerServices = customerServices;
        }

        [HttpGet("getall")]
        public IActionResult GettAll()
        {
            var result=_customerServices.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _customerServices.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(Customer customer)
        {
            var result=_customerServices.Add(customer);
            if (result.Success)
            {
                return Ok();
            }
                return BadRequest();
        }
        [HttpPost("delete")]
        public IActionResult Delete(Customer customer)
        {
            var result = _customerServices.Delete(customer);
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpPost("update")]
        public IActionResult Update(Customer customer)
        {
            var result = _customerServices.Update(customer);
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
