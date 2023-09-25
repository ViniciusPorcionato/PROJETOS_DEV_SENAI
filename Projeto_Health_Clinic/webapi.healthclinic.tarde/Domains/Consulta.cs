using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthclinic.tarde.Domains
{
    [Table(nameof(Consulta))]
    public class Consulta
    {

        [Key]
        public Guid IdConsulta { get; set; } = Guid.NewGuid();

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "Descrição obrigatório !")]
        public string? Descricao { get; set; }
    }
}
