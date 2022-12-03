using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BaiTapLonNhom06.Models
{
    public class Room
    {
        [Key]
        public string? RommID{get; set;}
        public string? MaGiaPhong{get; set;}
        [ForeignKey("MaGiaPhong")]
       public GiaPhong? GiaPhong{get; set;}
        public string? CSVC{get; set;}

    }
}