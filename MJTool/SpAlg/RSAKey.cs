/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2013-4-16
 * Time: 22:32
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Globalization;

namespace MJTool
{
	/// <summary>
	/// Description of RSAKey.
	/// </summary>
	public class RSAKey
	{
		private BigInteger n;
		private int e;
		public RSAKey()
		{
			this.n = null;
			this.e = 0;
			/*
			this.d = null;
			this.p = null;
			this.q = null;
			this.dmp1 = null;
			this.dmq1 = null;
			this.coeff = null;
			*/
		}
		
		// convert a (hex) string to a bignum object
		public BigInteger parseBigInt(string str, int r)
		{
			BigInteger bint = new BigInteger(str, r);
			return bint;
		}

		private string linebrk(string s, int n)
		{
			string ret = "";
			int i = 0;
			while (i + n < s.Length)
			{
				ret += s.Substring(i, i + n) + "\n";
				i += n;
			}
			return ret + s.Substring(i, s.Length);
		}

		private string byte2Hex(byte b)
		{
			if (b < 0x10)
			{
				return "0" + Convert.ToString(b, 16);
			}
			else
			{
				return Convert.ToString(b, 16);
			}
		}

		// PKCS#1 (type 2, random) pad input string s to n bytes, and return a
		// bigint
		private BigInteger pkcs1pad2(string s, int n)
		{
			if (n < s.Length + 11)
			{
				// TODO: fix for utf-8
				//alert("Message too long for RSA");
				return null;
			}
			int[] ba = new int[256];
			int i = s.Length - 1;
			while (i >= 0 && n > 0)
			{
				char c = s[i--];
				if (c < 128)
				{
					// encode using utf-8
					ba[--n] = c;
				}
				else if ((c > 127) && (c < 2048))
				{
					ba[--n] = (c & 63) | 128;
					ba[--n] = (c >> 6) | 192;
				}
				else
				{
					ba[--n] = (c & 63) | 128;
					ba[--n] = ((c >> 6) & 63) | 128;
					ba[--n] = (c >> 12) | 224;
				}
			}
			ba[--n] = 0;
			SecureRandom rng = new SecureRandom();
			int[] x = new int[256];
			while (n > 2)
			{
				// random non-zero pad
				x[0] = 0;
				while (x[0] == 0)
				{
					rng.nextBytes(x);
				}
				ba[--n] = x[0];
			}
			ba[--n] = 2;
			ba[--n] = 0;
			//return new BigInteger(ba);
			return new BigInteger(ba[0]);
		}
		
		// Set the public key fields N and e from hex strings
		public void setPublic(string N, string E)
		{
			if (N != null && E != null && N.Length > 0 && E.Length > 0)
			{
				this.n = parseBigInt(N, 16);
				this.e = int.Parse(E, NumberStyles.HexNumber);
			}
			else
			{
				//alert("Invalid RSA public key");
			}
		}

		// Perform raw public operation on "x": return x^e (mod n)
		private BigInteger doPublic(BigInteger x)
		{
			return x.modPowInt(this.e, this.n);
		}

		// Return the PKCS#1 RSA encryption of "text" as an even-length hex string
		public string encrypt(string text)
		{
			BigInteger m = pkcs1pad2(text, (this.n.bitLength() + 7) >> 3);
			if (m == null)
			{
				return null;
			}
			BigInteger c = this.doPublic(m);
			if (c == null)
			{
				return null;
			}
			string h = c.toString(16);
			if ((h.Length & 1) == 0)
			{
				return h;
			}
			else
			{
				return "0" + h;
			}
		}
	}
}
