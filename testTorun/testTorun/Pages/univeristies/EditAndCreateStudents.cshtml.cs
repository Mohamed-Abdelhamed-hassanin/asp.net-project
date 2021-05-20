using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace aspDotNetAppp.Pages.univeristies
{
    public class EditAndCreateStudentsModel : PageModel
    {
        public string AddedName { set; get; }
        public string AddedAddress { set; get; }
        public float AddedGrades { set; get; }
        public void OnGet()
        {
        }
    }
}
