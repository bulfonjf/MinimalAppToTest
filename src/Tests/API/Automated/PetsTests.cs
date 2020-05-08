using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutomatedAPITests
{
    [TestClass]
    public class PetsTests
    {
        private PetsClient petsClient;
        [TestInitialize]
        public void SetUp()
        {
            petsClient = new PetsClient();
        }

        [TestMethod]
        public async Task GetPets()
        {
            var pets = await petsClient.GetPets();
            Assert.IsTrue(!pets.Any());
        }
    }
}
