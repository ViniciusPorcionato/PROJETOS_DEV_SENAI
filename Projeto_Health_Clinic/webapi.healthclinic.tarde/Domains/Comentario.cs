using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthclinic.tarde.Domains
{
    [Table(nameof(Comentario))]
    public class Comentario
    {
        [Key]
        public Guid IdComentario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "Descrição obrigatório !")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "Paciente é obrigatório !")]
        public Guid IdPaciente { get; set; }

        [ForeignKey(nameof(IdPaciente))]
        public Paciente? Paciente { get; set; }


        [Required(ErrorMessage = "A Consulta é obrigatório !")]
        public Guid IdConsulta { get; set; }

        [ForeignKey(nameof(IdConsulta))]
        public Consulta? Consulta { get; set; }

    }
}
