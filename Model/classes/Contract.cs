using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;

namespace Model.classes
{
    public class Contract : ViewModelBase
    {

        private string contractNumber;
        private int clientID;
        private DateTime dateOfSignature;
        private ObservableCollection<Building> building;


        public string ContractNumber
        {
            get { return contractNumber; }
            set { Set(nameof(ContractNumber), ref contractNumber, value); }
        }
        public int ClientID
        {
            get { return clientID; }
            set { Set(nameof(ClientID), ref clientID, value); }
        }
        public DateTime DateOfSignature
        {
            get { return dateOfSignature; }
            set { Set(nameof(DateOfSignature), ref dateOfSignature, value); }
        }
        public ObservableCollection<Building> Building
        {
            get { return building; }
            set { Set(nameof(Building), ref building, value); }
        }

    }




}
