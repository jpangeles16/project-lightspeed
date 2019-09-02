using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class ChainTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void SimpleChainTest()
        {
            Chain test = new Chain(5, 20);

            Assert.AreEqual(5, test.Condition);
            Assert.AreEqual(20, test.Tension);
            test.Tension = 15;
            Assert.AreEqual(15, test.Tension);
            test.Condition = 1;
            Assert.IsTrue(test.IsBadCondition());

        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator ChainTestWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
