using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class ClutchTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void SimpleConstructorTest()
        {
            Clutch test = new Clutch();
            Assert.IsTrue(test.isFixed());
        }

        public void SimpleDestroyTest()
        {
            Clutch test = new Clutch();
            test.damageClutch();
            Assert.IsFalse(test.isFixed());
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator ClutchTestWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
