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
using System.Windows.Shapes;

namespace Aukcija
{
    /// <summary>
    /// Interaction logic for NewProduct.xaml
    /// </summary>
    public partial class NewProduct : Window
    {
        public NewProduct()
        {
            InitializeComponent();
          
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (ProdajaEntities context = new ProdajaEntities())
                {
                    tblProduct product = new tblProduct();
                    product.name = txtName.Text;
                    product.price = Convert.ToInt32(txtPrice.Text);
                    product.bid = Convert.ToInt32(txtPrice.Text);
                    product.time = string.Format("{0:00}:{1:00}:{2:00}", 120 / 3600, (120 / 60) % 60, 120 % 60);
                    IsProduct = true;
                    context.tblProducts.Add(product);
                    context.SaveChanges();

                }
                this.Close();
            }
            catch
            {
                MessageBox.Show("Please fill all fiels corect.", "Warning");
            }
        }

       

        public bool IsProduct { get; set; }

        private void btnClose_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }



    }
}
