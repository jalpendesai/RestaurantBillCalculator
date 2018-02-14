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

namespace _300979057_desai__ASS2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

   

    public partial class MainWindow : Window
    {
        List<BillDetails> Beverage = new List<BillDetails>();
        List<BillDetails> Appetizer = new List<BillDetails>();
        List<BillDetails> MainCourse = new List<BillDetails>();
        List<BillDetails> Dessert = new List<BillDetails>();
        public MainWindow()
        {
            InitializeComponent();
            Beverage.Add(new BillDetails {Name = "Soda", Category = "Beverage", Price = 1.95 });
            Beverage.Add(new BillDetails { Name = "Tea", Category = "Beverage", Price = 1.50 });
            Beverage.Add(new BillDetails { Name = "Coffee", Category = "Beverage", Price = 1.25 });
            Beverage.Add(new BillDetails { Name = "Mineral Water", Category = "Beverage", Price = 2.95 });
            Beverage.Add(new BillDetails { Name = "Juice", Category = "Beverage", Price = 2.50 });
            Beverage.Add(new BillDetails { Name = "Milk", Category = "Beverage", Price = 1.50 });

            Appetizer.Add(new BillDetails { Name = "Buffalo Wings", Category = "Appetizer", Price = 5.95 });
            Appetizer.Add(new BillDetails { Name = "Buffalo Fingers", Category = "Appetizer", Price = 6.95 });
            Appetizer.Add(new BillDetails { Name = "Potato Skins", Category = "Appetizer", Price = 8.95 });
            Appetizer.Add(new BillDetails { Name = "Nachos", Category = "Appetizer", Price = 8.95 });
            Appetizer.Add(new BillDetails { Name = "Mushroom Caps", Category = "Appetizer", Price = 10.95 });
            Appetizer.Add(new BillDetails { Name = "Shrimp Cocktail", Category = "Appetizer", Price = 12.95 });
            Appetizer.Add(new BillDetails { Name = "Chips and Salsa", Category = "Appetizer", Price = 6.95 });

            MainCourse.Add(new BillDetails { Name = "Seafood Alfredo", Category = "Main Course", Price = 15.95 });
            MainCourse.Add(new BillDetails { Name = "Chicken Alfredo", Category = "Main Course", Price = 13.95 });
            MainCourse.Add(new BillDetails { Name = "Chicken Picatta", Category = "Main Course", Price = 15.95 });
            MainCourse.Add(new BillDetails { Name = "Turkey Club", Category = "Main Course", Price = 11.95 });
            MainCourse.Add(new BillDetails { Name = "Lobster Pie", Category = "Main Course", Price = 19.95 });
            MainCourse.Add(new BillDetails { Name = "Prime Rib", Category = "Main Course", Price = 20.95 });
            MainCourse.Add(new BillDetails { Name = "Shrimp Scampi", Category = "Main Course", Price = 18.95 });
            MainCourse.Add(new BillDetails { Name = "Turkey Dinner", Category = "Main Course", Price = 13.95 });
            MainCourse.Add(new BillDetails { Name = "Struffed Chicken", Category = "Main Course", Price = 14.95 });

            Dessert.Add(new BillDetails { Name = "Apple Pie", Category = "Dessert", Price = 5.95});
            Dessert.Add(new BillDetails { Name = "Sundae", Category = "Dessert", Price = 3.95 });
            Dessert.Add(new BillDetails { Name = "Carrot Cake", Category = "Dessert", Price = 5.95 });
            Dessert.Add(new BillDetails { Name = "Mud Pie", Category = "Dessert", Price = 4.95 });
            Dessert.Add(new BillDetails { Name = "Apple Crisp", Category = "Dessert", Price = 5.95 });

            //dgCustomer.Visibility = Visibility.Hidden;
            //dgCustomer.ItemsSource = Beverage;

            // Overwritting DataGrid value to Appetizer
            //dgCustomer.ItemsSource = Appetizer

            cbBeverage.DisplayMemberPath = "Name";
            cbBeverage.SelectedValuePath = "Price";
            cbBeverage.SetBinding(ComboBox.ItemsSourceProperty, new Binding() { Source = Beverage });

            cbAppetizer.DisplayMemberPath = "Name";
            cbAppetizer.SelectedValuePath = "Price";
            cbAppetizer.SetBinding(ComboBox.ItemsSourceProperty, new Binding() { Source = Appetizer});

            cbMainCourse.DisplayMemberPath = "Name";
            cbMainCourse.SelectedValuePath = "Price";
            cbMainCourse.SetBinding(ComboBox.ItemsSourceProperty, new Binding() { Source = MainCourse  });

            cbDessert.DisplayMemberPath = "Name";
            cbDessert.SelectedValuePath = "Price";
            cbDessert.SetBinding(ComboBox.ItemsSourceProperty, new Binding() { Source = Dessert });

        }

        private void cbBeverage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           string text = (sender as ComboBox).SelectedValue.ToString();
            lblTest.Content = text;
        }

        private void cbAppetizer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string text = (sender as ComboBox).SelectedValue.ToString();
            lblTest.Content = text;
        }

        private void cbMainCourse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string text = (sender as ComboBox).SelectedValue.ToString();
            lblTest.Content = text;
        }

        private void cbDessert_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string text = (sender as ComboBox).SelectedValue.ToString();
            lblTest.Content = text;
        }
    }
}
