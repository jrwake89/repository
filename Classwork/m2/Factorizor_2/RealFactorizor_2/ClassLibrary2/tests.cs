using System;
using Factorizor.BLL;
using JetBrains.ReSharper;
using NUnit.Framework;

namespace Factorizor.Tests
{
        [TestFixture]
        public class FactorTests
        {

        [Test]

            public void FactorTest()
            {
            Factor lowTest = new Factor();
                int[] actual = lowTest.GetFactors(1);

                Assert.AreEqual(1, actual);
            }

        [Test]
        public void HighFactorTest()
        {

            int[] answer = {1, 2, 11, 22, 71, 142, 781, 1562};
            Factor highTest = new Factor();
            int[] actual = highTest.GetFactors(1562);

            Assert.AreEqual(answer, actual);
        }

        [Test]
        public void ZeroTest()
        {

                int[] answer = {0};
                Factor zeroTest = new Factor();
                int[] actual = zeroTest.GetFactors(0);

                Assert.AreEqual(answer, actual);
        }

        [Test]
        public void ZeropTest()
        {

            bool answer = true;
            Perfect ZeropTest = new Perfect();
            bool actual = ZeropTest.IsPerfectNumber(0);

            Assert.AreEqual(answer, actual);
        }

        [Test]
        public void notPerfectTest()
        {

            bool answer = false;
            Perfect notPerfectTest = new Perfect();
            bool actual = notPerfectTest.IsPerfectNumber(2);

            Assert.AreEqual(answer, actual);
        }

        [Test]
        public void PerfectTest()
        {

            bool answer = true;
            Perfect PerfectTest = new Perfect();
            bool actual = PerfectTest.IsPerfectNumber(6);

            Assert.AreEqual(answer, actual);
        }

        [Test]
        public void PrimeTest()
        {

            bool answer = true;
            Prime PrimeTest = new Prime();
            bool actual = PrimeTest.GetPrime(2);

            Assert.AreEqual(answer, actual);
        }

        [Test]
        public void NotPrimeTest()
        {

            bool answer = false;
            Prime NotPrimeTest = new Prime();
            bool actual = NotPrimeTest.GetPrime(4);

            Assert.AreEqual(answer, actual);
        }

        [Test]
        public void ZeroPrimeTest()
        {

            bool answer = true;
            Prime ZeroPrimeTest = new Prime();
            bool actual = ZeroPrimeTest.GetPrime(0);

            Assert.AreEqual(answer, actual);
        }

    }
        
    
}
