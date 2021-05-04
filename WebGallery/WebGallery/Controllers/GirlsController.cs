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
                    Name = "Саша Маргалова",
                    Age=33,
                    Height=198,
                    Weight=95,
                    Image="1.png"
                },
                new GirlVM
                {
                    Name = "Наташа Ростова",
                    Age=18,
                    Height=202,
                    Weight=102,
                    Image = "2.jpg"
                },
            };
            return Ok(list);
        }
    }
}
