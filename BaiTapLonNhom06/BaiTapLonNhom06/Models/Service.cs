using System.ComponentModel.DataAnnotations;
namespace BaiTapLonNhom06.Models
{
    public class Service
    {
        [Key]
        [Required]
        public string? ServiceID{get; set;}
         [Required]
        public string? ServiceName{get; set;}
        public string? FoodName{get; set;}
        public string? DrinkName{get; set;}
        public string? HaircutName {get; set;}
        public string? Number {get; set;}
        [MinLength(1)]// do dai toi thieu la ba ki tu
          [Required]
        public string? ServicePrice {get; set;}
       
       
    }
}