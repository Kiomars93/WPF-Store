using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFStore
{
    public partial class MainWindow : Window
    {
        private List<Product> productList = new List<Product>
        {
            new Product { Titel = "BeadsNecklace", Description = "Original Beads straight from Thailand", Price = 320,
                Picture = new BitmapImage(new Uri(@"Images\BeadsNecklace.jpg", UriKind.Relative)) },
            new Product { Titel = "Diamond", Description = "Top notch Diamond from Bangladesh", Price = 5700,
                Picture = new BitmapImage(new Uri(@"Images\Diamond.jpg", UriKind.Relative)) }
        };
        public class Product
        {
            public string Titel;
            public string Description;
            public decimal Price;
            public BitmapImage Picture;
        }

        public MainWindow()
        {
            InitializeComponent();
            Start();
        }

        private void Start()
        {
            // Window options
            Title = "Jewelery Store";
            Width = 400;
            Height = 300;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            // Scrolling
            ScrollViewer root = new ScrollViewer();
            root.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
            Content = root;

            // Main grid
            Grid grid = new Grid();
            root.Content = grid;
            grid.Margin = new Thickness(5);

            StackPanel imageGrid = new StackPanel
            {
                Orientation = Orientation.Vertical,
                MaxHeight = 300,
                Margin = new Thickness(5)
            };

            grid.Children.Add(imageGrid);

            Image normalImage = CreateImage(@"Images\BeadsNecklace.jpg");
            normalImage.Stretch = Stretch.None;
            imageGrid.Children.Add(normalImage);
            Grid.SetRow(imageGrid, 0);
            Grid.SetColumn(imageGrid, 0);

            foreach (Product product in productList)
            {
                var labelTitel = new Label { Content = product.Titel };
                var labelPrice = new Label { Content = product.Price };
                imageGrid.Children.Add(labelTitel);
                imageGrid.Children.Add(labelPrice);
            }

        }

        private Image CreateImage(string filePath)
        {
            ImageSource scource = new BitmapImage(new Uri(filePath, UriKind.Relative));
            Image image = new Image
            {
                Source = scource,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(5)
            };

            RenderOptions.SetBitmapScalingMode(image, BitmapScalingMode.HighQuality);
            return image;
        }

    }
}
