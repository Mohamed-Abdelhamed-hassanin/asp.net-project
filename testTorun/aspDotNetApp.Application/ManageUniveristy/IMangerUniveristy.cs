using System;
using System.Collections.Generic;
using System.Text;
using aspDotNetApp.Domain;

namespace aspDotNetApp.Application.ManageUniveristy
{
    public interface  IMangerUniveristy
    {
        List<Universties> GetUniversties();
        Universties SingleUniveristyDetails(int id);
        List<Universties> GetUniveristyByName(string name);
        void deleteUni(int uniID);
        void addUni(Universties uni);
        void EditUni(Universties uni);
      
    }
}
