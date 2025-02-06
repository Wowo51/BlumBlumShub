using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Numerics;
using BlumBlumShub;

namespace BlumBlumShubTest
{
    [TestClass]
    public class BlumBlumShubTests
    {
        [TestMethod]
        public void TestValidSeedUsingNextMethod()
        {
            BigInteger p = 7;
            BigInteger q = 11;
            BigInteger seed = 3;
            Generator generator = new Generator(p, q, seed);
            BigInteger value1 = generator.Next(); // 3^2 mod 77 = 9
            BigInteger value2 = generator.Next(); // 9^2 mod 77 = 4
            BigInteger value3 = generator.Next(); // 4^2 mod 77 = 16
            Assert.AreEqual(new BigInteger(9), value1);
            Assert.AreEqual(new BigInteger(4), value2);
            Assert.AreEqual(new BigInteger(16), value3);
        }

        [TestMethod]
        public void TestValidSeedUsingNextBitMethod()
        {
            BigInteger p = 7;
            BigInteger q = 11;
            BigInteger seed = 3;
            Generator generator = new Generator(p, q, seed);
            int bit1 = generator.NextBit(); // (3^2 mod 77 = 9) -> 9 % 2 = 1
            int bit2 = generator.NextBit(); // (9^2 mod 77 = 4) -> 4 % 2 = 0
            int bit3 = generator.NextBit(); // (4^2 mod 77 = 16) -> 16 % 2 = 0
            int bit4 = generator.NextBit(); // (16^2 mod 77 = 25) -> 25 % 2 = 1
            Assert.AreEqual(1, bit1);
            Assert.AreEqual(0, bit2);
            Assert.AreEqual(0, bit3);
            Assert.AreEqual(1, bit4);
        }

        [TestMethod]
        public void TestInvalidSeedDefaultsToOne()
        {
            BigInteger p = 7;
            BigInteger q = 11;
            BigInteger seed = 0; // invalid seed, should default state to 1
            Generator generator = new Generator(p, q, seed);
            BigInteger next1 = generator.Next(); // 1^2 mod 77 = 1
            BigInteger next2 = generator.Next(); // 1^2 mod 77 = 1
            Assert.AreEqual(new BigInteger(1), next1);
            Assert.AreEqual(new BigInteger(1), next2);
            int bit = generator.NextBit(); // 1^2 mod 77 = 1 -> 1 % 2 = 1
            Assert.AreEqual(1, bit);
        }

        [TestMethod]
        public void TestLargeIterationBitDistribution()
        {
            // Using different Blum primes for a broader test.
            BigInteger p = 11;
            BigInteger q = 19;
            BigInteger seed = 3;
            Generator generator = new Generator(p, q, seed);
            int count0 = 0;
            int count1 = 0;
            for (int i = 0; i < 1000; i++)
            {
                int bit = generator.NextBit();
                if (bit == 0)
                {
                    count0++;
                }
                else if (bit == 1)
                {
                    count1++;
                }
            }

            Assert.IsTrue(count0 > 0);
            Assert.IsTrue(count1 > 0);
        }

        [TestMethod]
        public void TestNextMethodRange()
        {
            BigInteger p = 7;
            BigInteger q = 11;
            BigInteger seed = 3;
            Generator generator = new Generator(p, q, seed);
            BigInteger modulus = p * q;
            for (int i = 0; i < 100; i++)
            {
                BigInteger number = generator.Next();
                Assert.IsTrue(number >= 0 && number < modulus);
            }
        }

        [TestMethod]
        public void TestSeedMultipleOfPrime()
        {
            // Seed divisible by one of the primes should be considered invalid.
            BigInteger p = 7;
            BigInteger q = 11;
            BigInteger seed = 7; // invalid since GCD(7, 77) != 1
            Generator generator = new Generator(p, q, seed);
            BigInteger value = generator.Next(); // should default to using state = 1 => 1^2 mod 77 = 1
            Assert.AreEqual(new BigInteger(1), value);
        }
    }
}