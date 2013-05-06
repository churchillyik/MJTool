using System;

namespace MJTool
{
	/// <summary>
	/// Montgomery reduction
	/// </summary>
	public class Montgomery
	{
		private BigInteger m;
		private int mp;
		private int mpl;
		private int mph;
		private int um;
		private int mt2;
		public Montgomery(BigInteger m)
		{
			if (m == null)
			{
				return;
			}
			this.m = m;
			this.mp = m.invDigit();
			this.mpl = this.mp & 0x7fff;
			this.mph = this.mp >> 15;
			this.um = (1 << (m.DB - 15)) - 1;
			this.mt2 = 2 * m.t;
		}
		
		// xR mod m
		public BigInteger convert(BigInteger x)
		{
			if (x == null)
			{
				return null;
			}
			BigInteger r = new BigInteger();
			x.abs().dlShiftTo(this.m.t, r);
			r.divRemTo(this.m, null, r);
			if (x.s < 0 && r.compareTo(BigInteger.ZERO) > 0)
			{
				this.m.subTo(r, r);
			}
			return r;
		}

		// x/R mod m
		public BigInteger revert(BigInteger x)
		{
			BigInteger r = new BigInteger();
			x.copyTo(r);
			this.reduce(r);
			return r;
		}

		// x = x/R mod m (HAC 14.32)
		public void reduce(BigInteger x)
		{
			if (x == null)
			{
				return;
			}
			while (x.t <= this.mt2)
			{
				// pad x so am has enough room later
				x.SetData(x.t++, 0);
			}
			for (int i = 0; i < this.m.t; ++i)
			{
				// faster way of calculating u0 = x[i]*mp mod DV
				int j = x.datas[i] & 0x7fff;
				int u0 = (j * this.mpl + (((j * this.mph + (x.datas[i] >> 15) * this.mpl) & this.um) << 15))
					& x.DM;
				// use am to combine the multiply-shift-add into one call
				j = i + this.m.t;
				x.datas[j] += this.m.am(0, u0, x.datas, i, 0, this.m.t);
				// propagate carry
				while (x.datas[j] >= x.DV)
				{
					x.datas[j] -= x.DV;
					x.datas[++j]++;
				}
			}
			x.clamp();
			x.drShiftTo(this.m.t, x);
			if (x.compareTo(this.m) >= 0)
			{
				x.subTo(this.m, x);
			}
		}

		// r = "x^2/R mod m"; x != r
		public void sqrTo(BigInteger x, BigInteger r)
		{
			if (x == null)
			{
				return;
			}
			x.squareTo(r);
			this.reduce(r);
		}

		// r = "xy/R mod m"; x,y != r
		public void mulTo(BigInteger x, BigInteger y, BigInteger r)
		{
			if (x == null)
			{
				return;
			}
			x.multiplyTo(y, r);
			this.reduce(r);
		}
	}
}
