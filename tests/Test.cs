using educational_practice.windows;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace educational_practice.tests
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void Test1()
        {
            Login login = new Login();

            Assert.AreEqual(true, login.check("executor", "executor"));
        }
    }
}
