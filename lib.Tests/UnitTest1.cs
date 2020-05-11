using NUnit.Framework;
using System.Drawing;

using ds.test.impl;

namespace lib.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        { }

        [Test]
        public void AddTest()
        {
            Plugins x = new Plugins();
            IPlugin y = x.GetPlugin(x.GetPluginNames[0]);
            Assert.AreEqual(y.Run(2, 5), 7);
        }

        [Test]
        public void MinusTest()
        {
            Plugins x = new Plugins();
            IPlugin y = x.GetPlugin(x.GetPluginNames[1]);
            Assert.AreEqual(y.Run(2, 5), -3);
        }

        [Test]
        public void MultTest()
        {
            Plugins x = new Plugins();
            IPlugin y = x.GetPlugin(x.GetPluginNames[2]);
            Assert.AreEqual(y.Run(2, 5), 10);
        }

        [Test]
        public void GCDTest()
        {
            Plugins x = new Plugins();
            IPlugin y = x.GetPlugin(x.GetPluginNames[3]);
            Assert.AreEqual(y.Run(2019, 2020), 1);
        }

        [Test]
        public void LCMTest()
        {
            Plugins x = new Plugins();
            IPlugin y = x.GetPlugin(x.GetPluginNames[4]);
            Assert.AreEqual(y.Run(2, 3), 6);
        }
    }
}