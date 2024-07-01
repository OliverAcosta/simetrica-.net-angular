using DatabaseManager.ContextEntities;
using GestionDeUsuarios.Authentication.Constants;
using GestionDeUsuarios.Authentication.Models;
using GestionDeUsuarios.Commons;
using GestionDeUsuarios.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeUsuarioTestUnit
{
    [TestFixture]
    public class UserTodoTest
    {

        GestionDataContext db;
        UserTodosController controller;
        AccountController account;
        [OneTimeSetUp]
        public void Initialize()
        {
           db = new GestionDataContext();
           controller = new UserTodosController(null, db);
           account = new AccountController(null, db);
        
        }

        [TearDown]
        public void close()
        {
            db.Dispose();
        }

        [Test]
        [Order(0)]
        public async Task login()
        {
           ActionResult<RequestResult> logged = await account.Login(new UserModel
            {
                Username = "reyazul",
                Password = "$turey21"
           });
            Assert.True(logged.Result.GetType() == typeof(OkObjectResult));
        }

        [Test]
        [Order(1)]
        public async Task Get()
        {
            var result = await controller.Get(2);
            Assert.True(result.Result.GetType() == typeof(OkObjectResult));
        }

        [Test]
        [Order(2)]
        public async Task Paginate()
        {
            var result = await controller.Paginate(0,10);
            Assert.True(result.Result.GetType() == typeof(OkObjectResult));
        }
    }
}
