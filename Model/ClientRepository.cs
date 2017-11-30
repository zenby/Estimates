using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_DB;
using System.Configuration;
using AutoMapper;
using Model.classes;

namespace Model
{
    public class ClientRepository : IClientRepository
    {
        //private static string connectionStr = ConfigurationManager.ConnectionStrings["ConnectionStr"].ConnectionString;
        DB_Estimate context;
        public ClientRepository()
        {
            context = new DB_Estimate();
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<DAL_DB.Client, classes.Client>();
                cfg.CreateMap<classes.Client, DAL_DB.Client>();
                cfg.CreateMap<DAL_DB.Contract, classes.Contract>();
                cfg.CreateMap<classes.Contract, DAL_DB.Contract>();
                cfg.CreateMap<DAL_DB.Building, classes.Building>();
                cfg.CreateMap<classes.Building, DAL_DB.Building>();
            });
        }

        public void Add(ref classes.Client item)
        {
            DAL_DB.Client clientDB = Mapper.Map<DAL_DB.Client>(item);
            context.Client.Add(clientDB);
            context.SaveChanges();
            item.ClientID = clientDB.ClientID;
        }

        public void Delete(classes.Client item)
        {
            DAL_DB.Client clientDB = Mapper.Map<DAL_DB.Client>(item);
            List<DAL_DB.Contract> clients = new List<DAL_DB.Contract>(context.Contract.Cast<DAL_DB.Contract>());
            foreach (DAL_DB.Contract contract in clients)
            {
                if (contract.ClientID == clientDB.ClientID)
                {
                    foreach (DAL_DB.Building bld in contract.Building.ToArray())
                    {
                        context.Building.Remove(bld);
                    }
                    context.Contract.Remove(contract);
                }
            }
            context.Client.Remove(context.Client.First(clnt => clnt.ClientID == clientDB.ClientID));
            context.SaveChanges();
        }

        public IEnumerable<classes.Client> GetAll()
        {
            return context.Client.ToArray().Select(client => Mapper.Map<classes.Client>(client));
        }

        public void Update(classes.Client client)
        {
            DAL_DB.Client clientDB = context.Client.First(clnt => clnt.ClientID == client.ClientID);
            clientDB.Organization = client.Organization;
            clientDB.Adress = client.Adress;
            clientDB.Telephone = client.Telephone;
            clientDB.Fax = client.Fax;
            clientDB.PostIndex = client.PostIndex;
            clientDB.BankAccount = client.BankAccount;
        }
    }
}
