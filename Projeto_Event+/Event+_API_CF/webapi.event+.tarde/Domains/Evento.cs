using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.event_.tarde.Domains
{
    [Table(nameof(Evento))]
    public class Evento
    {

        [Key]
        public Guid IdEvento { get; set; } = Guid.NewGuid();

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "Data do Evento obrigatório !")]
        public DateTime DataEvento { get; set; }


        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Nome do Evento obrigatório !")]
        public string? NomeEvento { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "Descrição do Evento obrigatório !")]
        public string? Descricao { get; set; }

        //ref. tabela TipoEvento = FK
        [Required(ErrorMessage = "O tipo de evento é obrigatório !")]
        public Guid IdTipoEvento { get; set; }

        [ForeignKey(nameof(IdTipoEvento))]
        public TipoEvento? TipoEvento { get; set; }

        //ref. tabela Instituicao = FK
        [Required(ErrorMessage = "A instituição é obrigatória !")]
        public Guid IdInstituicao { get; set; }

        [ForeignKey(nameof(IdInstituicao))]
        public Instituicao? Instituicao { get; set; }
    }
}
