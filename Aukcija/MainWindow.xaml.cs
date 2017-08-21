using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace Aukcija
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FillDataGrid();
            Window_Loaded();
            Time();
            btnAddProduct.Visibility = Visibility.Hidden;
            btnBidColl.Visibility = Visibility.Hidden;
            btnDelete.Visibility = Visibility.Hidden;
            ime.Text = "Guest";
        }

        public MainWindow(string role)
        {
            InitializeComponent();
            FillDataGrid();
            Window_Loaded_Refresh();
            ime.Text = role;

            if (role == "admin")
            {
                btnBidColl.Visibility = Visibility.Hidden;
              
            }
            else
            {
                btnAddProduct.Visibility = Visibility.Hidden;
                btnDelete.Visibility = Visibility.Hidden;
                name = role;

            }
        }
        string name;

        public void FillDataGrid()
        {
            using (ProdajaEntities context = new ProdajaEntities())
            {
                DataGridResults.ItemsSource = context.vwProducts.ToList();
            }

        }
        private void Time()
        {
            using (ProdajaEntities context = new ProdajaEntities())
            {
                tblProduct product = new tblProduct();

                foreach (tblProduct item in context.tblProducts)
                {
                    item.time = "00:02:00";
                }
                context.SaveChanges();
                FillDataGrid();
            }
        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            NewProduct product = new NewProduct();
            product.ShowDialog();

            if (product.IsProduct == true)
            {
                FillDataGrid();
            }
        }

        private void btnBID_Click(object sender, RoutedEventArgs e)
        {
            vwProduct row = (vwProduct)DataGridResults.SelectedItem;

            object item = DataGridResults.SelectedItem;
            string pozition = (DataGridResults.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            int id = Convert.ToInt16(pozition);

            using (ProdajaEntities context = new ProdajaEntities())
            {
                //var itemToBid = context.tblProducts.SingleOrDefault(x => x.productID == row.productID);
                var itemToBid = context.tblProducts.SingleOrDefault(x => x.productID == id);


                if (itemToBid != null)
                {
                    itemToBid.bid++;
                    itemToBid.customer = name;
                    TimeSpan s1 = TimeSpan.Parse(itemToBid.time);
                    TimeSpan s2 = TimeSpan.Parse("00:02:00");
                    TimeSpan s3 = s1 + s2;
                    int vreme = Convert.ToInt32(s3.TotalSeconds);
                    itemToBid.time = string.Format("{0:00}:{1:00}:{2:00}", vreme / 3600, (vreme / 60) % 60, vreme % 60);
                    //itemToBid.time = "00:02:00";
                    context.SaveChanges();
                }

                FillDataGrid();
            }
        }

        private void Window_Loaded()
        {
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            using (ProdajaEntities context = new ProdajaEntities())
            {
                tblProduct product = new tblProduct();

                foreach (tblProduct item in context.tblProducts)
                {
                    try
                    {
                        TimeSpan ts = TimeSpan.Parse(item.time);
                        int vreme = Convert.ToInt32(ts.TotalSeconds);
                        --vreme;
                        item.time = string.Format("{0:00}:{1:00}:{2:00}", vreme / 3600, (vreme / 60) % 60, vreme % 60);
                        if (vreme < 0)
                        {
                            //this.btnBidColl.Visibility = Visibility.Hidden;

                            item.time = "CLOSED";
                            // ((DispatcherTimer)sender).Stop();
                        }
                    }
                    catch
                    {
                        item.time = "CLOSED";
                    }
                }
                context.SaveChanges();
                FillDataGrid();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            vwProduct row = (vwProduct)DataGridResults.SelectedItem;

            object item = DataGridResults.SelectedItem;
            string pozition = (DataGridResults.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            int id = Convert.ToInt16(pozition);

            using (ProdajaEntities context = new ProdajaEntities())
            {
                //var itemToBid = context.tblProducts.SingleOrDefault(x => x.productID == row.productID);
                var itemToBid = context.tblProducts.SingleOrDefault(x => x.productID == id);
                if (itemToBid != null)
                {
                    context.tblProducts.Remove(itemToBid);
                    context.SaveChanges();
                }

                FillDataGrid();
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void Window_Loaded_Refresh()
        {
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick_Refresh);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
        }


        private void dispatcherTimer_Tick_Refresh(object sender, EventArgs e)
        {
            using (ProdajaEntities context = new ProdajaEntities())
            {
                tblProduct product = new tblProduct();

                foreach (tblProduct item in context.tblProducts)
                {
                    try
                    {
                        TimeSpan ts = TimeSpan.Parse(item.time);
                        int vreme = Convert.ToInt32(ts.TotalSeconds);
                        if (vreme == 0)
                        {
                            // this.btnBidColl.Visibility = Visibility.Hidden;

                            item.time = "CLOSED";
                            // ((DispatcherTimer)sender).Stop();
                        }
                        item.time = string.Format("{0:00}:{1:00}:{2:00}", vreme / 3600, (vreme / 60) % 60, vreme % 60);
                    }
                    catch
                    {
                        this.btnBidColl.Visibility = Visibility.Hidden;



                        item.time = "CLOSED";
                        //((DispatcherTimer)sender).Stop();
                    }
                }

                context.SaveChanges();
                FillDataGrid();
            }
        }
    }
}
