using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebGallery.Models;

namespace WebGallery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GirlsController : ControllerBase
    {
        [HttpGet]
        [Route("search")]
        public IActionResult SearchGrils()
        {
            var list = new List<GirlVM>()
            {
                new GirlVM
                {
                    Name = "Альонушка Ужасна",
                    Age=63,
                    Height=298,
                    Weight=395,
                    Image="https://ba2h.ga/img/1.jpg"
                },
                new GirlVM
                {
                    Name = "Бабуся Добрийдень",
                    Age=78,
                    Height=159,
                    Weight=71,
                    Image = "https://ba2h.ga/img/2.jpg"
                },
                new GirlVM
                {
                    Name = "Дохторка Медсестра",
                    Age=16,
                    Height=158,
                    Weight=55,
                    Image="https://ba2h.ga/img/3.jpg"
                },
                new GirlVM
                {
                    Name = "Васіліса Прекрасна",
                    Age=28,
                    Height=180,
                    Weight=65,
                    Image = "https://ba2h.ga/img/4.jpg"
                }
            };
            return Ok(list);
        }
    }
}
