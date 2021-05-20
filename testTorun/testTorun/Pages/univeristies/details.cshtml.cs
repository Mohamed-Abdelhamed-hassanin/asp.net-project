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
    public class detailsModel : PageModel
    {
        public Universties DeatilsUni { get; set; }
        private readonly IMangerUniveristy Imanager;
        public detailsModel(IMangerUniveristy Imanager)
        {
            this.Imanager = Imanager;
        }
        public IActionResult OnGet(int IdForUniveristy)
        {
            DeatilsUni = Imanager.SingleUniveristyDetails(IdForUniveristy);
            if(DeatilsUni == null)
            {
                return RedirectToPage("./UniveristyNotFound");
            }
            else
            {
                return Page();
            }
        }
    }
}
