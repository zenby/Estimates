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
using Model.classes;

namespace Estimates
{
    /// <summary>
    /// Interaction logic for BuildingDialog.xaml
    /// </summary>
    public partial class BuildingDialog : Window
    {

        public Building NewBuilding { get; set; }
        public BuildingDialog(Contract contract)
        {
            InitializeComponent();
            DataContext = this;

            NewBuilding = new Building()
            {
                ContractNumber = contract.ContractNumber,
                NameOfTheObject = "NameOfTheObject",
                IssueDate = new DateTime(2018, 10, 3),
                Length = 1,
                Width = 1,
                Height = 1.12F,
                Amount = 1,
                IsCivil = true,
                IsMultistory = true,
                IsPreserved = false,
                IsWhileConstruction = false,
                StoreyHeight = 2,
                PrimalCoefficient = 1,
                CostOfTheObject = 100,
                InvNumber = "хэштег ящерка"
            };
        }
        public BuildingDialog(Building bld)
        {
            InitializeComponent();
            DataContext = this;
            NewBuilding = bld;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            NewBuilding.CostOfTheObject = NewBuilding.Length * NewBuilding.Width * NewBuilding.Height * NewBuilding.Amount * NewBuilding.PrimalCoefficient;
            this.DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
