using System.ComponentModel.DataAnnotations;

namespace Control_Inventario_SEBDOM_SAS.Models
{
    public class Inventario
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public bool WithCheese { get; set; }
        [Range(0.01, 9999.99)]
        public decimal Precio { get; set; }
    }
}
