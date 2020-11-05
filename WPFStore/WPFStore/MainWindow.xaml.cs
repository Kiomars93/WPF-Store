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
    public class Product
    {
        public string Title;
        public string Description;
        public decimal Price;
        public string Image;
        public int Count = 1;
    }
    public partial class MainWindow : Window
    {
        public List<Product> productList = new List<Product>();
        public Product displayProducts = new Product();
        Dictionary<string, decimal> adjustmentDictionary = new Dictionary<string, decimal>();
        ListBox productListBox;
        Label labelTextBox;
        ListBox resultListBox;
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
        //decimal bmwCount = 1;
        //decimal harleyCount = 1;
        //decimal vintageCount = 1;
        //decimal woodyCount = 1;
        decimal sum = 0;


        public MainWindow()
        {
            InitializeComponent();
            Start();
        }

        private void Start()
        {
            ReadCSVDisplayFile();

            // Window options
            Title = "Motorcycle Store";
            Width = 800;
            Height = 1050;
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

            displayProducts = productList[0];
            firstTitleLabel = new Label
            {
                Content = displayProducts.Title,
            };

            firstDescriptionLabel = new Label
            {
                Content = displayProducts.Description
            };

            firstPriceLabel = new Label
            {
                Content = displayProducts.Price
            };

            firstImageLabel = new Label
            {
                Content = CreateImage(displayProducts.Image)
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

            displayProducts = productList[1];

            secondTitleLabel = new Label
            {
                Content = displayProducts.Title,
            };

            secondDescriptionLabel = new Label
            {
                Content = displayProducts.Description
            };

            secondPriceLabel = new Label
            {
                Content = displayProducts.Price
            };

            secondImageLabel = new Label
            {
                Content = CreateImage(displayProducts.Image)
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

            displayProducts = productList[2];

            thirdTitleLabel = new Label
            {
                Content = displayProducts.Title,
            };

            thirdDescriptionLabel = new Label
            {
                Content = displayProducts.Description
            };

            thirdPriceLabel = new Label
            {
                Content = displayProducts.Price
            };

            thirdImageLabel = new Label
            {
                Content = CreateImage(displayProducts.Image)
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


            displayProducts = productList[3];

            fourthTitleLabel = new Label
            {
                Content = displayProducts.Title,
            };

            fourthDescriptionLabel = new Label
            {
                Content = displayProducts.Description
            };

            fourthPriceLabel = new Label
            {
                Content = displayProducts.Price
            };

            fourthImageLabel = new Label
            {
                Content = CreateImage(displayProducts.Image)
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

            // Every row above is just for showing my products.

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
            foreach (var productItem in productList)
            {
                productListBox.Items.Add(productItem.Title);
            }
            Grid.SetRow(productPanel, 1);
            productPanel.Children.Add(productListBox);


            var textLabel = new Label
            {
                Content = "Chosen items:"
            };
            productPanel.Children.Add(textLabel);

            resultListBox = new ListBox
            {
                Padding = new Thickness(5, 5, 5, 50)
            };
            productPanel.Children.Add(resultListBox);



            labelTextBox = new Label();
            productPanel.Children.Add(labelTextBox);

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
            removeButton.Click += RemoveHandle;
            clearButton.Click += ClearHandle;

        }
        private void AddHandle(object sender, RoutedEventArgs e)
        {
            // lägg 2 listor
            // ena e för productList
            // andra list är resultListBox.
            // productlistan ska adderas med objektet och inte enbart titeln. Matcha det med titeln.
            // bikeindex från productListBox som d e.
            // productListBox[bikeIndex]
            // Få ut titeln på den indexet (får sparas i nån varibel)
            // kolla i resultListBox. Loopa igenom om det finns nåt som matchar min titeln så jag har sparat undan.
            // om den matchar loopen som ska man uppdatera titeln på nåt sätt och om loopen ej matchar så ska det stacka på.
            // refresh funktion kmr nog funka om det uppdaterar själva Items i  resultListBox

            //foreach (var productItem in productList)
            //{
            //    adjustmentList.Add(productItem);
            //}
            var a = adjustmentDictionary.ContainsKey("BMWCycle");
            if (adjustmentDictionary.ContainsKey("BMWCycle"))
            {
                adjustmentDictionary["BMWCycle"] += 1;
            }
            else
            {
                adjustmentDictionary["BMWCycle"] = 1; 
            }


            UpdateBox();

            
            //var bikeIndex = productListBox.SelectedIndex;

            //adjustmentDictionary.Add(productList[bikeIndex]);


            //foreach (var productItem in adjustmentDictionary)
            //{
            //    sum += productItem.Price;
            //    resultListBox.Items.Insert(anotherIndex, $"{productItem.Title} {productList[bikeIndex].Count} x {productItem.Price}");
            //    //resultListBox.Items.Add($"{productItem.Title} {productList[bikeIndex].Count} x {productItem.Price}");
            //    productList[bikeIndex].Count++;
            //    anotherIndex++;
            //}

            // Det gör så att jag får in en produkt i taget. Annars blir det fler producter per add click
            //adjustmentDictionary.Remove(productList[bikeIndex]);

            //foreach (var displayItem in adjustmentDictionary)
            //{
            //    labelTextBox.Content = $"Total amount: {sum}";
            //}
        }


        private void UpdateBox()
        {
            resultListBox.Items.Clear();

            foreach (var pair in adjustmentDictionary)
            {
                string bikeTitle = pair.Key;
                decimal bikeAmount = pair.Value;
                resultListBox.Items.Add($"{bikeTitle} x {bikeAmount}");
            }
        }

        private void RemoveHandle(object sender, RoutedEventArgs e)
        {

            //var bikeIndex = resultListBox.SelectedIndex;

            //foreach (var productItem in adjustmentDictionary)
            //{
            //    //sum -= productItem.Price;
            //    resultListBox.Items.RemoveAt(bikeIndex);

            //}

            //labelTextBox.Content = $"Total amount: {sum}";
        }
        private void ClearHandle(object sender, RoutedEventArgs e)
        {
            // Kör en try n catch senare där du kan
            // ta emot felet isf bikeIndex är null


            ////För att visa priset av totalsumman i varukorgen!
            //totalSum += listProducts[selectedIndex].Price;
            //totalSumInChart.Text = Math.Round(totalSum, 0).ToString("C");
            //addedItemList = new List<Product>();

            //var bikeIndex = productListBox.SelectedIndex;
            //adjustmentDictionary.Add(0,productList[bikeIndex]);

            //// Create a new textbox for you sumExpenses

            //foreach (var productItem in adjustmentDictionary)
            //{
            //    resultListBox.Items.Clear();
            //}

            //sum = 0;
            //labelTextBox.Content = $"Total amount: {sum}";
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

        public void ReadCSVDisplayFile()
        {
            var filePath =
                "CurrentProduct.csv";

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
