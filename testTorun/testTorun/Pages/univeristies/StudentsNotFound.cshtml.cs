using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspDotNetApp.Application.ManageStudents;
using aspDotNetApp.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace aspDotNetAppp.Pages.univeristies
{
    public class StudentsNotFoundModel : PageModel

    {
        
        public readonly IStudentInterface imangeStudents;
        [BindProperty(SupportsGet = true)]
        public int UniID { set; get; }
        [BindProperty(SupportsGet = true)]
        public string NewName { set; get; }
        [BindProperty(SupportsGet = true)]
        public string NewAddress { set; get; }
        [BindProperty(SupportsGet = true)]
        public float NewGrades { set; get; }
        [BindProperty(SupportsGet = true)]
        
        public Students stud { set; get; }
        [BindProperty(SupportsGet =true)]
        public bool create { set; get; }
        
        //public Students stud { set; get; }
        public StudentsNotFoundModel(IStudentInterface imangeStudents)
        {
            this.imangeStudents = imangeStudents;
            stud = new Students();
        }
        public void OnGet(int UniID, bool create = false)
        {
            if (create)
            {
                this.UniID = UniID;
                stud = new Students();
                this.create = create;
            }
            else
            {
                this.UniID = UniID;
                stud = imangeStudents.GetSingleStudent(UniID);
            }
            /*this.UniID = UniID;
            stud = new Students();
            this.create = create;*/
        }
        public IActionResult OnPost()
        {
            if (create)
            {
                imangeStudents.AddingStudentToUni(UniID, stud);
                return RedirectToPage("./Univerties");
            }
            else
            {
                imangeStudents.EditStudent(this.UniID, stud);
                return RedirectToPage("./Univerties");
            }
            
            
            
        }
    }
}
