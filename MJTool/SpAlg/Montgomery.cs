/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2013-4-14
 * Time: 10:21
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace MJTool.SpAlg
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
			BigInteger q, r;
			x.abs().dlShiftTo(this.m.t, out r);
			r.divRemTo(this.m, out q, out r);
			if (x.s < 0 && r.compareTo(BigInteger.ZERO) > 0)
			{
				this.m.subTo(r, out r);
			}
			return r;
		}

		// x/R mod m
		public BigInteger revert(BigInteger x)
		{
			BigInteger r;
			x.copyTo(out r);
			this.reduce(out r);
			return r;
		}

		// x = x/R mod m (HAC 14.32)
		public void reduce(out BigInteger x)
		{
			x  = new BigInteger();
			while (x.t <= this.mt2)
			{
				// pad x so am has enough room later
				x.datas[x.t++] = 0;
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
			x.drShiftTo(this.m.t, out x);
			if (x.compareTo(this.m) >= 0)
			{
				x.subTo(this.m, out x);
			}
		}

		// r = "x^2/R mod m"; x != r
		public void sqrTo(BigInteger x, out BigInteger r)
		{
			x.squareTo(out r);
			this.reduce(out r);
		}

		// r = "xy/R mod m"; x,y != r
		public void mulTo(BigInteger x, BigInteger y, out BigInteger r)
		{
			x.multiplyTo(y, out r);
			this.reduce(out r);
		}
	}
}
