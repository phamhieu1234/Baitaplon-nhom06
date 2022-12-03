using System.ComponentModel.DataAnnotations;
namespace BaiTapLonNhom06.Models
{
    public class GioiTinh
    {
        [Key]
        public string? MaGioiTinh{get; set;}
        public string? TenGioiTinh{get; set;}
    }
}