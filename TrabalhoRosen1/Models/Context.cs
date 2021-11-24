using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrabalhoRosen1.Models
{
    public class Context : DbContext
    {
        public DbSet<MateriaEscolar> MateriaEscolares { get; set; }
        public DbSet<Professor> Professores { get; set; }

        public DbSet<Aluno> Alunos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Escola;Integrated Security=True");
        }
    }
}
