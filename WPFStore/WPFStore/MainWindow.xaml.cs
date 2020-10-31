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
        public Product mainProduct = new Product();
        ListBox productListBox;
        TextBox resultTextBox;
        Label firstTitleLabel;
        Label secondTitleLabel;
        Label thirdTitleLabel;
        Label fourthTitleLabel;

        Label firstDescriptionLabel;
        Label secondDescriptionLabel;
        Label thirdDescriptionLabel;
        Label fourthDescriptionLabel;

        Label firstPriceLabel;
        Label secondPriceLabel;
        Label thirdPriceLabel;
        Label fourthPriceLabel;

        Label firstImageLabel;
        Label secondImageLabel;
        Label thirdImageLabel;
        Label fourthImageLabel;

        decimal count = 1;
        decimal sum = 0;
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

            mainProduct = productList[0];
            firstTitleLabel = new Label
            {
                Content = mainProduct.Title,
            };

            firstDescriptionLabel = new Label
            {
                Content = mainProduct.Description
            };

            firstPriceLabel = new Label
            {
                Content = mainProduct.Price
            };

            firstImageLabel = new Label
            {
                Content = CreateImage(mainProduct.Image)
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

            mainProduct = productList[1];

            secondTitleLabel = new Label
            {
                Content = mainProduct.Title,
            };

            secondDescriptionLabel = new Label
            {
                Content = mainProduct.Description
            };

            secondPriceLabel = new Label
            {
                Content = mainProduct.Price
            };

            secondImageLabel = new Label
            {
                Content = CreateImage(mainProduct.Image)
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

            mainProduct = productList[2];

            thirdTitleLabel = new Label
            {
                Content = mainProduct.Title,
            };

            thirdDescriptionLabel = new Label
            {
                Content = mainProduct.Description
            };

            thirdPriceLabel = new Label
            {
                Content = mainProduct.Price
            };

            thirdImageLabel = new Label
            {
                Content = CreateImage(mainProduct.Image)
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


            mainProduct = productList[3];

            fourthTitleLabel = new Label
            {
                Content = mainProduct.Title,
            };

            fourthDescriptionLabel = new Label
            {
                Content = mainProduct.Description
            };

            fourthPriceLabel = new Label
            {
                Content = mainProduct.Price
            };

            fourthImageLabel = new Label
            {
                Content = CreateImage(mainProduct.Image)
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

            var productPanel = new StackPanel
            {
                Orientation = Orientation.Vertical
            };
            grid.Children.Add(productPanel);

            var chooseMenu = new Label
            {
                Content = "Select your item",
                HorizontalAlignment = HorizontalAlignment.Center
            };
            productPanel.Children.Add(chooseMenu);
            productListBox = new ListBox();
            mainProduct = productList[0];
            productListBox.Items.Add(mainProduct.Title);
            mainProduct = productList[1];
            productListBox.Items.Add(mainProduct.Title);
            mainProduct = productList[2];
            productListBox.Items.Add(mainProduct.Title);
            mainProduct = productList[3];
            productListBox.Items.Add(mainProduct.Title);
            Grid.SetRow(productPanel, 1);
            productPanel.Children.Add(productListBox);

            var textLabel = new Label
            {
                Content = "Chosen items:"
            };
            productPanel.Children.Add(textLabel);

            resultTextBox = new TextBox
            {
                IsReadOnly = true,
            };
            productPanel.Children.Add(resultTextBox);

            
            var addButton = new Button
            {
                Content = "Add Item"
            };
            productPanel.Children.Add(addButton);


            var removeButton = new Button
            {
                Content = "Remove an Item"
            };
            productPanel.Children.Add(removeButton);

            var clearButton = new Button
            {
                Content = "Clear"
            };
            productPanel.Children.Add(clearButton);

            addButton.Click += AddHandle;

        }

        private void AddHandle(object sender, RoutedEventArgs e)
        {
            if (productListBox.SelectedIndex == 0)
            {
                mainProduct = productList[0];
                resultTextBox.Clear();
                resultTextBox.Text += $"You chose {count} {mainProduct.Title}";
                count++;
            }
            else if (productListBox.SelectedIndex == 1)
            {
                mainProduct = productList[1];
                resultTextBox.Clear();
                resultTextBox.Text += $"You chose {count} {mainProduct.Title}";
                count++;
            }
            else if (productListBox.SelectedIndex == 2)
            {
                resultTextBox.Text += $"{Environment.NewLine} You chose a {thirdTitleLabel.Content}";
                count++;
            }
            else if (productListBox.SelectedIndex == 3)
            {
                resultTextBox.Text += $"{Environment.NewLine} You chose a {fourthTitleLabel.Content}";
                count++;
            }

            sum += mainProduct.Price;
            resultTextBox.Text += $" Total amount: {sum}";

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
