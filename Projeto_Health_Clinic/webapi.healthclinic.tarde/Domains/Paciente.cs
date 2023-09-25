using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.healthclinic.tarde.Domains
{
    [Table(nameof(Paciente))]
    [Index(nameof(RG), IsUnique = true)]
    [Index(nameof(CPF), IsUnique = true)]

    public class Paciente
    {
        [Key]
        public Guid IdPaciente { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(9)")]
        [Required(ErrorMessage = "RG obrigatório !")]
        public string? RG { get; set; }

        [Column(TypeName = "VARCHAR(11)")]
        [Required(ErrorMessage = "CPF obrigatório !")]
        public string? CPF { get; set; }

        [Column(TypeName = "VARCHAR(150)")]
        [Required(ErrorMessage = "Endereço obrigatório !")]
        public string? Endereco { get; set; }

        [Column(TypeName = "VARCHAR(10)")]
        [Required(ErrorMessage = "Telefone obrigatório !")]
        public string? Telefone { get; set; }


        [Required(ErrorMessage = "A Usuario é obrigatório !")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }

    }
}
