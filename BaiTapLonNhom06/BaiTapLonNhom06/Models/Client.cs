using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaiTapLonNhom06.Models
{
    public class Client
    {
        [Key]
        [Required]
        public string? KhachhangID{get; set;}
        [Required]
        public string? Ten{get; set;}
        [Required]
        public string?  MaGioiTinh {get;set;}
         [ForeignKey("MaGioiTinh")]
       public GioiTinh? GioiTinh{get; set;}
         [Required]
        public string? Address{get; set;}
        [Required]
        [MinLength(10)]
        public string? SĐT{get; set;}
        [Required]
        public string? CMND{get; set;}
        public string? Sophong{get; set;}
         [Required]
          [DataType(DataType.Date)]
        public DateTime? Ngayra { get; set; }
        [DataType(DataType.Date)]
        public DateTime? Ngayvao { get; set; }
 }
}