using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebGallery.Entities;
using WebGallery.Entities.Data;
using WebGallery.Models;
using UIHelper;

namespace WebGallery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private IWebHostEnvironment _webHostEnvironment;
        private EFDataContext _context;
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
        [RequestSizeLimit(100_000_000)]
        public IActionResult AddCar([FromBody]CarView car)
        {
            _context.Cars.Add(new Car
            {
                Mark = car.Mark,
                Model = car.Model,
                Year = car.Year,
                Fuel = car.Fuel,
                Capacity = car.Capacity,
                Image = car.Image
            });


            var dir = Directory.GetCurrentDirectory();
            var ext = Path.GetExtension(car.Image);
            var dirSave = Path.Combine(dir, "uploads");
            var imageName = Path.GetRandomFileName() + ext;
            var imageSaveFolder = Path.Combine(dirSave, imageName);
            var imagen = car.Image.LoadBase64();
            imagen.Save(imageSaveFolder, ImageFormat.Jpeg);


            _context.SaveChanges();
            return Ok(new { message = "Was added"});
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var del_item = _context.Cars.Find(id);

            if (del_item == null)
            {
                return NotFound();
            }

            _context.Cars.Remove(del_item);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Car car)
        {

            if (car == null)
            {
                return BadRequest();
            }

            var res = _context.Cars.FirstOrDefault(x => x.Id == id);

            res.Mark = car.Mark;
            res.Model = car.Model;
            res.Year = car.Year;
            res.Image = car.Image;

            if (res == null)
            {
                return NotFound();
            }

            _context.SaveChanges();

            return NoContent();
        }
    }
}
