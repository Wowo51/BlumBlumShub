# Blum Blum Shub Algorithm

A pure C# library. No external dependencies except for Microsoft's unit testing. No binaries. Unit tested.

This code is free to use under the MIT.

## Overview
The Blum Blum Shub (BBS) algorithm is a cryptographically secure pseudorandom number generator (CSPRNG). It is based on the difficulty of factoring large composite numbers and is commonly used in cryptographic applications requiring high-quality random bits.

The BBS generator produces a sequence of bits that are computationally indistinguishable from true randomness, given that its modulus is the product of two large prime numbers.

## Algorithm
The Blum Blum Shub algorithm operates as follows:

1. Choose two large prime numbers, `p` and `q`, such that both are congruent to 3 modulo 4.
2. Compute the modulus `n = p * q`.
3. Select an initial seed `s` such that `s` is relatively prime to `n`.
4. Generate the next state using the recurrence relation:
   
   \[
   x_{i+1} = (x_i)^2 \mod n
   \]
   
   where `x_0 = s`.
5. Extract the least significant bit (LSB) of `x_i` as the next random bit.

## How to Use the Code
This C# implementation of the Blum Blum Shub algorithm provides methods to generate random numbers and random bits.

### Installation
Clone the repository and include the `BlumBlumShub` project in your solution.

### Example Usage
```csharp
using System;
using System.Numerics;
using BlumBlumShub;

class Program
{
    static void Main()
    {
        BigInteger p = 7;  // Must be a large prime in real-world use.
        BigInteger q = 11; // Must be a large prime in real-world use.
        BigInteger seed = 3; // Initial seed value.

        Generator generator = new Generator(p, q, seed);
        
        Console.WriteLine("Next pseudorandom number: " + generator.Next());
        Console.WriteLine("Next pseudorandom bit: " + generator.NextBit());
    }
}
```

### API Methods
- **`Generator(BigInteger p, BigInteger q, BigInteger seed)`**
  - Initializes the generator with the given prime numbers `p`, `q`, and the seed.
- **`BigInteger Next()`**
  - Generates the next pseudorandom number in the sequence.
- **`int NextBit()`**
  - Returns the least significant bit (LSB) of the generated number.

### Unit Testing
The project includes unit tests using Microsoft's MSTest framework. Run tests using Visual Studio Test Explorer or execute:
```sh
dotnet test BlumBlumShubTest
```

## Security Considerations
- Use large primes (at least 512 bits each) for cryptographic applications.
- Ensure the seed is chosen randomly and is relatively prime to `n`.
- Avoid reusing the modulus `n` for different applications to maintain security.

![AI Image](aiimage.jpg)
Copyright [TranscendAI.tech](https://TranscendAI.tech) 2025.</br>
Authored by Warren Harding. AI assisted.</br>

