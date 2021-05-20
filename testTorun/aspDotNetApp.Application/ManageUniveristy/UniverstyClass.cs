using aspDotNetApp.Data;
using aspDotNetApp.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace aspDotNetApp.Application.ManageUniveristy
{

    public class UniverstyClass : IMangerUniveristy
    {
        private readonly UniDbContext dbContext;
        public UniverstyClass(UniDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void addUni(Universties uni)
        {
            dbContext.Universties.Add(uni);
            dbContext.SaveChanges();
        }

        public void deleteUni(int uniID)
        {
            var DeletedUni = dbContext.Universties.SingleOrDefault(stud => stud.id == uniID); 
            dbContext.Universties.Remove(DeletedUni);
            dbContext.SaveChanges();
        }

        public void EditUni(Universties uni)
        {
            var uniToBeEdited = dbContext.Universties.SingleOrDefault(stud =>stud.id == uni.id);
            if(uniToBeEdited != null)
            {
                uniToBeEdited.name = uni.name;
                uniToBeEdited.address = uni.address;
                
                dbContext.SaveChanges();
            }
        }

     

        public List<Universties> GetUniveristyByName(string name)
        {
            return dbContext.Universties.Where(uni => uni.name.StartsWith(name) ).ToList();
        }

        public List<Universties> GetUniversties()
        {
            
            return dbContext.Universties.Include(uni =>uni.students).ToList();
        }

        public Universties SingleUniveristyDetails(int univeristyId)
        {
            return GetUniversties().SingleOrDefault(stud => stud.id == univeristyId);
        }


    }
}
