/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2013-4-14
 * Time: 10:07
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace MJTool.SpAlg
{
	/// <summary>
	/// // Modular reduction using "classic" algorithm
	/// </summary>
	public class Classic
	{
		private BigInteger m;
		public Classic(BigInteger m)
		{
			this.m = m;
		}
		
		public BigInteger convert(BigInteger x)
		{
			if (x.s < 0 || x.compareTo(this.m) >= 0)
			{
				return x.mod(this.m);
			}
			else
			{
				return x;
			}
		}

		public BigInteger revert(BigInteger x)
		{
			return x;
		}

		public void reduce(out BigInteger x)
		{
			x = new BigInteger();
			BigInteger q;
			x.divRemTo(this.m, out q, out x);
		}

		public void mulTo(BigInteger x, BigInteger y, out BigInteger r)
		{
			x.multiplyTo(y, out r);
			this.reduce(out r);
		}
		public void sqrTo(BigInteger x, out BigInteger r)
		{
			x.squareTo(out r);
			this.reduce(out r);
		}
	}
}
