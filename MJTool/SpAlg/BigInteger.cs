/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2013-4-12
 * Time: 19:56
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace MJTool
{
	public enum ExplorerMod
	{
		IE,
		UNKNOWN,
		MOZILLA,
	}
	
	/// <summary>
	/// Description of BigInteger.
	/// </summary>
	public class BigInteger
	{
		// Bits per digit
		private int dbits;
		
		private static long canary = 0xdeadbeefcafe;
		private static bool j_lm = ((canary & 0xffffff) == 0xefcafe);
		private static int BI_FP = 52;

		private static ExplorerMod gMod = ExplorerMod.MOZILLA;
		
		public int[] datas = null;
		public int t;
		public int s;
		
		public static BigInteger ZERO = new BigInteger(0);
		public static BigInteger ONE = new BigInteger(1);
		
		// return new, unset BigInteger
		public BigInteger()
		{
		}
		
		// return bigint initialized to value
		public BigInteger(int nInteger)
		{
			this.fromInt(nInteger);
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
		private int am1(int i, int x, int[] w, int j, int c, int n)
		{
			int v;
			while (--n >= 0)
			{
				v = x * datas[i++] + w[j] + c;
				c = v / 0x4000000;
				w[j++] = v & 0x3ffffff;
			}
			return c;
		}
		
		// am2 avoids a big mult-and-extract completely.
		// Max digit bits should be <= 30 because we do bitwise ops
		// on values up to 2*hdvalue^2-hdvalue-1 (< 2^31)
		private int am2(int i, int x, int[] w, int j, int c, int n)
		{
			int xl = x & 0x7fff;
			int xh = x >> 15;
			while (--n >= 0)
			{
				int l = datas[i] & 0x7fff;
				int h = datas[i++] >> 15;
				int m = xh * l + h * xl;
				l = xl * l + ((m & 0x7fff) << 15) + w[j] + (c & 0x3fffffff);
				c = (l >> 30) + (m >> 15) + xh * h + (c >> 30);
				//c = (l >>> 30) + (m >>> 15) + xh * h + (c >>> 30);
				w[j++] = l & 0x3fffffff;
			}
			return c;
		}
		
		// Alternately, set max digit bits to 28 since some
		// browsers slow down when dealing with 32-bit numbers.
		private int am3(int i, int x, int[] w, int j, int c, int n)
		{
			int xl = x & 0x3fff;
			int xh = x >> 14;
			while (--n >= 0) {
				int l = datas[i] & 0x3fff;
				int h = datas[i++] >> 14;
				int m = xh * l + h * xl;
				l = xl * l + ((m & 0x3fff) << 14) + w[j] + c;
				c = (l >> 28) + (m >> 14) + xh * h;
				w[j++] = l & 0xfffffff;
			}
			return c;
		}
		
		public int am(int i, int x, int[] w, int j, int c, int n)
		{
			if (j_lm && (gMod == ExplorerMod.IE))
			{
				c = this.am2(i, x, w, j, c, n);
				dbits = 30;
			}
			else if (j_lm && (gMod != ExplorerMod.MOZILLA))
			{
				c = this.am1(i, x, w, j, c, n);
				dbits = 26;
			}
			else
			{
				// Mozilla/Netscape seems to prefer am3
				c = this.am3(i, x, w, j, c, n);
				dbits = 28;
			}
			
			return c;
		}
		
		public int DB
		{
			get
			{
				return dbits;
			}
		}
		
		public int DM
		{
			get
			{
				return ((1 << dbits) - 1);
			}
		}
		
		public int DV
		{
			get
			{
				return (1 << dbits);
			}
		}
		
		public int FV
		{
			get
			{
				return 2 ^ BI_FP;
			}
		}
		
		public int F1
		{
			get
			{
				return BI_FP - dbits;
			}
		}
		
		public int F2
		{
			get
			{
				return 2 * dbits - BI_FP;
			}
		}
		
		private static string BI_RM = "0123456789abcdefghijklmnopqrstuvwxyz";
		private static Dictionary<char, int> BI_RC = new Dictionary<char, int>();
		public static void init_BI_RC()
		{
			int vv;
			char rr = '0';
			for (vv = 0; vv <= 9; ++vv)
			{
				BI_RC.Add(rr, vv);
				rr++;
			}
			rr = 'a';
			for (vv = 10; vv < 36; ++vv)
			{
				BI_RC.Add(rr, vv);
				rr++;
			}
			rr = 'A';
			for (vv = 10; vv < 36; ++vv)
			{
				BI_RC.Add(rr, vv);
				rr++;
			}
		}
		
		private char int2char(int n)
		{
			return BI_RM[n];
		}
		
		private int intAt(string s, int i)
		{
			if (BI_RC.ContainsKey(s[i]))
			{
				return BI_RC[s[i]];
			}
			else
			{
				return -1;
			}
		}
		
		// (protected) copy this to r
		public void copyTo(BigInteger r)
		{
			if (r == null)
			{
				r = new BigInteger();
			}
			r.datas = new int[this.t];
			for (int i = this.t - 1; i >= 0; --i)
			{
				r.datas[i] = this.datas[i];
			}
			r.t = this.t;
			r.s = this.s;
		}
		
		// (protected) set from integer value x, -DV <= x < DV
		public void fromInt(int x)
		{
			this.t = 1;
			this.s = (x < 0) ? -1 : 0;
			this.datas = new int[1];
			if (x > 0)
			{
				this.datas[0] = x;
			}
			else if (x < -1)
			{
				this.datas[0] = x + DV;
			}
			else
			{
				this.t = 0;
			}
		}
		
		// (protected) set from string and radix
		public void fromString(string data_str, int radix)
		{
			int k;
			if (radix == 16)
			{
				k = 4;
			}
			else if (radix == 8)
			{
				k = 3;
			}
			else if (radix == 256)
			{
				k = 8; // byte array
			}
			else if (radix == 2)
			{
				k = 1;
			}
			else if (radix == 32)
			{
				k = 5;
			}
			else if (radix == 4)
			{
				k = 2;
			}
			else
			{
				this.fromRadix(data_str, radix);
				return;
			}
			this.t = 0;
			this.s = 0;
			
			int i = data_str.Length;
			bool mi = false;
			int sh = 0;
			
			this.datas = new int[i];
			while (--i >= 0)
			{
				int x = (k == 8) ? Convert.ToInt32(data_str[i]) & 0xff : this.intAt(data_str, i);
				if (x < 0)
				{
					if (data_str[i] == '-')
					{
						mi = true;
					}
					continue;
				}
				mi = false;
				if (sh == 0)
				{
					this.datas[this.t++] = x;
				}
				else if (sh + k > this.DB)
				{
					this.datas[this.t - 1] |= (x & ((1 << (this.DB - sh)) - 1)) << sh;
					this.datas[this.t++] = (x >> (this.DB - sh));
				}
				else
				{
					this.datas[this.t - 1] |= x << sh;
				}
				sh += k;
				if (sh >= this.DB)
				{
					sh -= this.DB;
				}
			}
			
			if (k == 8 && (data_str[0] & 0x80) != 0)
			{
				this.s = -1;
				if (sh > 0)
				{
					this.datas[this.t - 1] |= ((1 << (this.DB - sh)) - 1) << sh;
				}
			}
			this.clamp();
			if (mi)
			{
				ZERO.subTo(this, this);
			}
		}
		
		// (protected) clamp off excess high words
		public void clamp()
		{
			int c = this.s & this.DM;
			while (this.t > 0 && this.datas[this.t - 1] == c)
			{
				--this.t;
			}
		}
		
		// (public) return string representation in given radix
		public string toString(int radix)
		{
			if (this.s < 0)
			{
				return "-" + this.negate().toString(radix);
			}
			
			int k;
			if (radix == 16)
			{
				k = 4;
			}
			else if (radix == 8)
			{
				k = 3;
			}
			else if (radix == 2)
			{
				k = 1;
			}
			else if (radix == 32)
			{
				k = 5;
			}
			else if (radix == 4)
			{
				k = 2;
			}
			else
			{
				return this.toRadix(radix);
			}
			
			int km = (1 << k) - 1;
			int d;
			bool m = false;
			string r = "";
			int i = this.t;
			int p = this.DB - (i * this.DB) % k;
			
			if (i-- > 0)
			{
				if (p < this.DB && (d = this.datas[i] >> p) > 0)
				{
					m = true;
					r = this.int2char(d).ToString();
				}
				while (i >= 0)
				{
					if (p < k)
					{
						d = (this.datas[i] & ((1 << p) - 1)) << (k - p);
						d |= this.datas[--i] >> (p += this.DB - k);
					}
					else
					{
						d = (this.datas[i] >> (p -= k)) & km;
						if (p <= 0)
						{
							p += this.DB;
							--i;
						}
					}
					if (d > 0)
					{
						m = true;
					}
					if (m)
					{
						r += int2char(d).ToString();
					}
				}
			}
			return m ? r : "0";
		}
		
		// (public) -this
		public BigInteger negate()
		{
			BigInteger r = null;
			ZERO.subTo(this, r);
			return r;
		}
		
		// (public) |this|
		public BigInteger abs()
		{
			return (this.s < 0) ? this.negate() : this;
		}
		
		// (public) return + if this > a, - if this < a, 0 if equal
		public int compareTo(BigInteger a)
		{
			int r = this.s - a.s;
			if (r != 0)
			{
				return r;
			}
			int i = this.t;
			r = i - a.t;
			if (r != 0)
			{
				return r;
			}
			while (--i >= 0)
			{
				if ((r = this.datas[i] - a.datas[i]) != 0)
				{
					return r;
				}
			}
			return 0;
		}
		
		// returns bit length of the integer x
		private int nbits(int x)
		{
			int r = 1;
			int t;
			//if ((t = x >>> 16) != 0)
			if ((t = x >> 16) != 0)
			{
				x = t;
				r += 16;
			}
			if ((t = x >> 8) != 0)
			{
				x = t;
				r += 8;
			}
			if ((t = x >> 4) != 0)
			{
				x = t;
				r += 4;
			}
			if ((t = x >> 2) != 0)
			{
				x = t;
				r += 2;
			}
			if ((t = x >> 1) != 0)
			{
				x = t;
				r += 1;
			}
			return r;
		}
		
		// (public) return the number of bits in "this"
		public int bitLength()
		{
			if (this.t <= 0)
			{
				return 0;
			}
			return this.DB * (this.t - 1)
				+ nbits(this.datas[this.t - 1] ^ (this.s & this.DM));
		}
		
		// (protected) r = this << n*DB
		public void dlShiftTo(int n, BigInteger r)
		{
			if (r == null)
			{
				r = new BigInteger();
			}
			r.datas = new int[this.t + n];
			int i;
			for (i = this.t - 1; i >= 0; --i)
			{
				r.datas[i + n] = this.datas[i];
			}
			for (i = n - 1; i >= 0; --i)
			{
				r.datas[i] = 0;
			}
			r.t = this.t + n;
			r.s = this.s;
		}
		
		// (protected) r = this >> n*DB
		public void drShiftTo(int n, BigInteger r)
		{
			if (r == null)
			{
				r = new BigInteger();
			}
			for (int i = n; i < this.t; ++i)
			{
				r.datas[i - n] = this.datas[i];
			}
			r.t = Math.Max(this.t - n, 0);
			r.s = this.s;
		}
		
		// (protected) r = this << n
		public void lShiftTo(int n, BigInteger r)
		{
			if (r == null)
			{
				r = new BigInteger();
			}
			
			int bs = n % this.DB;
			int cbs = this.DB - bs;
			int bm = (1 << cbs) - 1;
			int ds = n / this.DB;
			int c = (this.s << bs) & this.DM;
			int i;
			for (i = this.t - 1; i >= 0; --i)
			{
				r.datas[i + ds + 1] = (this.datas[i] >> cbs) | c;
				c = (this.datas[i] & bm) << bs;
			}
			for (i = ds - 1; i >= 0; --i)
			{
				r.datas[i] = 0;
			}
			r.datas[ds] = c;
			r.t = this.t + ds + 1;
			r.s = this.s;
			r.clamp();
		}
		
		// (protected) r = this >> n
		public void rShiftTo(int n, BigInteger r)
		{
			if (r == null)
			{
				r = new BigInteger();
			}
			r.s = this.s;
			int ds = n / this.DB;
			if (ds >= this.t)
			{
				r.t = 0;
				return;
			}
			int bs = n % this.DB;
			int cbs = this.DB - bs;
			int bm = (1 << bs) - 1;
			r.datas[0] = this.datas[ds] >> bs;
			for (int i = ds + 1; i < this.t; ++i)
			{
				r.datas[i - ds - 1] |= (this.datas[i] & bm) << cbs;
				r.datas[i - ds] = this.datas[i] >> bs;
			}
			if (bs > 0)
			{
				r.datas[this.t - ds - 1] |= (this.s & bm) << cbs;
			}
			r.t = this.t - ds;
			r.clamp();
		}
		
		// (protected) r = this - a
		public void subTo(BigInteger a, BigInteger r)
		{
			if (a == null)
			{
				return;
			}
			if (r == null)
			{
				r = new BigInteger();
			}
			
			int i = 0, c = 0, m = Math.Min(a.t, this.t);
			while (i < m)
			{
				c += this.datas[i] - a.datas[i];
				r.datas[i++] = c & this.DM;
				c >>= this.DB;
			}
			if (a.t < this.t)
			{
				c -= a.s;
				while (i < this.t)
				{
					c += this.datas[i];
					r.datas[i++] = c & this.DM;
					c >>= this.DB;
				}
				c += this.s;
			}
			else
			{
				c += this.s;
				while (i < a.t)
				{
					c -= a.datas[i];
					r.datas[i++] = c & this.DM;
					c >>= this.DB;
				}
				c -= a.s;
			}
			r.s = (c < 0) ? -1 : 0;
			if (c < -1)
			{
				r.datas[i++] = this.DV + c;
			}
			else if (c > 0)
			{
				r.datas[i++] = c;
			}
			r.t = i;
			r.clamp();
		}

		// (protected) r = this * a, r != this,a (HAC 14.12)
		// "this" should be the larger one if appropriate.
		public void multiplyTo(BigInteger a, BigInteger r)
		{
			if (a == null)
			{
				return;
			}
			if (r == null)
			{
				r = new BigInteger();
			}
			BigInteger x = this.abs(), y = a.abs();
			int i = x.t;
			r.t = i + y.t;
			while (--i >= 0)
			{
				r.datas[i] = 0;
			}
			for (i = 0; i < y.t; ++i)
			{
				r.datas[i + x.t] = x.am(0, y.datas[i], r.datas, i, 0, x.t);
			}
			r.s = 0;
			r.clamp();
			if (this.s != a.s)
			{
				ZERO.subTo(r, r);
			}
		}

		// (protected) r = this^2, r != this (HAC 14.16)
		public void squareTo(BigInteger r)
		{
			if (r == null)
			{
				r = new BigInteger();
			}
			BigInteger x = this.abs();
			int i = r.t = 2 * x.t;
			while (--i >= 0)
			{
				r.datas[i] = 0;
			}
			for (i = 0; i < x.t - 1; ++i)
			{
				int c = x.am(i, x.datas[i], r.datas, 2 * i, 0, 1);
				r.datas[i + x.t] += x.am(i + 1, 2 * x.datas[i], r.datas, 2 * i + 1, c, x.t - i - 1);
				if (r.datas[i + x.t] >= x.DV)
				{
					r.datas[i + x.t] -= x.DV;
					r.datas[i + x.t + 1] = 1;
				}
			}
			if (r.t > 0)
			{
				r.datas[r.t - 1] += x.am(i, x.datas[i], r.datas, 2 * i, 0, 1);
			}
			r.s = 0;
			r.clamp();
		}

		// (protected) divide this by m, quotient and remainder to q, r (HAC 14.20)
		// r != q, this != m. q or r may be null.
		public void divRemTo(BigInteger m, BigInteger q, BigInteger r)
		{
			if (m == null)
			{
				return;
			}
			if (q == null)
			{
				q = new BigInteger();
			}
			if (r == null)
			{
				r = new BigInteger();
			}
			
			BigInteger pm = m.abs();
			if (pm.t <= 0)
			{
				return;
			}
			BigInteger pt = this.abs();
			if (pt.t < pm.t)
			{
				if (q != null)
				{
					q.fromInt(0);
				}
				if (r != null)
				{
					this.copyTo(r);
				}
				return;
			}

			BigInteger y = new BigInteger();
			int ts = this.s, ms = m.s;
			int nsh = this.DB - nbits(pm.datas[pm.t - 1]); // normalize modulus
			if (nsh > 0)
			{
				pm.lShiftTo(nsh, y);
				pt.lShiftTo(nsh, r);
			}
			else
			{
				pm.copyTo(y);
				pt.copyTo(r);
			}
			int ys = y.t;
			int y0 = y.datas[ys - 1];
			if (y0 == 0)
			{
				return;
			}
			int yt = y0 * (1 << this.F1) + ((ys > 1) ? y.datas[ys - 2] >> this.F2 : 0);
			int d1 = this.FV / yt, d2 = (1 << this.F1) / yt, e = 1 << this.F2;
			int i = r.t, j = i - ys;
			BigInteger t = (q == null) ? new BigInteger() : q;
			y.dlShiftTo(j, t);
			if (r.compareTo(t) >= 0)
			{
				r.datas[r.t++] = 1;
				r.subTo(t, r);
			}
			ONE.dlShiftTo(ys, t);
			t.subTo(y, y); // "negative" y so we can replace sub with am later
			while (y.t < ys)
			{
				y.datas[y.t++] = 0;
			}
			while (--j >= 0)
			{
				// Estimate quotient digit
				int qd = (r.datas[--i] == y0) ? this.DM
					: r.datas[i] * d1 + (r.datas[i - 1] + e) * d2;
				if ((r.datas[i] += y.am(0, qd, r.datas, j, 0, ys)) < qd)
				{
					// Try it out
					y.dlShiftTo(j, t);
					r.subTo(t, r);
					while (r.datas[i] < --qd)
					{
						r.subTo(t, r);
					}
				}
			}
			if (q != null)
			{
				r.drShiftTo(ys, q);
				if (ts != ms)
				{
					ZERO.subTo(q, q);
				}
			}
			r.t = ys;
			r.clamp();
			if (nsh > 0)
			{
				r.rShiftTo(nsh, r); // Denormalize remainder
			}
			if (ts < 0)
			{
				ZERO.subTo(r, r);
			}
		}

		// (public) this mod a
		public BigInteger mod(BigInteger a)
		{
			BigInteger r = new BigInteger();
			this.abs().divRemTo(a, null, r);
			if (this.s < 0 && r.compareTo(ZERO) > 0)
			{
				a.subTo(r, r);
			}
			return r;
		}
		
		// (protected) return "-1/this % 2^DB"; useful for Mont. reduction
		// justification:
		// xy == 1 (mod m)
		// xy = 1+km
		// xy(2-xy) = (1+km)(1-km)
		// x[y(2-xy)] = 1-k^2m^2
		// x[y(2-xy)] == 1 (mod m^2)
		// if y is 1/x mod m, then y(2-xy) is 1/x mod m^2
		// should reduce x and y(2-xy) by m^2 at each step to keep size bounded.
		// JS multiply "overflows" differently from C/C++, so care is needed here.
		public int invDigit()
		{
			if (this.t < 1)
			{
				return 0;
			}
			int x = this.datas[0];
			if ((x & 1) == 0)
			{
				return 0;
			}
			int y = x & 3; // y == 1/x mod 2^2
			y = (y * (2 - (x & 0xf) * y)) & 0xf; // y == 1/x mod 2^4
			y = (y * (2 - (x & 0xff) * y)) & 0xff; // y == 1/x mod 2^8
			y = (y * (2 - (((x & 0xffff) * y) & 0xffff))) & 0xffff; // y == 1/x mod
			// 2^16
			// last step - calculate inverse mod DV directly;
			// assumes 16 < DB <= 32 and assumes ability to handle 48-bit ints
			y = (y * (2 - x * y % this.DV)) % this.DV; // y == 1/x mod 2^dbits
			// we really want the negative inverse, and -DV < y < DV
			return (y > 0) ? this.DV - y : -y;
		}
		
		// (protected) true iff this is even
		public bool isEven()
		{
			return ((this.t > 0) ? (this.datas[0] & 1) : this.s) == 0;
		}

		// (protected) this^e, e < 2^32, doing sqr and mul with "r" (HAC 14.79)
		public BigInteger exp(int e, Classic z)
		{
			if (e > 0x7fffffff || e < 1)
			{
				return BigInteger.ONE;
			}
			BigInteger r = new BigInteger(), r2 = new BigInteger();
			BigInteger g = z.convert(this);
			int i = nbits(e) - 1;
			g.copyTo(r);
			while (--i >= 0)
			{
				z.sqrTo(r, r2);
				if ((e & (1 << i)) > 0)
				{
					z.mulTo(r2, g, r);
				}
				else
				{
					BigInteger t = r;
					r = r2;
					r2 = t;
				}
			}
			return z.revert(r);
		}
		
		// (protected) this^e, e < 2^32, doing sqr and mul with "r" (HAC 14.79)
		public BigInteger exp(int e, Montgomery z)
		{
			if (e > 0x7fffffff || e < 1)
			{
				return BigInteger.ONE;
			}
			BigInteger r = new BigInteger(), r2 = new BigInteger();
			BigInteger g = z.convert(this);
			int i = nbits(e) - 1;
			g.copyTo(r);
			while (--i >= 0)
			{
				z.sqrTo(r, r2);
				if ((e & (1 << i)) > 0)
				{
					z.mulTo(r2, g, r);
				}
				else
				{
					BigInteger t = r;
					r = r2;
					r2 = t;
				}
			}
			return z.revert(r);
		}

		// (public) this^e % m, 0 <= e < 2^32
		public BigInteger modPowInt(int e, BigInteger m)
		{
			BigInteger r = null;
			if (e < 256 || m.isEven())
			{
				Classic z = new Classic(m);
				r = this.exp(e, z);
			}
			else
			{
				Montgomery z = new Montgomery(m);
				r = this.exp(e, z);
			}
			return r;
		}
		
		private void fromNumber(long a, int b, int c)
		{
		}
		
		private void fromRadix(string data_str, int radix)
		{
			
		}
		
		private string toRadix(int radix)
		{
			return null;
		}
	}
}
