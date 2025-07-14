using System.ComponentModel.DataAnnotations;

namespace DeMoMVC.Models.Entities
{
    public class DaiLy
    {
        [Key]
        public string MaDaiLy { get; set; } = string.Empty;
        public string TenDaiLy { get; set; } = string.Empty;
        public string DiaChi { get; set; } = string.Empty;
    }
}
