using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspDotNetApp.Application.ManageUniveristy;
using aspDotNetApp.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace aspDotNetAppp.Pages.univeristies
{
    public class EditModel : PageModel
    {
        private readonly IMangerUniveristy imangerUni;
        [BindProperty(SupportsGet = true)]
        public Universties uni { set; get; }
        public string Name { set; get; }
        [BindProperty(SupportsGet = true)]
        public string Address { set; get; }
        
        public EditModel(IMangerUniveristy imangerUni)
        {
            this.imangerUni = imangerUni;
        }
        [BindProperty(SupportsGet = true)]
        public bool EditFlag { set; get; }
        public void OnGet(int IdForUniveristy = 0)
        {
            if(IdForUniveristy == 0)
            {
                EditFlag = false;
            }
            else
            {
                EditFlag = true;
                uni = imangerUni.SingleUniveristyDetails(IdForUniveristy);
                
            }
            var i = EditFlag == true ? true : false;
            
        }
        //public bool i = EditFlag == true ? true : false;
        public IActionResult OnPost()
        {
           
            if(EditFlag)
            {
                var EditedUni = new Universties() { id = uni.id, name = uni.name, address = uni.address };
                imangerUni.EditUni(EditedUni);
                return RedirectToPage("./Univerties");
            }
            else
            {
                var CreatedUni = new Universties() { name = uni.name, address = uni.address };
                imangerUni.addUni(CreatedUni);
                return RedirectToPage("./Univerties");
            }
            //return default;
        }
    }
}
