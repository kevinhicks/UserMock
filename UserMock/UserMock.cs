using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;
using System.Web;
using System.IO;

namespace UserMock
{
    /// <summary>
    /// Creates new Mocked Users
    /// </summary>
    public class UserMock
    {
        /// <summary>
        /// Static ctor to make sure that we have a working HttpContext to work off of
        /// </summary>
        static UserMock()
        {
            if (HttpContext.Current == null)
            {
                HttpContext.Current = new HttpContext(new HttpRequest("", "http://localhost/", ""), new HttpResponse(new StringWriter()));
            }            
        }

        /// <summary>
        /// Create a new User to play around with
        /// </summary>
        /// <param name="name">The name of the user to use for testing</param>
        /// <returns></returns>
        public static MockedUser CreateUser(string name)
        {
            return new MockedUser(name);
        }
    }

    /// <summary>
    /// Represents a single User in the system, and performs actions as this user
    /// </summary>
    public class MockedUser
    {
        /// <summary>
        /// A user as the world likes to see it
        /// </summary>
        public IPrincipal User { get; set; }

        /// <summary>
        /// Crates a new user with a specifyed name
        /// </summary>
        /// <param name="name"></param>
        public MockedUser(string name)
        {
            //A name is neccesary
            if (name == null)
            {
                throw new ArgumentNullException("Must Specify A User Name");
            }

            //Create our actual user object so we can use it later
            User = new GenericPrincipal(new GenericIdentity(name), new string[] { });
        }

        /// <summary>
        /// Switch to this user, and perform an action as this user
        /// </summary>
        /// <param name="action"></param>
        public void DoAction(Action<IPrincipal> action)
        {
            switchToThisUser();
            action(User);
        }

        /// <summary>
        /// Tell the system that I am the currant user. and any actions to 
        /// follow are to be done unser my user account.
        /// </summary>
        protected void switchToThisUser()
        {
            HttpContext.Current.User = User;
        }
    }
}
