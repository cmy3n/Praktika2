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
    public partial class Page1 : Page
    {
        ClientsTableAdapter clients = new ClientsTableAdapter();

        public Page1()
        {
            InitializeComponent();

            DataGrid1.ItemsSource = clients.GetData();
        }

        private void ButtonPage1_Right_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page2());
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                object ID = (DataGrid1.SelectedItem as DataRowView).Row[0];
                clients.DeleteClients(Convert.ToInt32(ID));

                DataGrid1.ItemsSource = clients.GetData();
            } 
            catch (Exception ex) 
            { 
                
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                clients.InsertClients(Surname.Text, Name.Text, Middlename.Text, PhoneNumber.Text, Email.Text);
                DataGrid1.ItemsSource = clients.GetData();
            }
            catch (Exception ex)
            {

            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object ID = (DataGrid1.SelectedItem as DataRowView).Row[0];
                clients.UpdateClients(Surname.Text, Name.Text, Surname.Text, PhoneNumber.Text, Email.Text, Convert.ToInt32(ID));

                DataGrid1.ItemsSource = clients.GetData();
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
