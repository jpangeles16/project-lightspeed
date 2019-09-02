using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class BrakesTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void ConstructorTest()
        {
            Brakes fixedBrakes = new Brakes();
            Assert.IsTrue(fixedBrakes.IsFixed());

            Brakes broken = new Brakes(true);
            Assert.IsFalse(broken.IsFixed());

            Brakes toBrake = new Brakes();
            toBrake.Brake();
            Assert.IsFalse(broken.IsFixed());
        }

    }
}
