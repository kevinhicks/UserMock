using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserMock;

namespace UserMock.Test
{
    [TestClass]
    public class MockedUserTest
    {
        [TestMethod]
        public void TestSwitchingOfUsers()
        {
            var user1 = UserMock.CreateUser("First User");
            var user2 = UserMock.CreateUser("Second User(Admin)");

            user1.DoAction((u) =>
            {
                Assert.AreEqual("First User", u.Identity.Name);
            });

            user2.DoAction((u) =>
            {
                Assert.AreEqual("Second User(Admin)", u.Identity.Name);
            });
        }

        [TestMethod]
        public void CreatingAUserShouldNotReturnNullEvenWithBlankName()
        {
            Assert.IsNotNull(new MockedUser(""));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Must Specify A User Name")]
        public void CreateUserShouldThrowAnErrorIfNoNameIsPassed()
        {
            new MockedUser(null);
        }
    }
}
