using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Control_Inventario_SEBDOM_SAS.Models
{
    public class Balance
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NombreProducto { get; set; }

        [NotMapped]
        [Range(0, int.MaxValue, ErrorMessage = "Debe ser un número positivo")]
        public int? Entrada { get; set; }

        [NotMapped]
        [Range(0, int.MaxValue, ErrorMessage = "Debe ser un número positivo")]
        public int? Salida { get; set; }

        public double StockActual { get; set; }

    }
}
