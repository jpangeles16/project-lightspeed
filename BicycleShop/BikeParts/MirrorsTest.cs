using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

/* Tests for the mirrors.
 * @author John Angeles
 */
namespace Tests
{
    public class MirrorsTest
    {
        public void assertIsTrue(bool value)
        {
            NUnit.Framework.Assert.IsTrue(value);
        }

        public void assertIsFalse(bool value)
        {
            NUnit.Framework.Assert.IsFalse(value);
        }

        // Constructor created mirrors that are fixed!
        [Test]
        public void SimpleConstructorTest()
        {
            Mirrors test = new Mirrors();
            Assert.IsTrue(test.isFixed());
        }

        [Test]
        public void BreakMirrorTest()
        {
            Mirrors test = new Mirrors();
            test.smashMirror();
            Assert.IsTrue(test.isCracked());
            Assert.IsTrue(test.isDirty());
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator MirrorsTestWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
