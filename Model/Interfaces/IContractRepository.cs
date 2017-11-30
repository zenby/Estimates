using Model.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interfaces
{
    public interface IContractRepository : IBaseRepository<Contract>
    {
        classes.Contract GetContractById(classes.Building bld);
    }
}
