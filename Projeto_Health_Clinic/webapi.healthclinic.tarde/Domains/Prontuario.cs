using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthclinic.tarde.Domains
{
    [Table(nameof(Prontuario))]
    public class Prontuario
    {

        [Key]
        public Guid IdProntuario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "Descrição obrigatório !")]
        public string? Descricao { get; set; }
    }
}
