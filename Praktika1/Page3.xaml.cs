using System;
using System.Collections.Generic;
using System.Data;
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
using Praktika1.DataSetTableAdapters;

namespace Praktika1
{
    
    public partial class Page3 : Page
    {
        OrdersClientsTableAdapter OrdersCLients = new OrdersClientsTableAdapter();

        public Page3()
        {
            InitializeComponent();

            DataGrid3.ItemsSource = OrdersCLients.GetData();
        }

        private void ButtonPage3_Left_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page2());
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OrdersCLients.InsertOrdersClients(Convert.ToDateTime(ReceivingDate.Text), Convert.ToInt32(Client_ID.Text), Convert.ToInt32(Order_ID.Text));
                DataGrid3.ItemsSource = OrdersCLients.GetData();
            }
            catch (Exception ex)
            {

            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object ID = (DataGrid3.SelectedItem as DataRowView).Row[0];
                OrdersCLients.DeleteOrdersClients(Convert.ToInt32(ID));

                DataGrid3.ItemsSource = OrdersCLients.GetData();
            }
            catch (Exception ex)
            {

            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object ID = (DataGrid3.SelectedItem as DataRowView).Row[0];
                OrdersCLients.UpdateOrdersClients(Convert.ToDateTime(ReceivingDate.Text), Convert.ToInt32(Client_ID.Text), Convert.ToInt32(Order_ID.Text), Convert.ToInt32(ID));

                DataGrid3.ItemsSource = OrdersCLients.GetData();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
