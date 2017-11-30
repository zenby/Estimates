using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.classes;
using DAL_DB;
using AutoMapper;

namespace Model
{
    public class ContractRepository : IContractRepository
    {
        DB_Estimate context;
        public ContractRepository()
        {
            context = new DB_Estimate();

        }
        public void Add(ref classes.Contract item)
        {
            DAL_DB.Contract contractDB = Mapper.Map<DAL_DB.Contract>(item);
            context.Contract.Add(contractDB);
            context.SaveChanges();
            item.ClientID = contractDB.ClientID;
        }

        public void Delete(classes.Contract item)
        {
            DAL_DB.Contract contractDB = Mapper.Map<DAL_DB.Contract>(item);
            List<DAL_DB.Building> blds = new List<DAL_DB.Building>(context.Building.Cast<DAL_DB.Building>());
            foreach (DAL_DB.Building buildingToDel in blds)
            {
                if (buildingToDel.ContractNumber == contractDB.ContractNumber)
                {
                    context.Building.Remove(buildingToDel);
                }
            }      
            context.Contract.Remove(context.Contract.First(ctr => ctr.ContractNumber == contractDB.ContractNumber));
            context.SaveChanges();
        }

        public IEnumerable<classes.Contract> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(classes.Contract contract)
        {
            DAL_DB.Contract contractDB = context.Contract.First(ctr => ctr.ContractNumber == contract.ContractNumber);
            contractDB.DateOfSignature = contract.DateOfSignature;
            context.SaveChanges();
        }
        public classes.Contract GetContractById(classes.Building building)
        {

            return Mapper.Map<classes.Contract>(context.Contract.First(cntr => cntr.ContractNumber == building.ContractNumber));



        }
    }
}
