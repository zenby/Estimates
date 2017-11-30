using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Model.classes;
using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Linq;
using System.Xml.Linq;

namespace Estimates.ViewModel
{

    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Fields
        /// </summary>
        private ObservableCollection<Client> listClient;
        private UserControl dynamicUserControl;
        private UserControl chartsUserControl;
        private object selectedItem;
        private Client selectedClient;
        private Contract selectedContract;
        private Building selectedBuilding;
        private string selectedName;
        private string time;
        private int selectedObject;
        private Client parentClient;
        private Contract parentContract;

        /// <summary>
        /// Properties
        /// </summary>
        public ObservableCollection<Client> ListClient
        {
            get { return listClient; }
            set { Set(nameof(ListClient), ref listClient, value); }
        }
        public UserControl DynamicUserControl
        {
            get { return dynamicUserControl; }
            set { Set(nameof(DynamicUserControl), ref dynamicUserControl, value); }
        }
        public UserControl ChartsUserControl
        {
            get { return chartsUserControl; }
            set { Set(nameof(ChartsUserControl), ref chartsUserControl, value); }
        }
        public object SelectedItem
        {
            get { return selectedItem; }
            set { Set(nameof(SelectedItem), ref selectedItem, value); }
        }
        public Client SelectedClient
        {
            get { return selectedClient; }
            set { Set(nameof(SelectedClient), ref selectedClient, value); }
        }
        public Contract SelectedContract
        {
            get { return selectedContract; }
            set { Set(nameof(SelectedContract), ref selectedContract, value); }
        }
        public Building SelectedBuilding
        {
            get { return selectedBuilding; }
            set { Set(nameof(SelectedBuilding), ref selectedBuilding, value); }
        }
        public string SelectedName
        {
            get { return selectedName; }
            set { Set(nameof(SelectedName), ref selectedName, value); }
        }
        public int SelectedObject
        {
            get { return selectedObject; }
            set { Set(nameof(SelectedObject), ref selectedObject, value); }
        }
        public string Time
        {
            get { return time; }
            set { Set(nameof(Time), ref time, value); }
        }
        public string DayOfTheWeek { get; set; }
        public Client ParentClient
        {
            get { return parentClient; }
            set { Set(nameof(ParentClient), ref parentClient, value); }
        }
        public Contract ParentContract
        {
            get { return parentContract; }
            set { Set(nameof(ParentContract), ref parentContract, value); }
        }

        List<Action> actions = new List<Action>();
        IClientRepository clientsRepo;
        IBuildingRepository buildingRepo;
        IContractRepository contractRepo;
        public MainViewModel(IClientRepository clientsRepo, IBuildingRepository buildingRepo, IContractRepository contractRepo)
        {
            // передача значений полю от переданного объекта клиенты
            this.clientsRepo = clientsRepo;
            this.buildingRepo = buildingRepo;
            this.contractRepo = contractRepo;
            // заполенение свойства элементами дерева из БД
            ListClient = new ObservableCollection<Client>(this.clientsRepo.GetAll());
            DayOfTheWeek = DateTime.Now.DayOfWeek.ToString();
            DispatcherTimer t = new DispatcherTimer(new TimeSpan(0, 0, 0, 0, 50), DispatcherPriority.Background, t_Tick, Dispatcher.CurrentDispatcher); t.IsEnabled = true;

            //установка выбранного объекта дерева в свойство
            SetSelectedItemCommand = new RelayCommand<object>(item =>
              {
                  if (item is Client)
                  {
                      SelectedClient = item as Client;
                      SelectedBuilding = null;
                      SelectedContract = null;
                      SelectedName = SelectedClient.Organization;
                      DynamicUserControl = new UserControlClients(SelectedClient);
                      ChartsUserControl = new UserControlDiagram();
                      SelectedObject = 1;
                      ParentClient = null;
                      ParentContract = null;
                  }
                  else if (item is Contract)
                  {
                      SelectedContract = item as Contract;
                      SelectedClient = null;
                      SelectedBuilding = null;
                      SelectedName = SelectedContract.ContractNumber;
                      DynamicUserControl = new UserControlContracts(SelectedContract);
                      ChartsUserControl = new UserControlDiagram(SelectedContract);
                      SelectedObject = 2;
                      ParentClient = ListClient.First(clnt => clnt.ClientID == SelectedContract.ClientID);
                      ParentContract = null;

                  }
                  else if (item is Building)
                  {
                      SelectedBuilding = item as Building;
                      SelectedContract = null;
                      SelectedClient = null;
                      SelectedName = SelectedBuilding.NameOfTheObject;
                      DynamicUserControl = new UserControlBuildings(SelectedBuilding);
                      ChartsUserControl = new UserControlDiagram();
                      SelectedObject = 3;
                      ParentContract = contractRepo.GetContractById(SelectedBuilding); //получили родительский контракт из БД
                      ParentClient = ListClient.First(client => client.ClientID == ParentContract.ClientID); //получили родительского клиента из ListClient
                      ParentContract = ParentClient.Contract.First(ctr => ctr.ContractNumber == ParentContract.ContractNumber); //переписали контракт на контракт из ListClient
                  }
              });

            #region commands
            // удалить объект
            Action DeleteBuildingAction = () =>
                {
                    Building bld = SelectedBuilding;
                    buildingRepo.Delete(bld);

                    ParentContract.Building.Remove(bld);
                };
            actions.Add(DeleteBuildingAction);
            
            DeleteBuildingCmd = new RelayCommand(DeleteBuildingAction, () => SelectedObject == 3);
            // редактировать объект
            UpdateBuildingCmd = new RelayCommand(() =>
            {
                if (SelectedBuilding != null)
                {
                    BuildingDialog buildDlg = new BuildingDialog(SelectedBuilding);
                    if (buildDlg.ShowDialog() == true)
                    {
                        buildingRepo.Update(buildDlg.NewBuilding);
                        SelectedBuilding = buildDlg.NewBuilding;
                    }
                }
            }, () => SelectedObject == 3); 
            // добавить объект
            AddBuildingCmd = new RelayCommand(() =>
            {
                Building bld;
                BuildingDialog buildDlg = new BuildingDialog(SelectedContract);
                if (buildDlg.ShowDialog() == true)
                {
                    bld = buildDlg.NewBuilding;
                    buildingRepo.Add(ref bld);
                    if (SelectedContract.Building == null)
                    {
                        SelectedContract.Building = new ObservableCollection<Building>();
                    }
                    SelectedContract.Building.Add(bld);
                }
            }, () => SelectedObject == 2);
            // редактировать клиента
            UpdateClientCmd = new RelayCommand(() =>
           {
               Client clt;
               ClientDialog clntDlg = new ClientDialog(SelectedClient);
               if (clntDlg.ShowDialog() == true)
               {
                   clt = clntDlg.NewClient;
                   clientsRepo.Update(clntDlg.NewClient);
               }
           }, () => SelectedObject == 1);
            // добавить клиента
            AddClientCmd = new RelayCommand(() =>
            {
                Client clt;
                ClientDialog clntDlg = new ClientDialog();
                if (clntDlg.ShowDialog() == true)
                {
                    clt = clntDlg.NewClient;
                    clientsRepo.Add(ref clt);
                    ListClient.Add(clt);
                }
            }, () => SelectedObject == 1);
            // добавить контракт
            AddContractCmd = new RelayCommand(() =>
           {
               Contract contract;
               ContractDialog contractDialog = new ContractDialog(SelectedClient);
               if (contractDialog.ShowDialog() == true)
               {
                   contract = contractDialog.NewContract;
                   contract.ClientID = SelectedClient.ClientID;
                   contractRepo.Add(ref contract);
                   if (SelectedClient.Contract == null)
                   {
                       SelectedClient.Contract = new ObservableCollection<Contract>();
                       
                   }
                   SelectedClient.Contract.Add(contract);
               }
           }, () => SelectedObject == 1);
            // редактировать контракт
            UpdateContractCmd = new RelayCommand(() =>
            {
                Contract contract;
                ContractDialog contractDialog = new ContractDialog(SelectedContract);
                if (contractDialog.ShowDialog() == true)
                {
                    contract = contractDialog.NewContract;
                    contractRepo.Update(contractDialog.NewContract);
                }
            }, () => SelectedObject == 2);
            // удалить контракт
            DeleteContractCmd = new RelayCommand(() =>
            {
                Contract contract = SelectedContract;
                contractRepo.Delete(SelectedContract);
                if (SelectedContract.Building != null)
                {
                    SelectedContract.Building.Clear();
                }
                ParentClient.Contract.Remove(SelectedContract);
            }, () => SelectedObject == 2);
            // удалить клиента
            DeleteClientCmd = new RelayCommand(() =>
            {
                Client contract = SelectedClient;
                clientsRepo.Delete(SelectedClient);
                if (SelectedClient.Contract != null)
                {
                    SelectedClient.Contract.Clear();
                }
                ListClient.Remove(SelectedClient);
            }, () => SelectedObject == 1);
            // вывести сметы в XML
            BuildingToXmlCmd = new RelayCommand(() =>
            {
               XDocument BuildingsXML = new XDocument(
                   new XDeclaration("1.0", "utf-8", "yes"),
                   new XComment("Lizzard #smiles #loveMVVM #IAmGoodStudent"),
               new XElement("Buildings",
                    buildingRepo.GetAll().Select(bld=>
                        new XElement("Building", 
                            new XAttribute("ID",bld.ObjectID),
                            new XElement("Name", bld.NameOfTheObject),
                            new XElement("Contract_Number", bld.ContractNumber),
                            new XElement("Issue_Date", bld.IssueDate.ToLongDateString()),
                            new XElement("Cost", bld.CostOfTheObject)
                                    )
                                )
                    ));
                BuildingsXML.Save(@"Buildings.xml");                
            });
            #endregion
        }

        private void t_Tick(object sender, EventArgs e)
        {
            Time = Convert.ToString(DateTime.Now);
        }
        public RelayCommand DeleteBuildingCmd { get; set; }
        public RelayCommand AddBuildingCmd { get; set; }
        public RelayCommand<object> SetSelectedItemCommand { get; set; }
        public RelayCommand UpdateBuildingCmd { get; set; }
        public RelayCommand UpdateClientCmd { get; set; }
        public RelayCommand AddClientCmd { get; set; }
        public RelayCommand AddContractCmd { get; set; }
        public RelayCommand UpdateContractCmd { get; set; }
        public RelayCommand DeleteContractCmd { get; set; }
        public RelayCommand DeleteClientCmd { get; set; }
        public RelayCommand BuildingToXmlCmd { get; set; }




    }
}