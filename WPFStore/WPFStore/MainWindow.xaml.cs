using System;
using System.Collections.Generic;
using System.IO;
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
        public List<Product> productList = new List<Product>();
        public class Product
        {
            public string Title;
            public string Description;
            public decimal Price;
            public string Image;
        }

        public MainWindow()
        {
            InitializeComponent();
            Start();
        }

        private void Start()
        {
            var filePath =
                @"C:\Users\Kioma\Documents\GitHub\Teknikhögskolan\WPF-Store\WPFStore\WPFStore\Cart.csv";

            var lines = File.ReadAllLines(filePath);
            var product = new Product();
            
            foreach (var line in lines)
            {
                var columnsInLine = line.Split(',');
                productList.Add(new Product { Title = columnsInLine[0],
                Description = columnsInLine[1],
                Price = decimal.Parse(columnsInLine[2]),
                Image = columnsInLine[3]});
                
            }


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
            grid.RowDefinitions.Add(new RowDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            var stackpanel = new StackPanel
            {
                Orientation = Orientation.Vertical
            };
            grid.Children.Add(stackpanel);

            foreach (var productItem in productList)
            {
                var titleLabel = new Label
                {
                    Content = productItem.Title,
                };

                var descriptionLabel = new Label
                {
                    Content = productItem.Description
                };

                var priceLabel = new Label
                {
                    Content = productItem.Price
                };

                var imageLabel = new Label
                {
                    Content = CreateImage(productItem.Image)
                };
                stackpanel.Children.Add(titleLabel);
                stackpanel.Children.Add(descriptionLabel);
                stackpanel.Children.Add(priceLabel);
                stackpanel.Children.Add(imageLabel);
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
