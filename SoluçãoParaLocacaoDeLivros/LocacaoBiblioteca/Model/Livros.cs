using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocacaoBiblioteca.Model
{
    public class Livros : UserControls
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string Nome { get; set; }

    }
}
