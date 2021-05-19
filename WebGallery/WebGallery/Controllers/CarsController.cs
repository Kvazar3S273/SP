using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGallery.Entities;
using WebGallery.Entities.Data;
using WebGallery.Models;

namespace WebGallery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly EFDataContext _context;
        public string _url = "https://ba2h.ga/img/";
        private IWebHostEnvironment _webHostEnvironment;
        public CarsController(EFDataContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpGet]
        [Route("search")]
        public IActionResult SearchCars()
        {
            var list = _context.Cars.Select(
                x => new
                {
                    x.Id,
                    x.Mark,
                    x.Model,
                    x.Year,
                    x.Fuel,
                    x.Capacity,
                    x.Image
                });
            return Ok(list);
        }

        [HttpGet("Model")]
        public IActionResult Search(string model)
        {
            var result = _context.Cars.FirstOrDefault(y => y.Model == model);

            if (result == null)
            {
                return NotFound(new { message = "Немає такої моделі!" });
            }
            return Ok(result);
        }

        [HttpGet("{fileName}")]
        public IActionResult Get(string fileName)
        {
            string path = _webHostEnvironment.ContentRootPath + "\\uploads\\";
            var filepath = path + fileName + ".jpg";

            if (System.IO.File.Exists(filepath))
            {
                byte[] bytes = System.IO.File.ReadAllBytes(filepath);
                return File(bytes, "image/jpg");
            }

            return NotFound(fileName + " Дане фото не знайдене!");
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddCar([FromBody]Car car)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();
            return Ok(new { message = "Was added"});
        }
    }
}
