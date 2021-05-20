using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspDotNetApp.Application.ManageUniveristy;
using aspDotNetApp.Data;
using aspDotNetApp.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace testTorun.Pages.univeristies
{
    public class UnivertiesModel : PageModel
    {
        
        public string message { set; get; }
        private readonly IConfiguration config;
        [BindProperty(SupportsGet = true)]
        public string searchByName { set; get; }
       
        public List<Universties> Univeristies { set; get; }
        public readonly IMangerUniveristy ImanagerUniveristy;
        [BindProperty(SupportsGet = true)]
        public string AddedName { set; get; }
        [BindProperty(SupportsGet = true)]
        public string AddedAddress { set; get; }
        public string directon { set; get; }
        

        public UnivertiesModel(IConfiguration con,IMangerUniveristy ImanagerUniveristy)
        {
            config = con;
            this.ImanagerUniveristy = ImanagerUniveristy;
        }
        public IActionResult OnGet(string search,int IdForDelete = 0)
        {
        
            if (search == "reset")
            {
                Univeristies = this.ImanagerUniveristy.GetUniversties();
            }
            else if(this.searchByName == null)
            {
                Univeristies = this.ImanagerUniveristy.GetUniversties();
                
            }
            else
            {
                Univeristies = this.ImanagerUniveristy.GetUniveristyByName(this.searchByName);
            }
            if(IdForDelete != 0)
            {
                ImanagerUniveristy.deleteUni(IdForDelete);
                return RedirectToPage("./Univerties");
            }
            return default;
            
        }
        public IActionResult OnPost()
        {
            
            var uni = new Universties() { name = AddedName, address = AddedAddress };
            ImanagerUniveristy.addUni(uni);
            return RedirectToPage("./Univerties");
        }
    }
}
