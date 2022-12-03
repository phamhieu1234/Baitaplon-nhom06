using System.ComponentModel.DataAnnotations;
namespace BaiTapLonNhom06.Models
{
    public class ChucVu
    {
        [Key]
        public string? MaChucVu{get; set;}
        public string? TenChucVu{get; set;}
    }
}