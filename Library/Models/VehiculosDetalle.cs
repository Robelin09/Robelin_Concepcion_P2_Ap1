using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class VehiculosDetalle
    {
        [Key]
        public int Id { get; set; }
        public int VehiculoId { get; set; }
        [Required]
        public int AccesorioId { get; set; }
        [Required]
        public decimal Valor { get; set; }

    }
}
