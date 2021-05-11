using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebGallery.Entities.Data
{
    /// <summary>
    /// Автомобілі
    /// </summary>
    [Table("tblCars")]
    public class Car
    {
        [Key]
        public long Id { get; set; }
        /// <summary>
        /// Марка
        /// </summary>
        [Required, StringLength(255)]
        public string Mark { get; set; }
        /// <summary>
        /// Модель
        /// </summary>
        [Required, StringLength(255)]
        public string Model { get; set; }
        /// <summary>
        /// Рік
        /// </summary>
        public int Year { get; set; }
        /// <summary>
        /// Пальне
        /// </summary>
        [Required, StringLength(255)]
        public string Fuel { get; set; }
        /// <summary>
        /// Об'єм
        /// </summary>
        public float Capacity { get; set; }
        /// <summary>
        /// Фото
        /// </summary>
        [StringLength(255)]
        public string Image { get; set; }
    }
}
