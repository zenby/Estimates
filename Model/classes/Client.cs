using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;


namespace Model.classes
{
    public class Client: ViewModelBase
    {

        private string organization;
        private string adress;
        private string telephone;
        private string bankAccount;
        private string fax;
        private int postIndex;
        private int clientID;

        public string Organization
        {
            get { return organization; }
            set { Set(nameof(Organization), ref organization, value); }
        }
        public string Adress
        {
            get { return adress; }
            set { Set(nameof(Adress), ref adress, value); }
        }
        public string Telephone
        {
            get { return telephone; }
            set { Set(nameof(Telephone), ref telephone, value); }
        }
        public string BankAccount
        {
            get { return bankAccount; }
            set { Set(nameof(BankAccount), ref bankAccount, value); }
        }
        public string Fax
        {
            get { return fax; }
            set { Set(nameof(Fax), ref fax, value); }
        }
        public int PostIndex
        {
            get { return postIndex; }
            set { Set(nameof(PostIndex), ref postIndex, value); }
        }
        public int ClientID
        {
            get { return clientID; }
            set { Set(nameof(ClientID), ref clientID, value); }
        }
        public ObservableCollection <Contract> Contract { get; set; }
    }
}
