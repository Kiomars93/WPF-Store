using System;
using System.Collections.Generic;
using System.Linq;
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

namespace TestWrap
{
    public partial class MainWindow : Window
    {
        // These variables are used in multiple methods, so we need to declare them as instance variables.
        // We assign values to them inside Start.
        private TextBlock messageLabel;
        private ComboBox comboBox;
        private ListBox listBox;

        public MainWindow()
        {
            InitializeComponent();
            Start();
        }

        private void Start()
        {
            // Window options
            Title = "Kitchen Sink";
            Width = 1000;
            Height = 600;
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
            grid.ColumnDefinitions.Add(new ColumnDefinition());

            // Create the left panel, which shows off many different controls.
            StackPanel controlPanel = CreateControlPanel();
            grid.Children.Add(controlPanel);
            Grid.SetRow(controlPanel, 0);
            Grid.SetColumn(controlPanel, 0);

            // Create the right panel, which shows off several different layout techniques.
            Grid layoutPanel = CreateLayoutPanel();
            grid.Children.Add(layoutPanel);
            Grid.SetRow(layoutPanel, 0);
            Grid.SetColumn(layoutPanel, 1);
        }

        private StackPanel CreateControlPanel()
        {
            StackPanel controlPanel = new StackPanel { Orientation = Orientation.Vertical };

            // Create some descriptive text with different text styles.
            TextBlock heading = new TextBlock
            {
                Text = "A Bunch of GUI Controls",
                TextWrapping = TextWrapping.Wrap,
                Margin = new Thickness(5),
                FontFamily = new FontFamily("Constantia"),
                FontSize = 20,
                TextAlignment = TextAlignment.Center
            };
            controlPanel.Children.Add(heading);

            messageLabel = new TextBlock
            {
                Text = "Messages will appear here when actions on the controls below are performed",
                TextWrapping = TextWrapping.Wrap,
                Margin = new Thickness(5)
            };
            controlPanel.Children.Add(messageLabel);

            // A regular button with an event handler.
            Button button = new Button
            {
                Content = "Click Me",
                Margin = new Thickness(5)
            };
            controlPanel.Children.Add(button);
            button.Click += HandleButtonClick;

            // Put some checkboxes in a wrap panel, which moves them to the next line if there is not enough horizontal space.
            WrapPanel radioPanel = new WrapPanel { Orientation = Orientation.Horizontal };
            controlPanel.Children.Add(radioPanel);

            // Create three checkboxes and assign the same event handler to all of them.
            for (int i = 1; i <= 3; i++)
            {
                CheckBox checkBox = new CheckBox
                {
                    Content = "Checkbox " + i,
                    Margin = new Thickness(5)
                };
                radioPanel.Children.Add(checkBox);
                checkBox.Checked += HandleCheckboxCheck;
                checkBox.Unchecked += HandleCheckboxUncheck;
            }

            // Create a combo box, also known as a "dropdown".
            comboBox = new ComboBox { Margin = new Thickness(5) };
            controlPanel.Children.Add(comboBox);
            comboBox.Items.Add("First Combobox Item");
            comboBox.Items.Add("Second Combobox Item");
            comboBox.Items.Add("Third Combobox Item");
            comboBox.SelectedIndex = 0;
            comboBox.SelectionChanged += HandleComboBoxSelection;

            // Create a list box, which is similar to a combo box but we can see all the options at once.
            listBox = new ListBox { Margin = new Thickness(5) };
            controlPanel.Children.Add(listBox);
            listBox.Items.Add("First Listbox Item");
            listBox.Items.Add("Second Listbox Item");
            listBox.Items.Add("Third Listbox Item");
            listBox.SelectedIndex = 0;
            listBox.SelectionChanged += HandleListBoxSelection;

            // Put four images inside a grid and scale them with different techniques.
            Grid imageGrid = new Grid
            {
                MaxHeight = 300,
                Margin = new Thickness(5)
            };
            controlPanel.Children.Add(imageGrid);
            imageGrid.RowDefinitions.Add(new RowDefinition());
            imageGrid.RowDefinitions.Add(new RowDefinition());
            imageGrid.ColumnDefinitions.Add(new ColumnDefinition());
            imageGrid.ColumnDefinitions.Add(new ColumnDefinition());

            // Let the image have its natural size.
            Image normalImage = CreateImage("Tower1.jpg");
            normalImage.Stretch = Stretch.None;
            imageGrid.Children.Add(normalImage);
            Grid.SetRow(normalImage, 0);
            Grid.SetColumn(normalImage, 0);

            // Let the image fill its space, even if that makes it appear "stretched".
            Image fillImage = CreateImage("Tower1.jpg");
            fillImage.Stretch = Stretch.Fill;
            imageGrid.Children.Add(fillImage);
            Grid.SetRow(fillImage, 0);
            Grid.SetColumn(fillImage, 1);

            // Resize the image as much as we can without overflowing and without changing the aspect ratio.
            Image uniformImage = CreateImage("Tower1.jpg");
            uniformImage.Stretch = Stretch.Uniform;
            imageGrid.Children.Add(uniformImage);
            Grid.SetRow(uniformImage, 1);
            Grid.SetColumn(uniformImage, 0);

            // Resize the image until the entire space is filled, without changing the aspect ratio.
            Image uniformToFillImage = CreateImage("Tower1.jpg");
            uniformToFillImage.Stretch = Stretch.UniformToFill;
            imageGrid.Children.Add(uniformToFillImage);
            Grid.SetRow(uniformToFillImage, 1);
            Grid.SetColumn(uniformToFillImage, 1);

            return controlPanel;
        }
        private Grid CreateLayoutPanel()
        {
            // The main layout is a grid with two columns and four rows.
            // All rows are sized to their content ("auto") except the second row, which takes up all the remaining space.
            Grid grid = new Grid();
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

            // A text heading.
            TextBlock heading = new TextBlock
            {
                Text = "A Sample GUI Layout",
                TextWrapping = TextWrapping.Wrap,
                Margin = new Thickness(5),
                FontFamily = new FontFamily("Constantia"),
                FontSize = 20,
                TextAlignment = TextAlignment.Center
            };
            grid.Children.Add(heading);
            Grid.SetColumn(heading, 0);
            Grid.SetRow(heading, 0);
            Grid.SetColumnSpan(heading, 2);

            // The list box allowing us to select a water tower.
            // Fills the left half of the second row.
            ListBox listBox = new ListBox { Margin = new Thickness(5) };
            listBox.Items.Add("Björkekärr");
            listBox.Items.Add("Guldheden");
            listBox.Items.Add("Biskopsgården");
            listBox.SelectedIndex = 0;
            grid.Children.Add(listBox);
            Grid.SetColumn(listBox, 0);
            Grid.SetRow(listBox, 1);

            // The information panel describing a specific water tower.
            // Fills the right half of the second row.
            StackPanel infoPanel = new StackPanel
            {
                Orientation = Orientation.Vertical,
                Margin = new Thickness(5)
            };
            grid.Children.Add(infoPanel);
            Grid.SetColumn(infoPanel, 1);
            Grid.SetRow(infoPanel, 1);

            // The text heading inside the information panel.
            TextBlock infoHeading = new TextBlock
            {
                Text = "Björkekärr",
                TextWrapping = TextWrapping.Wrap,
                Margin = new Thickness(5),
                FontFamily = new FontFamily("Constantia"),
                FontSize = 16,
                TextAlignment = TextAlignment.Center
            };
            infoPanel.Children.Add(infoHeading);

            // The image inside the information panel.
            Image infoImage = CreateImage("Tower2.jpg");
            infoImage.Stretch = Stretch.Uniform;
            infoPanel.Children.Add(infoImage);

            // The descriptive text inside the information panel.
            TextBlock infoText = new TextBlock
            {
                Text = "Björkekärrs vattentorn är en svampliknande byggnad i grå betong, ritat av arkitekt Jan Wallinder. Tornet stod färdigt 1969. Foto: Frank Palm.",
                TextWrapping = TextWrapping.Wrap,
                Margin = new Thickness(5),
                FontFamily = new FontFamily("Constantia"),
                FontSize = 12
            };
            infoPanel.Children.Add(infoText);

            // A button that stretches across both columns.
            Button bigButton = new Button
            {
                Content = "Big Button",
                Margin = new Thickness(5),
                Padding = new Thickness(5),
                FontSize = 16
            };
            grid.Children.Add(bigButton);
            Grid.SetColumn(bigButton, 0);
            Grid.SetRow(bigButton, 2);
            Grid.SetColumnSpan(bigButton, 2);

            // Thre buttons that are horizontally centered in the last row.
            StackPanel buttonPanel = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                HorizontalAlignment = HorizontalAlignment.Center
            };
            grid.Children.Add(buttonPanel);
            Grid.SetColumn(buttonPanel, 0);
            Grid.SetRow(buttonPanel, 3);
            Grid.SetColumnSpan(buttonPanel, 2);

            for (int i = 0; i < 3; i++)
            {
                Button button = new Button
                {
                    Content = "Small Button " + (i + 1),
                    Margin = new Thickness(5),
                    Padding = new Thickness(5)
                };
                buttonPanel.Children.Add(button);
            }

            return grid;
        }

        private void HandleButtonClick(object sender, RoutedEventArgs e)
        {
            messageLabel.Text = "You pressed the button";
        }

        private void HandleCheckboxCheck(object sender, RoutedEventArgs e)
        {
            // Figure out which specific checkbox was clicked.
            CheckBox checkBox = (CheckBox)sender;
            messageLabel.Text = "You checked " + checkBox.Content;
        }

        private void HandleCheckboxUncheck(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            messageLabel.Text = "You unchecked " + checkBox.Content;
        }

        private void HandleComboBoxSelection(object sender, SelectionChangedEventArgs e)
        {
            messageLabel.Text =
                "You selected " + comboBox.SelectedItem +
                " with index " + comboBox.SelectedIndex;
        }

        private void HandleListBoxSelection(object sender, SelectionChangedEventArgs e)
        {
            messageLabel.Text =
                "You selected " + listBox.SelectedItem +
                " with index " + listBox.SelectedIndex;
        }

        private Image CreateImage(string filePath)
        {
            ImageSource source = new BitmapImage(new Uri(filePath, UriKind.Relative));
            Image image = new Image
            {
                Source = source,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(5)
            };
            // A small rendering tweak to ensure maximum visual appeal.
            RenderOptions.SetBitmapScalingMode(image, BitmapScalingMode.HighQuality);
            return image;
        }
    }
}