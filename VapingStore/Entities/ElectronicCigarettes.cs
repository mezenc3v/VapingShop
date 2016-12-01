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

        [Display(Name = "Описание")]
        [Required(ErrorMessage = "Пожалуйста, ввведите описание товара")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name="Вес")]
        [Required(ErrorMessage = "Пожалуйста, укажите вес товара")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Пожалуйста, укажите неотрицательное значение")]
        public int Weight { get; set; }

        [Display(Name="Размеры")]
        [Required(ErrorMessage = "Пожалуйста, укажите размеры товара")]
        public string Size { get; set; }

        [Display(Name = "Сопротивление")]
        [Required(ErrorMessage = "Пожалуйста, укажите сопротивление")]
        public string Resistance { get; set; }

        [Display(Name = "Обдув")]
        [Required(ErrorMessage = "Пожалуйста, укажите обдув")]
        public string Blowout { get; set; }

        [Display(Name = "Коннектор")]
        [Required(ErrorMessage = "Пожалуйста, укажите тип коннектора")]
        public string Connector { get; set; }

        [Display(Name = "Объем жидкости")]
        [Required(ErrorMessage = "Пожалуйста, укажите объем жидкости")]
        public string Volume { get; set; }

        [Display(Name = "Время зарядки")]
        [Required(ErrorMessage = "Пожалуйста, укажите время зарядки")]
        public string Time { get; set; }

        [Display(Name = "Разьем для зарядки")]
        [Required(ErrorMessage = "Пожалуйста, укажите тип разъема для зарядки")]
        public string Socket { get; set; }

        [Display(Name="Аккумулятор")]
        [Required(ErrorMessage = "Пожалуйста, укажите мощность")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Пожалуйста, укажите неотрицательное значение")]
        public int BattaryPower { get; set; }

        [Required(ErrorMessage = "Укажите цену")]
        [Range(0.01,double.MaxValue, ErrorMessage = "Пожалуйста, укажите неотрицательную цену")]
        [Display(Name="Цена (руб)")]
        public decimal Price { get; set; }

        [Display(Name = "Производитель")]
        [Required(ErrorMessage = "Пожалуйста, укажите производителя")]
        public string Produser { get; set; }

        [HiddenInput(DisplayValue = false)]
        [Display(Name = "Image")]
        public string Image { get; set; }
    }
}
