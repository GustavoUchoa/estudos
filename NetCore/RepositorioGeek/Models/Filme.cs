using System;
using System.ComponentModel.DataAnnotations;

namespace RepositorioGeek.Models
{
    public class Filme
    {
        [Key]
        public int Id { get; set; }

        [StringLength(200)]        
        public string IdProprietario { get; set; }

        [StringLength(80)]
        [Display(Name="Filme")]        
        [Required(ErrorMessage="Nome do filme é obrigatório")]        
        public String Nome { get; set; }
        
        [Display(Name="Assistido")]
        public bool Concluido { get; set; }

        [Display(Name="Classificação")]
        public int Classificacao { get; set; }

        [Display(Name="Data de Cadastro")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTimeOffset? DataCadastro { get; set; }

        [Display(Name="Data de Conclusão")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTimeOffset? DataConclusao { get; set; }
    }
}