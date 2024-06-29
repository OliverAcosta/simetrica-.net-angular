
using DatabaseManager.ContextEntities;

namespace GestionDeUsuarioTestUnit
{
    [TestFixture]
    public class DatabaseTest
    {

        [Test]
        public void TestConnection()
        {
            var db = new GestionDataContext();
            Assert.IsNotNull(db.Database.CanConnect());
        }

        [Test]
        public void HasUser()
        {
            var db = new GestionDataContext();
            Assert.IsNotNull(db.Users.FirstOrDefault());
        }

        [Test]
        public void HasTodoUser()
        {
            var db = new GestionDataContext();
            Assert.IsNotNull(db.UserTodos.FirstOrDefault());
        }

    }
}
