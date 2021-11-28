using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Microsoft.EntityFrameworkCore;
using TrabalhoRosen1.Models;
using Xunit;
using TrabalhoRosen1.Controllers;
using System.Threading;

namespace TestProject
{
    public class MateriaControllerTest
    {
        private readonly Mock<DbSet<MateriaEscolar>> _mockSet;
        private readonly Mock<Context> _mockContext;
        private readonly MateriaEscolar _materiaEscolar;

        public MateriaControllerTest()
        {
            _mockSet = new Mock<DbSet<MateriaEscolar>>();
            _mockContext = new Mock<Context>();
            _materiaEscolar = new MateriaEscolar { Id = 2, Nome = "Geografia"};


           /* _mockContext.Setup(m => m.MateriaEscolares).Returns(_mockSet.Object);

            _mockContext.Setup(m => m.MateriaEscolares.FindAsync(2))
                .ReturnsAsync(_materiaEscolar);*/
        }

        [Fact]
        public async Task Get_MateriaisEscolares()
        {
            var service = new MateriaEscolaresController(_mockContext.Object);
            await service.Details(2);

            _mockSet.Verify(m => m.FindAsync(2),
                Times.Once());
        }

        [Fact]
        public async Task Put_MateriaisEscolares()
        {
            var service = new MateriaEscolaresController(_mockContext.Object);
            await service.Edit(2, _materiaEscolar);

            _mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
        }
        [Fact]
        public async Task Post_MateriaisEscolares()
        {
            var service = new MateriaEscolaresController(_mockContext.Object);
            await service.Create(_materiaEscolar);

            _mockContext.Verify(m => m.Add(_materiaEscolar), Times.Once());
            _mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
        }

        [Fact]
        public async Task Delete_MateriaisEscolares()
        {
            var service = new MateriaEscolaresController(_mockContext.Object);
            await service.Delete(2);

            _mockSet.Verify(m => m.FindAsync(2), Times.Once());

            _mockSet.Verify(x => x.Remove(_materiaEscolar), Times.Once());
            _mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
        }
    }
}
