using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Accesorios
    {
        [Key]
        public int AccesorioId { get; set; }

        [Required(ErrorMessage ="Descripción Requerida")]

        public string Descripción { get; set; }
    }
}
