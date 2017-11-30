using Model.classes;
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

namespace Estimates
{
    /// <summary>
    /// Interaction logic for ClientDialog.xaml
    /// </summary>
    public partial class ClientDialog : Window
    {
        public Client NewClient { get; set; }
        public ClientDialog(Client client)
        {
            InitializeComponent();
            DataContext = this;
            NewClient = client;

        }

        public ClientDialog()
        {
            InitializeComponent();
            DataContext = this;
            NewClient = new Client()
            {
                Organization = "name of the organisation",
                Adress = "Adress",
                Telephone = "telephone",
                Fax = "fax",
                PostIndex = 220000,
                BankAccount = "bank account",
            };
             
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
