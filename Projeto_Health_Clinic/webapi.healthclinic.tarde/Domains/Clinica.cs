using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthclinic.tarde.Domains
{
    [Table(nameof(Clinica))]
    [Index(nameof(CNPJ), IsUnique = true)]
    public class Clinica
    {

        [Key]
        public Guid IdClinica { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(50)")]
        [Required(ErrorMessage = "Nome fantasia obrigatório !")]
        public string? NomeFantasia { get; set; }

        [Column(TypeName = "VARCHAR(150)")]
        [Required(ErrorMessage = "Razão Social obrigatória !")]
        public string? RazaoSocial { get; set; }

        [Column(TypeName = "CHAR(14)")]
        [Required(ErrorMessage = "CNPJ obrigatório !")]
        [StringLength(14)]
        public string? CNPJ { get; set; }

        [Column(TypeName = "VARCHAR(200)")]
        [Required(ErrorMessage = "Endereço obrigatório !")]
        public string? Endereco { get; set; }

        //terminar HorarioAbertura e HorarioFechamento!!!

        [Column(TypeName = "TIME")]
        [Required(ErrorMessage = "Horário Abertura obrigatório !")]
        public TimeSpan? HorarioAbertuta { get; set; } = new TimeSpan();

        [Column(TypeName = "TIME")]
        [Required(ErrorMessage = "Horário Fchamento obrigatório !")]
        public TimeSpan? HorarioFechamento { get; set; } = new TimeSpan();

    }
}
