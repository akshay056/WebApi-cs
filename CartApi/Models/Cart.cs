using System.ComponentModel.DataAnnotations;

namespace CartApi.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public int Qty { get; set; }
        public int Price { get; set; }
    }
}
