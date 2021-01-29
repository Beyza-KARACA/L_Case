using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_BitmapPlayground.Filters
{
    /// <summary>
    ///  Implement a moving average filter from an image.
    /// </summary>
    class MovingAverageFilter:IFilter
    {
        public Color[,] Apply(Color[,] input)
        {
            int width = input.GetLength(0);
            int height = input.GetLength(1);
            int r = 0;
            int g = 0;
            int b = 0;
            Color[,] result = new Color[width, height];

            for (int x = 0; x < width; x++)
            {
                r = 0;
                g = 0;
                b = 0;
                
                for (int y = 0; y < height; y++)
                {
                    var p = input[x, y];
                    if (y == 0 || y >= height-1 || x == 0 || x >= width-1)
                    {
                        
                        result[x, y] = Color.FromArgb(p.A, p.R, p.G, p.B);
                    }

                    else
                    {
                        var Lp = input[x-1, y];
                        var Rp = input[x+1, y];
                        var Up = input[x, y-1];
                        var Dp = input[x, y+1];
                        r = (Lp.R + Rp.R + Up.R + Dp.R) / 4;
                        g = (Lp.G + Rp.G + Up.G + Dp.G) / 4;
                        b = (Lp.B + Rp.B + Up.B + Dp.B) / 4;
                        result[x, y] = Color.FromArgb(p.A, r,g,b);

                    }
                    
                }
            }

            return result;
        }

        public string Name => "Moving Average Filter";

        public override string ToString()
            => Name;
    }
}
