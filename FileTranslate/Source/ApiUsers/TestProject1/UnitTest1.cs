using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApiUsers.Controller;
using ApiUsers.Models;
using System.Collections.Generic;
using System.Linq;
using ApiUsers.Data;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ValidarSiAgregaUsuarios()
        {
            // Arrange / Preparar el ambiente de nuestra prueba
            UserController context = new UserController();
            User user = new User();
            user.Name = "Andres";
            user.LastName = "Peralta";
            user.Email = "AndresPeralta@gmail.com";
            user.Password = "andresitoww123";
            // Act / Ejecucion de nuestro metodo en prueba
            var result = context.Post(user);
           //assert
            Assert.IsFalse(result.IsCompletedSuccessfully);
        }


        [TestMethod]
        public void UserList()
        {
            //arrange
            UserController context = new UserController();
            User user = new User();
            //act
            var result = context.GetAll();
            //assert
            Assert.IsFalse(result.IsCompletedSuccessfully);

        }
        [TestMethod]
        public void Login()
        {
            // Arrange / Preparar el ambiente de nuestra prueba
            UserController context = new UserController();
            User user = new User();
            user.Email = "AndresPeralta@gmail.com";
            user.Password = "andresitoww123";
            // Act / Ejecucion de nuestro metodo en prueba
            var result = context.Post(user);
            //assert
            Assert.IsFalse(result.IsCompletedSuccessfully);
        }
        [TestMethod]
        public void UsersListForId()
        {
            //arrange
            UserController context = new UserController();

            User user = new User();
            var id = 1;
            //act
            var result = context.GetAll();
            //assert
            Assert.IsFalse(result.IsCompletedSuccessfully);

        }
    }

}
