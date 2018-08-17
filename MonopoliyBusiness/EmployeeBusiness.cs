using MonopolyDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace MonopoliyBusiness
{
    public class EmployeeBusiness
    {
        public void Save(Employee emp)
        {
            DbConnection db = new DbConnection();
            List<Parameter> paramter = new List<Parameter>();
            
            paramter.Add(new Parameter("@Id", emp.Id));
            paramter.Add(new Parameter("@Name", emp.Name));

            db.ExcecuteSp("SpSaveEmployee", paramter);
        }

        public object LoadEmployee()
        {
            return new DbConnection().ExcecuteSp("SpSelectEmployee", null);
        }
    }
}
