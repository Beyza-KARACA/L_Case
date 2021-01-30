using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using _02_BitmapPlayground_Filters.Filters;
using _02_BitmapPlayground_Filters;
using System.Threading;

namespace _02_BitmapPlayground
{

    public partial class Form1 : Form
    {
      
        public Form1()
        {
            InitializeComponent();

            PopulateFilterPicker();

        }
       
        private void PopulateFilterPicker()
        {
            var type = typeof(IFilter);
            List<String> types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(s => s.GetTypes()).Where(p => type.IsAssignableFrom(p)).Select(x => x.Name).ToList();

            foreach (var item in types)
            {
                if(item!="IFilter")
                    FilterPickerBox.Items.Add(item);
            }
          

        }

        /// <summary>
        /// Applies a filter to an image.
        /// </summary>
        /// <param name="filter">The filter to apply. Must not be null.</param>
        /// <param name="image">The image to which the filter is applied.</param>
        /// <returns>A new image with the filter applied.</returns>
        private Image ApplyFilter(IFilter filter, Image image)
        {
            // Sanity check input
            if (filter == null)
                throw new ArgumentNullException(nameof(filter));

            if (image == null)
                throw new ArgumentNullException(nameof(image));

            // Create a new bitmap from the existing image
            Bitmap result = new Bitmap(image);

            // Copy the pixel colors of the existing bitmap to a new 2D - color array for further processing.
            Color[,] colors = new Color[result.Width, result.Height];
            for (int x = 0; x < result.Width; x++)
                for (int y = 0; y < result.Height; y++)
                    colors[x, y] = result.GetPixel(x, y);

            // Apply the user defined filter.
            var filteredImageData = filter.Apply(colors);

            // Copy the resulting array back to the bitmap
            for (int x = 0; x < result.Width; x++)
                for (int y = 0; y < result.Height; y++)
                    result.SetPixel(x, y, filteredImageData[x, y]);

            return result;
        }

        private void ApplyFilterButton_Click(object sender, EventArgs e)
        {
          
            if (FilterPickerBox.SelectedItem.ToString()== "GreyscaleFilter")
            {
               
               ThreadPool.QueueUserWorkItem(new WaitCallback(Greyscale));

            }

            if (FilterPickerBox.SelectedItem.ToString() == "RedFilter")
            {
                
                ThreadPool.QueueUserWorkItem(new WaitCallback(Red));
                
            }

            if (FilterPickerBox.SelectedItem.ToString() == "MovingAverageFilter")
            {
                
                ThreadPool.QueueUserWorkItem(new WaitCallback(MovingAverage));
                
            }

        }

        private void Red(Object obj)
        {
            PictureBoxFiltered.Image = ApplyFilter(new RedFilter(), PictureBoxOriginal.Image);

        }
        private void Greyscale(Object obj)
        {
            PictureBoxFiltered.Image = ApplyFilter(new GreyscaleFilter(), PictureBoxOriginal.Image);

        }
        private void MovingAverage(Object obj)
        {
            PictureBoxFiltered.Image = ApplyFilter(new MovingAverageFilter(), PictureBoxOriginal.Image);

        }
    }
}
