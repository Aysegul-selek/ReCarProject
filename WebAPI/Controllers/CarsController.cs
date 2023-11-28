using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarServices _carServices;

        public CarsController(ICarServices carServices)
        {
            _carServices = carServices;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carServices.GetAll();
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);

        }

        [HttpGet("getcarbybrandid")]
        public IActionResult GetCarByBrandId(int brandId)
        {
            var result = _carServices.GetCarsByBrandId(brandId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("getcarbycolorid")]
        public IActionResult GetCarByColorId(int colorId)
        {
            var result = _carServices.GetCarsByBrandId(colorId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carServices.Add(car);
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carServices.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carServices.Delete(car);
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(Car car)
        {
            var result = _carServices.Update(car);
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest(result);
        }
        [HttpGet("getcardetailsid")]
        public IActionResult GetCarDetailsId(int carId)
        {
            var result = _carServices.GetCarDetailsId(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("getcardetail")]
        public IActionResult GetCarDetail()
        {
            var result = _carServices.GetCarDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}

