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

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "Data consulta obrigatório !")]
        public DateTime? DataConsulta { get; set; }


        [Column(TypeName = "TIME")]
        [Required(ErrorMessage = "Hora consulta obrigatório !")]
        public TimeSpan? HoraConsulta { get; set; } = new TimeSpan();


        [Required(ErrorMessage = "O Médico é obrigatório !")]
        public Guid IdMedico { get; set; }

        [ForeignKey(nameof(IdMedico))]
        public Medico? Medico { get; set; }


        [Required(ErrorMessage = "O Paciente é obrigatório !")]
        public Guid IdPaciente { get; set; }

        [ForeignKey(nameof(IdPaciente))]
        public Paciente? Paciente { get; set; }


        [Required(ErrorMessage = "A Clinica é obrigatório !")]
        public Guid IdClinica { get; set; }

        [ForeignKey(nameof(IdClinica))]
        public Clinica? Clinica { get; set; }
    } 
}
