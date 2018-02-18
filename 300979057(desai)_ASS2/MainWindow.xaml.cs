using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;

namespace _300979057_desai__ASS2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

   

    public partial class MainWindow : Excel.Window
    {
        List<BillDetails> Beverage = new List<BillDetails>();
        List<BillDetails> Appetizer = new List<BillDetails>();
        List<BillDetails> MainCourse = new List<BillDetails>();
        List<BillDetails> Dessert = new List<BillDetails>();

        private double subTotal = 0.0, tax = 0.0, total = 0.0;
  
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
            Calculate(text);
            //lblTest.Content = text;
            

            cmbSelectedChanged(this.cbBeverage);

            //Adding to DataGrid
            BillDetails selectedBillDetails = (BillDetails)cbBeverage.SelectedItem;
            dgCustomer.Items.Add(selectedBillDetails);
            selectedBillDetails.Quantity = 0;

            //Increment Quantity
            foreach (var item in dgCustomer.Items)
            {
                if(item == selectedBillDetails)
                {
                    selectedBillDetails.Quantity++;
                }
            }
            
        }

        private void cbAppetizer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string text = (sender as ComboBox).SelectedValue.ToString();
            Calculate(text);

            //Adding to DataGrid
            BillDetails selectedBillDetails = (BillDetails)cbAppetizer.SelectedItem;
            dgCustomer.Items.Add(selectedBillDetails);
            selectedBillDetails.Quantity = 0;

            //Increment Quantity
            foreach (var item in dgCustomer.Items)
            {
                if (item == selectedBillDetails)
                {
                    selectedBillDetails.Quantity++;
                }
            }
        }


        private void cbMainCourse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string text = (sender as ComboBox).SelectedValue.ToString();
            Calculate(text);
            //Adding to DataGrid
            BillDetails selectedBillDetails = (BillDetails)cbMainCourse.SelectedItem;
            dgCustomer.Items.Add(selectedBillDetails);
            selectedBillDetails.Quantity = 0;

            //Increment Quantity
            foreach (var item in dgCustomer.Items)
            {
                if (item == selectedBillDetails)
                {
                    selectedBillDetails.Quantity++;
                }
            }
        }

        private void cbDessert_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string text = (sender as ComboBox).SelectedValue.ToString();
            Calculate(text);

            //Adding to DataGrid
            BillDetails selectedBillDetails = (BillDetails)cbDessert.SelectedItem;
            dgCustomer.Items.Add(selectedBillDetails);
            selectedBillDetails.Quantity = 0;

            foreach (var item in dgCustomer.Items)
            {
                if (item == selectedBillDetails)
                {
                    selectedBillDetails.Quantity++;
                }
            }
            //foreach (var item in dgCustomer.Items)
            //{
            //   // !dgCustomer.Items.Contains(selectedBillDetails)
            //    if (item != selectedBillDetails)
            //    {
            //        dgCustomer.Items.Add(selectedBillDetails);
            //        selectedBillDetails.Quantity = 1;
            //    }
            //    else
            //    {
            //        selectedBillDetails.Quantity++;
            //    }
            //}
            //Increment Quantity
            //foreach (var item in dgCustomer.Items)
            //{

            //}

            //cbDessert.SelectedIndex = -1;
            //cbDessert.Items.Clear();
            //cbDessert.Text = "";

        }

        

        //Calculator
        private void Calculate(string itemValue)
        {
            if(itemValue == null)
            {
                return;
            }
            subTotal += Convert.ToDouble(itemValue);
            //lblTest.Content = subTotal;
            //Rounding to Two decimals
            lblTest.Content = String.Format("${0:0.00}", subTotal);

            tax += Convert.ToDouble(itemValue) * .15;
            //lblTax.Content = tax;
            //Rounding to Two decimals
            lblTax.Content = String.Format("${0:0.00}", tax);

            total = subTotal + tax;
            //lblFTotal.Content = total;
            //Rounding to Two decimals
            lblFTotal.Content = String.Format("${0:0.00}", total);

        }

        private void lbllogo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.centennialcollege.ca/");
        }

        private void dgCustomer_SlectedIndex()
        {

        }

        private void export_Click(object sender, RoutedEventArgs e)
        {
            Excel.Application excel = new Excel.Application();
            excel.Visible = true; //www.ahmetcansever.com
            Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
            Worksheet sheet1 = (Worksheet)workbook.Sheets[1];

            for (int j = 0; j < dgCustomer.Columns.Count; j++) //Başlıklar için
            {
                Range myRange = (Range)sheet1.Cells[1, j + 1];
                sheet1.Cells[1, j + 1].Font.Bold = true; //Başlığın Kalın olması için
                sheet1.Columns[j + 1].ColumnWidth = 15; //Sütun genişliği ayarı
                myRange.Value2 = dgCustomer.Columns[j].Header;
            }
            for (int i = 0; i < dgCustomer.Columns.Count; i++)
            { //www.ahmetcansever.com
                for (int j = 0; j < dgCustomer.Items.Count; j++)
                {
                    TextBlock b = dgCustomer.Columns[i].GetCellContent(dgCustomer.Items[j]) as TextBlock;
                    Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[j + 2, i + 1];
                    myRange.Value2 = b.Text;
                }
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            lblTest.Content = "$0.00";
            lblTax.Content = "$0.00";
            lblFTotal.Content = "$0.00";
            //Reset datagrid value
            //dgCustomer.ItemsSource = null;

            //dgCustomer.Columns.Clear();
            dgCustomer.Items.Clear();
            dgCustomer.Items.Refresh();

            cbDessert.IsDropDownOpen = true;
            cbDessert.IsDropDownOpen = false;
            cbDessert.Items.Refresh();


        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if(dgCustomer.SelectedItem != null)
            {
                dgCustomer.SelectedItems.Remove(dgCustomer.SelectedItem);
            }
        }

        private void cmbSelectedChanged(ComboBox cmb)
        {
            //if(cmb.SelectedIndex != 1)
            //{
            //    Collection.Add(cmb.SelectedItem);
            //}
        }

        dynamic Excel.Window.Activate()
        {
            throw new NotImplementedException();
        }

        public dynamic ActivateNext()
        {
            throw new NotImplementedException();
        }

        public dynamic ActivatePrevious()
        {
            throw new NotImplementedException();
        }

        public bool Close(object SaveChanges, object Filename, object RouteWorkbook)
        {
            throw new NotImplementedException();
        }

        public dynamic LargeScroll(object Down, object Up, object ToRight, object ToLeft)
        {
            throw new NotImplementedException();
        }

        public Excel.Window NewWindow()
        {
            throw new NotImplementedException();
        }

        public dynamic _PrintOut(object From, object To, object Copies, object Preview, object ActivePrinter, object PrintToFile, object Collate, object PrToFileName)
        {
            throw new NotImplementedException();
        }

        public dynamic PrintPreview(object EnableChanges)
        {
            throw new NotImplementedException();
        }

        public dynamic ScrollWorkbookTabs(object Sheets, object Position)
        {
            throw new NotImplementedException();
        }

        public dynamic SmallScroll(object Down, object Up, object ToRight, object ToLeft)
        {
            throw new NotImplementedException();
        }

        public int PointsToScreenPixelsX(int Points)
        {
            throw new NotImplementedException();
        }

        public int PointsToScreenPixelsY(int Points)
        {
            throw new NotImplementedException();
        }

        public dynamic RangeFromPoint(int x, int y)
        {
            throw new NotImplementedException();
        }

        public void ScrollIntoView(int Left, int Top, int Width, int Height, object Start)
        {
            throw new NotImplementedException();
        }

        public dynamic PrintOut(object From, object To, object Copies, object Preview, object ActivePrinter, object PrintToFile, object Collate, object PrToFileName)
        {
            throw new NotImplementedException();
        }

        public Excel.Application Application => throw new NotImplementedException();

        public XlCreator Creator => throw new NotImplementedException();

        dynamic Excel.Window.Parent => throw new NotImplementedException();

        public Range ActiveCell => throw new NotImplementedException();

        public Chart ActiveChart => throw new NotImplementedException();

        public Pane ActivePane => throw new NotImplementedException();

        public dynamic ActiveSheet => throw new NotImplementedException();

        public dynamic Caption { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool DisplayFormulas { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool DisplayGridlines { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool DisplayHeadings { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool DisplayHorizontalScrollBar { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool DisplayOutline { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool _DisplayRightToLeft { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool DisplayVerticalScrollBar { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool DisplayWorkbookTabs { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool DisplayZeros { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool EnableResize { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool FreezePanes { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int GridlineColor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public XlColorIndex GridlineColorIndex { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Index => throw new NotImplementedException();

        public string OnWindow { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Panes Panes => throw new NotImplementedException();

        public Range RangeSelection => throw new NotImplementedException();

        public int ScrollColumn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int ScrollRow { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Sheets SelectedSheets => throw new NotImplementedException();

        public dynamic Selection => throw new NotImplementedException();

        public bool Split { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int SplitColumn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double SplitHorizontal { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int SplitRow { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double SplitVertical { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double TabRatio { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public XlWindowType Type => throw new NotImplementedException();

        public double UsableHeight => throw new NotImplementedException();

        public double UsableWidth => throw new NotImplementedException();

        public bool Visible { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Range VisibleRange => throw new NotImplementedException();

        public int WindowNumber => throw new NotImplementedException();

        XlWindowState Excel.Window.WindowState { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public dynamic Zoom { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public XlWindowView View { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool DisplayRightToLeft { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public SheetViews SheetViews => throw new NotImplementedException();

        public dynamic ActiveSheetView => throw new NotImplementedException();

        public bool DisplayRuler { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool AutoFilterDateGrouping { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool DisplayWhitespace { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Hwnd => throw new NotImplementedException();
    }
}
