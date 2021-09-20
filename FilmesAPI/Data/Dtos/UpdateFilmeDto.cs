using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Data.Dtos
{
    public class UpdateFilmeDto
    {
        [Required(ErrorMessage = "O campo Titulo é obrigatorio")] // para dizer que é obrigadtorio ter titulo
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo Diretor é obrigatorio")] // para dizer que é obrigadtorio ter diretor
        public string Diretor { get; set; }

        [StringLength(30, ErrorMessage = "Só pode ter 30 caracteres")]
        public string Genero { get; set; }

        [Range(1, 600, ErrorMessage = "A duração deve ter no minimo 1 e no máximo 600 minutos")] // duração de 1 minuto a 10 horas.
        public int Duracao { get; set; }
    }
}
