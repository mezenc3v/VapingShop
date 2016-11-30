using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace VapingStore.Entities
{
    public class ElectronicCigarettes
    {
        [HiddenInput(DisplayValue =false)]
        [Display(Name="Id")]
        public int ElectronicCigarettesId { get; set; }

        [Display(Name="Название")]
        [Required(ErrorMessage = "Пожалуйста, ввведите название товара")]
        public string Name { get; set; }

        [Display(Name="Производитель")]
        [Required(ErrorMessage = "Пожалуйста, укажите производителя")]
        public string Produser { get; set; }

        [Display(Name="Вес")]
        [Required(ErrorMessage = "Пожалуйста, укажите вес товара")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Пожалуйста, укажите неотрицательное значение")]
        public int Weight { get; set; }

        [Display(Name="Длина")]
        [Required(ErrorMessage = "Пожалуйста, укажите длину товара")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Пожалуйста, укажите неотрицательное значение")]
        public int Length { get; set; }

        [Display(Name="Мощность")]
        [Required(ErrorMessage = "Пожалуйста, укажите мощность батареи")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Пожалуйста, укажите неотрицательное значение")]
        public int BattaryPower { get; set; }

        [Required(ErrorMessage = "Укажите цену")]
        [Range(0.01,double.MaxValue, ErrorMessage = "Пожалуйста, укажите неотрицательную цену")]
        [Display(Name="Цена (руб)")]
        public decimal Price { get; set; }

        [Display(Name = "Категория")]
        [Required(ErrorMessage = "Пожалуйста, укажите категорию товара")]
        public string CurrentCategory { get; set; }
    }
}
