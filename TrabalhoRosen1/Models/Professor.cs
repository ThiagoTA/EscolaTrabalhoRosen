using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrabalhoRosen1.Models
{
    public class Professor
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }

        public long? CPF { get; set; }

        public int MateriaEscolarId { get; set; }

        public MateriaEscolar MateriaEscolar { get; set; }
    }
}
