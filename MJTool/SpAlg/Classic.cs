using System;

namespace MJTool
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

		public void reduce(BigInteger x)
		{
			if (x == null)
			{
				return;
			}
			x.divRemTo(this.m, null, x);
		}

		public void mulTo(BigInteger x, BigInteger y, BigInteger r)
		{
			if (x == null)
			{
				return;
			}
			x.multiplyTo(y, r);
			this.reduce(r);
		}
		public void sqrTo(BigInteger x, BigInteger r)
		{
			if (x == null)
			{
				return;
			}
			x.squareTo(r);
			this.reduce(r);
		}
	}
}
