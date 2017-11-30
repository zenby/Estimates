
using Model.classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for ContractDialog.xaml
    /// </summary>
    public partial class ContractDialog : Window
    {
        public Contract NewContract { get; set; }
        public bool IsNew { get; set; }

        public ContractDialog(Client client)
        {
            InitializeComponent();
            DataContext = this;
            IsNew = false;
            NewContract = new Contract()
            {
                ContractNumber = "",
                DateOfSignature = new DateTime(2018, 10, 15)
                
            };
            NewContract.Building = new ObservableCollection<Building>();
        }
        public ContractDialog(Contract contract)
        {
            InitializeComponent();
            DataContext = this;
            IsNew = true;
            NewContract = contract;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
