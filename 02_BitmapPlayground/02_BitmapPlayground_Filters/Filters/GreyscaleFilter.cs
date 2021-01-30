using System;
using System.Drawing;


namespace _02_BitmapPlayground_Filters.Filters
{
    /// <summary>
    ///  Implement a grayscale filter from an image.
    /// </summary>
    public class GreyscaleFilter : IFilter
    {
        public Color[,] Apply(Color[,] input)
        {
            int width = input.GetLength(0);
            int height = input.GetLength(1);
            Color[,] result = new Color[width, height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    var p = input[x, y];
                    var scale = Convert.ToInt32((p.R + p.G + p.B) / 3);
                    result[x, y] = Color.FromArgb(p.A,scale,scale,scale);
                }
            }

            return result;
        }

        public string Name => "Greyscale filter";

        public override string ToString()
            => Name;
    }
}
