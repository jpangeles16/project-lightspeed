using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class RadiatorTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void ConstructorTest()
        {
            Radiator fixedRadiator = new Radiator();
            Assert.IsTrue(fixedRadiator.IsFixed());
            Assert.IsFalse(fixedRadiator.IsLeaking());
            fixedRadiator.CauseLeak();
            Assert.IsTrue(fixedRadiator.IsLeaking());
            Assert.IsFalse(fixedRadiator.IsFixed());
            fixedRadiator.FixRadiator();
            Assert.IsTrue(fixedRadiator.IsFixed());
            Assert.IsFalse(fixedRadiator.IsLeaking());
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator RadiatorTestWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
