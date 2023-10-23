using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Testing
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestBL_MateriaGetAllEF()
        {
            ML.Result result = BL.Materia.GetAllEF();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Correct);
        }
    }
}
