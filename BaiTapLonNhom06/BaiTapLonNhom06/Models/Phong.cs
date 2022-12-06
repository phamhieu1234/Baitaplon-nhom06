using System.ComponentModel.DataAnnotations;
namespace BaiTapLonNhom06.Models
{
    public class Phong
    {
        [Key]
        public string? PhongID{get; set;}
        public string? TienPhong{get; set;}
        public string? CSVC{get; set;}
    }
}