﻿using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        IRentalServices _rentalServices;

        public RentalsController(IRentalServices rentalServices)
        {
            _rentalServices = rentalServices;
        }

        [HttpGet("getall")]
        public IActionResult GettAll()
        {
            var result = _rentalServices.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _rentalServices.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(Rental rental)
        {
            var result = _rentalServices.Add(rental);
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpPost("delete")]
        public IActionResult Delete(Rental rental)
        {
            var result = _rentalServices.Delete(rental);
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpPost("update")]
        public IActionResult Update(Rental rental)
        {
            var result = _rentalServices.Update(rental);
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpGet("checkrentalcarid")]
        public IActionResult CheckRentalCarId(int carId)
        {
            var result = _rentalServices.CheckRentalCarId(carId);

            return Ok(result);


        }
    }
}
