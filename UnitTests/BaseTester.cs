using System;
using System.IO;

using log4net.Config;

using NUnit.Framework;

namespace UnitTests
{
    public abstract class BaseTester
    {
        [TestFixtureSetUp]
        public static void FixtureSetup()
        {
            XmlConfigurator.Configure(new FileInfo(string.Format(@"{0}log4net.config", AppDomain.CurrentDomain.BaseDirectory)));
        }
    }
}
