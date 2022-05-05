using Microsoft.VisualStudio.TestTools.UnitTesting;
using TranslateApi.Controllers;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            var subDirectory = @"File/";
            var files = @"File/holaa.txt";
            //   //Act
            var result = FileController.Upload(files, subDirectory);
            //   //Assert
            Assert.AreEqual("Archivo enviado", result);

        }
    }
}
