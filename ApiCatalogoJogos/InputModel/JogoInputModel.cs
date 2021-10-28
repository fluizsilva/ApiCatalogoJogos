using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.InputModel
{
    public class JogoInputModel
    {
        [Required]
        [StringLength(100,MinimumLength =3,ErrorMessage ="O Nome do jogo deve conter ntre 3 e 100 caracteres")]
        public string Nome { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "O Nome da produtora deve conter ntre 1 e 100 caracteres")]
        public string Produtora { get; set; }

        [Required]
        [Range(1,1000, ErrorMessage = "O preço dev serde no mínimo 1 real e no máximo 1000 reais")]
        public double Preco { get; set; }


    }
}
