using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UserMock;

namespace UserMock.Test
{
    [TestClass]
    public class UserMockTest
    {
        [TestMethod]
        public void CreateUserShouldNotReturnNull()
        {
            Assert.IsNotNull(UserMock.CreateUser("Test name"));
        }

        [TestMethod]
        public void CreateUserShouldNotReturnNullEvenWithBlankName()
        {
            Assert.IsNotNull(UserMock.CreateUser(""));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Must Specify A User Name")]
        public void CreateUserShouldThrowAnErrorIfNoNameIsPassed()
        {
            UserMock.CreateUser(null);
        }
    }
}
