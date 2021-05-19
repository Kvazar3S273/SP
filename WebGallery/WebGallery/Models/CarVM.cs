using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebGallery.Models
{
    public class CarVM
    {
        public long Id { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Fuel { get; set; }
        public float Capacity { get; set; }
        public string Image { get; set; }
    }
}
