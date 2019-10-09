using System;
using System.ComponentModel.DataAnnotations;

namespace LocacaoBiblioteca.Model
{
    public class Usuarios : UserControls
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string Login { get; set; }
        [MaxLength(50)]
        [Required]
        public string Senha { get; set; }

    }
}
