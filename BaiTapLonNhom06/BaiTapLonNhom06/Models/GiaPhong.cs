using System.ComponentModel.DataAnnotations;
namespace BaiTapLonNhom06.Models
{
    public class GiaPhong
    {
        [Key]
        public string? MaGiaPhong{get; set;}
        public string? TenGiaPhong{get; set;}
    }
}