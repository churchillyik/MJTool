/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2013-4-12
 * Time: 19:56
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace MJTool
{
	/// <summary>
	/// Description of BigInteger.
	/// </summary>
	public class BigInteger
	{
		// Bits per digit
		private int dbits;
		
		private static long canary = 0xdeadbeefcafe;
		private static bool  j_lm = ((canary & 0xffffff) == 0xefcafe);

		// return new, unset BigInteger
		public BigInteger()
		{
		}
		
		// (public) Constructor
		public BigInteger(long a, int b, int c)
		{
			this.fromNumber(a, b, c);
		}
		
		public BigInteger(string a)
		{
			this.fromString(a, 256);
		}
		
		public BigInteger(string a, int b)
		{
			this.fromString(a, b);
		}
		
		// am: Compute w_j += (x*this_i), propagate carries,
		// c is initial carry, returns final carry.
		// c < 3*dvalue, x < 2*dvalue, this_i < dvalue
		// We need to select the fastest one that works in this environment.

		// am1: use a single mult and divide to get the high bits,
		// max digit bits should be 26 because
		// max internal value = 2*dvalue^2-2*dvalue (< 2^53)
		public int am1(int i, int x, int[] w, int j, int c, int n)
		{
			long v;
			while (--n >= 0)
			{
				v = x * this[i++] + w[j] + c;
				c = Math.Floor((double)v / 0x4000000);
				w[j++] = v & 0x3ffffff;
			}
			return c;
		}
	}
}
