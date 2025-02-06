using System;
using System.Numerics;

namespace BlumBlumShub
{
    public class Generator
    {
        private BigInteger p;
        private BigInteger q;
        private BigInteger modulus;
        private BigInteger state;
        public Generator(BigInteger inputP, BigInteger inputQ, BigInteger seed)
        {
            p = inputP;
            q = inputQ;
            modulus = p * q;
            if (seed <= 0 || BigInteger.GreatestCommonDivisor(seed, modulus) != 1)
            {
                state = 1;
            }
            else
            {
                state = seed % modulus;
            }
        }

        public BigInteger Next()
        {
            state = BigInteger.ModPow(state, 2, modulus);
            return state;
        }

        public int NextBit()
        {
            state = BigInteger.ModPow(state, 2, modulus);
            return (int)(state % 2);
        }
    }
}