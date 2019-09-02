using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class HandleBarsTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void SimpleConstructorTest()
        {
            HandleBars test = new HandleBars(5);
            Assert.IsTrue(5==test.Position());
        }

        [Test]
        public void SimpleRiseTests()
        {
            HandleBars test = new HandleBars(0);
            for (int i = 0; i < 10; i ++)
            {
                Assert.AreEqual(i, test.Position());
                test.Rise();
            }
            test.Rise();
            Assert.AreEqual(10, test.Position());
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator HandleBarsTestWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
