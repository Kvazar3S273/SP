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
        [Required(ErrorMessage = "Вкажіть марку автомобіля"), StringLength(255)]
        public string Mark { get; set; }
        /// <summary>
        /// Модель
        /// </summary>
        [Required(ErrorMessage = "Вкажіть модель автомобіля"), StringLength(255)]
        public string Model { get; set; }
        /// <summary>
        /// Рік
        /// </summary>
        [Range(1950, 2021, ErrorMessage = "Не допустиме значення для року автомобіля")]
        public int Year { get; set; }
        /// <summary>
        /// Пальне
        /// </summary>
        [Required(ErrorMessage = "Вкажіть тип пального"), StringLength(255)]
        public string Fuel { get; set; }
        /// <summary>
        /// Об'єм
        /// </summary>
        [Required(ErrorMessage = "Вкажіть об'єм двигуна")]
        public float Capacity { get; set; }
        /// <summary>
        /// Фото
        /// </summary>
        [StringLength(255)]
        public string Image { get; set; }
    }
}
