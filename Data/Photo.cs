using System;
using System.Drawing;

namespace MyPhotoshop
{
	public class Photo
	{
		public readonly int Width;
		public readonly int Height;
		private readonly Pixel[,] Data;
		
		public Pixel this[int width, int height]
		{
			get { return Data[width, height]; }
			set { Data[width, height] = value; }
		}
	
		public Photo(int width, int height)
		{
			Width = width;
			Height = height;
			Data = new Pixel[width, height];
			for (var x = 0; x < Width; x++)
			for (var y = 0; y < Height; y++)
			{
				Data[x, y] = new Pixel();
			}
		}
	}
}

