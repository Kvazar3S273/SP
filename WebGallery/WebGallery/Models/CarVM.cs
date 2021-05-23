using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebGallery.Models
{
    public class CarVM
    {
        public long Id { get; set; }
        
        [Required(ErrorMessage = "Вкажіть марку автомобіля")]
        public string Mark { get; set; }

        [Required(ErrorMessage = "Вкажіть модель автомобіля")]
        public string Model { get; set; }
        
        [Range(1950, 2021, ErrorMessage = "Не допустиме значення для року автомобіля")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Вкажіть тип пального")]
        public string Fuel { get; set; }

        [Required(ErrorMessage = "Вкажіть об'єм двигуна")]
        public float Capacity { get; set; }
        public string Image { get; set; }
    }
}
