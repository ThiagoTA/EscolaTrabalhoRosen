using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrabalhoRosen1.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }

        public int MateriaEscolarId { get; set; }

        public MateriaEscolar MateriaEscolar { get; set; }
    }
}
