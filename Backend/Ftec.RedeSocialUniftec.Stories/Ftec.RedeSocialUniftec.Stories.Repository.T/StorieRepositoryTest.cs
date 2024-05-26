using Ftec.RedeSocialUniftec.Stories.Domain.Entities;
using Ftec.RedeSocialUniftec.Stories.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ftec.RedeSocialUniftec.Stories.Repository.T
{
    [TestClass]
    public class StorieRepositoryTest
    {
        [TestMethod]
        public void PostarTest(Storie storie)
        {
            var storieRepository = new StorieRepository();
            try
            {
                storieRepository.Postar(new Storie());
                Assert.IsTrue(true);
            }
            catch (Exception ex)
            { 
                Assert.Fail(ex.Message);
            }
        }
    }
}
