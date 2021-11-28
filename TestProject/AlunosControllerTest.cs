using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Microsoft.EntityFrameworkCore;
using TrabalhoRosen1.Models;
using Xunit;
namespace TestProject
{
    public class AlunosControllerTest
    {
        private readonly Mock<DbSet<Aluno>> _mockSet;
        private readonly Mock<Context> _mockContext;
        private readonly Aluno _aluno;
        public AlunosControllerTest()
        {
            _mockSet = new Mock<DbSet<Aluno>>();
            _mockContext = new Mock<Context>();
            _aluno = new Aluno { Id = 1, MateriaEscolarId = 2, NomeCompleto = "Marcos" };
        }
    }
}
