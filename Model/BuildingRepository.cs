using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.classes;
using Model.Interfaces;
using DAL_DB;
using AutoMapper;

namespace Model
{
    public class BuildingRepository : IBuildingRepository
    {
        DB_Estimate context;
        public BuildingRepository()
        {
            context = new DB_Estimate();

        }
        public void Add(ref classes.Building item)
        {
            DAL_DB.Building buildingDB = Mapper.Map<DAL_DB.Building>(item);
            context.Building.Add(buildingDB);
            context.SaveChanges();
            item.ObjectID = buildingDB.ObjectID;
        }

        public void Delete(classes.Building item)
        {
            context.Building.Remove(context.Building.FirstOrDefault(bld => bld.ObjectID == item.ObjectID));
            context.SaveChanges();
        }

        public IEnumerable<classes.Building> GetAll()
        {
            return context.Building.ToArray().Select(bld => Mapper.Map<classes.Building>(bld));
        }

        public void Update(classes.Building building)
        {
            DAL_DB.Building buildingDB = context.Building.First(bld => bld.ObjectID == building.ObjectID);
            buildingDB.NameOfTheObject = building.NameOfTheObject;
            buildingDB.IssueDate = building.IssueDate;
            buildingDB.Length = building.Length;
            buildingDB.Width = building.Width;
            buildingDB.Height = building.Height;
            buildingDB.Amount = building.Amount;
            buildingDB.IsCivil = building.IsCivil;
            buildingDB.IsPreserved = building.IsPreserved;
            buildingDB.IsWhileConstruction = building.IsWhileConstruction;
            buildingDB.IsMultistory = building.IsMultistory;
            buildingDB.StoreyHeight = building.StoreyHeight;
            buildingDB.PrimalCoefficient = building.PrimalCoefficient;
            buildingDB.CostOfTheObject = building.CostOfTheObject;
            buildingDB.InvNumber = building.InvNumber;
            context.SaveChanges();
        }
    }
}
