using Ftec.RedeSocialUniftec.Stories.Domain.Entities;
using Ftec.RedeSocialUniftec.Stories.Repository.Repository;

namespace Ftec.RedeSocialUniftec.Stories.Repository.T
{
    [TestClass]
    public class StorieRepositoryTest
    {
        [TestMethod]
        public void PostarTest()
        {
            string strConexao = "User ID=jmenzen1; Password='8N9;FLC?;@?I;'; Host=pgsql.jmenzen.com.br; Port=5432; Database=jmenzen1;";
            var storieRepository = new StorieRepository(strConexao);
            try
            {
                Storie storie = new Storie();
                storie.Id = Guid.NewGuid();
                storie.IdUsuario = Guid.NewGuid();
                storie.Conteudo = Array.Empty<byte>();
                storie.NumVisualização = 10;
                storie.DataEnvio = DateTime.Now;
                storie.Situacao = SituacaoStorie.Disponível;

                storieRepository.Postar(storie);
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }


        [TestMethod]
        public void ArquivarTest()
        {
            string strConexao = "User ID=jmenzen1; Password='8N9;FLC?;@?I;'; Host=pgsql.jmenzen.com.br; Port=5432; Database=jmenzen1;";
            var storieRepository = new StorieRepository(strConexao);
            try
            {
                storieRepository.Arquivar(Guid.Parse("4010348d-4d6b-41c3-ad47-98d00dba423f"));
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void ExcluirTest()
        {
            string strConexao = "User ID=jmenzen1; Password='8N9;FLC?;@?I;'; Host=pgsql.jmenzen.com.br; Port=5432; Database=jmenzen1;";
            var storieRepository = new StorieRepository(strConexao);
            try
            {
                storieRepository.Excluir(Guid.Parse("00edd785-5d6b-4892-98d5-345721ad86f9"));
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void TemporizadorTest()
        {
            string strConexao = "User ID=jmenzen1; Password='8N9;FLC?;@?I;'; Host=pgsql.jmenzen.com.br; Port=5432; Database=jmenzen1;";
            var storieRepository = new StorieRepository(strConexao);
            try
            {
                storieRepository.Temporizador();
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void VisualizarTest()
        {
            string strConexao = "User ID=jmenzen1; Password='8N9;FLC?;@?I;'; Host=pgsql.jmenzen.com.br; Port=5432; Database=jmenzen1;";
            var storieRepository = new StorieRepository(strConexao);
            try
            {
                storieRepository.Visualizar(Guid.Parse("4010348d-4d6b-41c3-ad47-98d00dba423f"));
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
