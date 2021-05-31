using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebGallery.Models
{
    public class CarView
    {
        [Required(ErrorMessage = "{0} не може бути порожнім"), StringLength(255, ErrorMessage = "{0} не може бути коротше {2} і довше {1} символів.", MinimumLength = 2)]
        public string Mark { get; set; }

        [Required(ErrorMessage = "{0} не може бути порожнім"), StringLength(255, ErrorMessage = "{0} не може бути коротше {2} і довше {1} символів.", MinimumLength = 2)]
        public string Model { get; set; }

        [Required, Range(1900, 2021, ErrorMessage = "неправильні межі дозволених значень")]
        public int Year { get; set; }
        
        [Required(ErrorMessage = "{0} не може бути порожнім"), StringLength(255, ErrorMessage = "{0} не може бути коротше {2} і довше {1} символів.", MinimumLength = 2)]
        public string Fuel { get; set; }
        
        [Required, Range(0, 100, ErrorMessage = "неправильні межі дозволених значень")]
        public float Capacity { get; set; }

        [Required(ErrorMessage = "{0} не може бути порожнім")]
        public string Image { get; set; }
    }
}
