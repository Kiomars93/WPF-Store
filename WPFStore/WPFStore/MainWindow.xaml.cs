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
            ReadCSVFile();

            // Window options
            Title = "Motorcycle Store";
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
            grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            Grid currentProductGrid = new Grid();
            grid.Children.Add(currentProductGrid);
            currentProductGrid.RowDefinitions.Add(new RowDefinition());
            currentProductGrid.RowDefinitions.Add(new RowDefinition());
            currentProductGrid.RowDefinitions.Add(new RowDefinition());
            currentProductGrid.RowDefinitions.Add(new RowDefinition());
            currentProductGrid.RowDefinitions.Add(new RowDefinition());
            currentProductGrid.RowDefinitions.Add(new RowDefinition());
            currentProductGrid.RowDefinitions.Add(new RowDefinition());
            currentProductGrid.RowDefinitions.Add(new RowDefinition());
            currentProductGrid.RowDefinitions.Add(new RowDefinition());
            currentProductGrid.RowDefinitions.Add(new RowDefinition());
            currentProductGrid.RowDefinitions.Add(new RowDefinition());
            currentProductGrid.RowDefinitions.Add(new RowDefinition());
            currentProductGrid.RowDefinitions.Add(new RowDefinition());
            currentProductGrid.RowDefinitions.Add(new RowDefinition());
            currentProductGrid.RowDefinitions.Add(new RowDefinition());
            currentProductGrid.RowDefinitions.Add(new RowDefinition());
            currentProductGrid.RowDefinitions.Add(new RowDefinition());
            currentProductGrid.ColumnDefinitions.Add(new ColumnDefinition());
            currentProductGrid.ColumnDefinitions.Add(new ColumnDefinition());



            var currentProductLabel = new Label
            {
                Content = "Welcome to my shop. This is our current products:",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                FontSize = 14,
                Margin = new Thickness(5)
            };
            currentProductGrid.Children.Add(currentProductLabel);
            Grid.SetRow(currentProductLabel, 0);
            Grid.SetColumnSpan(currentProductLabel, 2);

            var firstProduct = productList[0];
            var firstTitleLabel = new Label
            {
                Content = firstProduct.Title,
            };

            var firstDescriptionLabel = new Label
            {
                Content = firstProduct.Description
            };

            var firstPriceLabel = new Label
            {
                Content = firstProduct.Price
            };

            var firstImageLabel = new Label
            {
                Content = CreateImage(firstProduct.Image)
            };
            currentProductGrid.Children.Add(firstTitleLabel);
            currentProductGrid.Children.Add(firstDescriptionLabel);
            currentProductGrid.Children.Add(firstPriceLabel);
            currentProductGrid.Children.Add(firstImageLabel);
            Grid.SetRow(firstTitleLabel, 1);
            Grid.SetColumn(firstTitleLabel, 0);
            Grid.SetRow(firstDescriptionLabel, 2);
            Grid.SetColumn(firstDescriptionLabel, 0);
            Grid.SetRow(firstPriceLabel, 3);
            Grid.SetColumn(firstPriceLabel, 0);
            Grid.SetRow(firstImageLabel, 4);
            Grid.SetColumn(firstImageLabel, 0);
            
            var secondProduct = productList[1];

            var secondTitleLabel = new Label
            {
                Content = secondProduct.Title,
            };

            var secondDescriptionLabel = new Label
            {
                Content = secondProduct.Description
            };

            var secondPriceLabel = new Label
            {
                Content = secondProduct.Price
            };

            var secondImageLabel = new Label
            {
                Content = CreateImage(secondProduct.Image)
            };
            currentProductGrid.Children.Add(secondTitleLabel);
            currentProductGrid.Children.Add(secondDescriptionLabel);
            currentProductGrid.Children.Add(secondPriceLabel);
            currentProductGrid.Children.Add(secondImageLabel);
            Grid.SetRow(secondTitleLabel, 1);
            Grid.SetRow(secondDescriptionLabel, 2);
            Grid.SetRow(secondPriceLabel, 3);
            Grid.SetRow(secondImageLabel, 4);
            Grid.SetColumn(secondTitleLabel, 1);
            Grid.SetColumn(secondDescriptionLabel, 1);
            Grid.SetColumn(secondPriceLabel, 1);
            Grid.SetColumn(secondImageLabel, 1);

            var thirdProduct = productList[2];

            var thirdTitleLabel = new Label
            {
                Content = thirdProduct.Title,
            };

            var thirdDescriptionLabel = new Label
            {
                Content = thirdProduct.Description
            };

            var thirdPriceLabel = new Label
            {
                Content = thirdProduct.Price
            };

            var thirdImageLabel = new Label
            {
                Content = CreateImage(thirdProduct.Image)
            };
            currentProductGrid.Children.Add(thirdTitleLabel);
            currentProductGrid.Children.Add(thirdDescriptionLabel);
            currentProductGrid.Children.Add(thirdPriceLabel);
            currentProductGrid.Children.Add(thirdImageLabel);
            Grid.SetRow(thirdTitleLabel, 5);
            Grid.SetRow(thirdDescriptionLabel, 6);
            Grid.SetRow(thirdPriceLabel, 7);
            Grid.SetRow(thirdImageLabel, 8);
            Grid.SetColumn(thirdTitleLabel, 0);
            Grid.SetColumn(thirdDescriptionLabel, 0);
            Grid.SetColumn(thirdPriceLabel, 0);
            Grid.SetColumn(thirdImageLabel, 0);


            var foruthProduct = productList[3];

            var fourthTitleLabel = new Label
            {
                Content = foruthProduct.Title,
            };

            var fourthDescriptionLabel = new Label
            {
                Content = foruthProduct.Description
            };

            var fourthPriceLabel = new Label
            {
                Content = foruthProduct.Price
            };

            var fourthImageLabel = new Label
            {
                Content = CreateImage(foruthProduct.Image)
            };
            currentProductGrid.Children.Add(fourthTitleLabel);
            currentProductGrid.Children.Add(fourthDescriptionLabel);
            currentProductGrid.Children.Add(fourthPriceLabel);
            currentProductGrid.Children.Add(fourthImageLabel);
            Grid.SetRow(fourthTitleLabel, 5);
            Grid.SetRow(fourthDescriptionLabel, 6);
            Grid.SetRow(fourthPriceLabel, 7);
            Grid.SetRow(fourthImageLabel, 8);
            Grid.SetColumn(fourthTitleLabel, 1);
            Grid.SetColumn(fourthDescriptionLabel, 1);
            Grid.SetColumn(fourthPriceLabel, 1);
            Grid.SetColumn(fourthImageLabel, 1);




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

        public void ReadCSVFile()
        {
            var filePath =
                @"C:\Users\Kioma\Documents\GitHub\Teknikhögskolan\WPF-Store\WPFStore\WPFStore\CurrentProduct.csv";

            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                var columnsInLine = line.Split(',');
                productList.Add(new Product
                {
                    Title = columnsInLine[0],
                    Description = columnsInLine[1],
                    Price = decimal.Parse(columnsInLine[2]),
                    Image = columnsInLine[3]
                });

            }
        }
    }
}
