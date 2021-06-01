using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Forum_asp_net_core_webapi.Models
{
    public class Cathegory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(100, ErrorMessage="Este campo não pode ter mais do que 100 caracteres")]
        [MinLength(1, ErrorMessage="Este campo deve ser preenchido")]
        public string Name { get; set; }

        [MaxLength(500, ErrorMessage="Este campo não pode ter mais do que 500 caracteres")]
        [MinLength(1, ErrorMessage="Este campo deve ser preenchido")]
        public string Description { get; set; }
    }
}