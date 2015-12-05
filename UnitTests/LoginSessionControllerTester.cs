using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

using Util;
using WebInterface.Controllers;

namespace UnitTests
{
    [TestFixture]
    public class LoginSessionControllerTester : BaseTester
    {
        [Test]
        public void Test1()
        {
            LoginSessionController controller = new LoginSessionController();
            string password = "MhfSlcNPFmiy8L7sYZQw";
            Console.WriteLine("password: {0}", password);
            string encryptedPassword = MD5Utility.CreateMD5(password);
            Console.WriteLine("encryptedPassword: {0}", encryptedPassword);
        }
    }
}
