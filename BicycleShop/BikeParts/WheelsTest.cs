using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.Assertions;

namespace Tests
{
    public class WheelsTest
    {

        public void assertIsTrue(bool value)
        {
            NUnit.Framework.Assert.IsTrue(value);
        }

        public void assertIsFalse(bool value)
        {
            NUnit.Framework.Assert.IsFalse(value);
        }

        [Test]
        public void SimpleConstructorTest()
        {
            Wheel test1 = new Wheel(20, 30);
            assertIsTrue(test1.LowerBoundPSI() == 20);
            assertIsTrue(test1.UpperBoundPSI() == 30);
        }

        [Test]
        public void SimpleReducePSI()
        {
            Wheel test2 = new Wheel(20, 30);
            test2.SetPSI(10);
            assertIsTrue(test2.IsFlat());
        }

        [Test]
        public void SimplePopTire()
        {
            Wheel popTire = new Wheel(20, 30);
            popTire.Pop();
            assertIsTrue(popTire.IsFlat());
            assertIsTrue(popTire.IsPopped());
        }

        [Test]
        public void PumpTireTest()
        {
            Wheel toPump = new Wheel(20, 30);
            toPump.PumpTire();
            assertIsTrue(toPump.GetPSI() == 30);
            toPump.PumpTire();
            toPump.PumpTire();
            toPump.PumpTire();
            assertIsTrue(toPump.GetPSI() == 40);

            Wheel toPump2 = new Wheel(20, 30);
            toPump2.SetPSI(37);
            toPump2.PumpTire();
            assertIsTrue(40 == toPump2.GetPSI());
        }

        [Test]
        public void IsFixedTest()
        {
            Wheel fixedWheel = new Wheel(20, 30);
            assertIsTrue(fixedWheel.IsFixed());

            Wheel flatWheelButNotPopped = new Wheel(20, 30);
            flatWheelButNotPopped.SetPSI(15);
            assertIsTrue(flatWheelButNotPopped.IsFlat());

            Wheel poppedWheel = new Wheel(20, 30);
            poppedWheel.Pop();
            assertIsTrue(poppedWheel.IsPopped());
            assertIsFalse(poppedWheel.IsFixed());
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator WheelsTestWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
