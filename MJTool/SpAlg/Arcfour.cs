using System;

namespace MJTool
{
	/// <summary>
	/// Description of Arcfour.
	/// </summary>
	public class Arcfour
	{
		private int i;
		private int j;
		private int[] S;

		public Arcfour()
		{
			this.i = 0;
			this.j = 0;
		}
		
		// Initialize arcfour context from key, an array of ints, each from [0..255]
		public void init(int[] key)
		{
			int i, j, t;
			this.S = new int[256];
			for (i = 0; i < 256; ++i)
			{
				this.S[i] = i;
			}
			j = 0;
			for (i = 0; i < 256; ++i)
			{
				j = (j + this.S[i] + key[i % key.Length]) & 255;
				t = this.S[i];
				this.S[i] = this.S[j];
				this.S[j] = t;
			}
			this.i = 0;
			this.j = 0;
		}

		public int next()
		{
			int t;
			this.i = (this.i + 1) & 255;
			this.j = (this.j + this.S[this.i]) & 255;
			t = this.S[this.i];
			this.S[this.i] = this.S[this.j];
			this.S[this.j] = t;
			return this.S[(t + this.S[this.i]) & 255];
		}

	}
}
