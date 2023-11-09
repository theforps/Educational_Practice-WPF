using educational_practice.data.repos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace educational_practice.tests
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public async void Test1()
        {
            BaseRepository db = new BaseRepository();
            bool check = await db.checkUserExist("executor1", "executor1");

            Assert.AreEqual(true, check);
        }
    }
}
