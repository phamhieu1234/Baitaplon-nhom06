using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaiTapLonNhom06.Models
{
    public class Employee
    {
        [Key]
        [Required]
        public string? MaID{get; set;}
        [Required]
        public string? TenNV{get; set;}
        [Required]
        public string? MaGioiTinh{get; set;}
       [ForeignKey("MaGioiTinh")]
       public GioiTinh? GioiTinh{get; set;}
         [Required]
        public string? Address{get; set;}
        [Required]
        [MinLength(10)]
        public string? SĐT{get; set;}
        [Required]
        [StringLength(10)]
        public string? CMND{get; set;}
         [Required]
        public string? MaChucVu{get; set;}
         [ForeignKey("MaChucVu")]
       public ChucVu? ChucVu{get; set;}
       
        
    }
}