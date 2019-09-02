using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class SuspensionTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void SuspensionTestSimplePasses()
        {
            Suspension curr = new Suspension(3);
            Assert.AreEqual(3, curr.GetSetting());
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator SuspensionTestWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
