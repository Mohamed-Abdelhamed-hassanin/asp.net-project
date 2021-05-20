using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspDotNetApp.Application.ManageStudents;
using aspDotNetApp.Application.ManageUniveristy;
using aspDotNetApp.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace aspDotNetAppp.Pages.univeristies
{
    public class StudentsModel : PageModel
    {
      
        public readonly IStudentInterface imanagerStudent;
        [BindProperty(SupportsGet = true)]
        public string SearchValue { set; get; }
        public Students StudentDetail { set; get; }
        public List<Students> AllStudents { set; get; }
        [BindProperty(SupportsGet = true)]
        public Students stud { set; get; }
        [BindProperty(SupportsGet = true)]
        public int UniID { set; get; }
        [BindProperty(SupportsGet = true)]
        public string reset { set; get; }
        public StudentsModel(IStudentInterface imanagerStudent)
        {
            this.imanagerStudent = imanagerStudent;
            AllStudents = new List<Students>();
            stud = new Students();
        }
        public void OnGet(int StudentID,int UniID,string search)
        {
            StudentDetail = imanagerStudent.GetSingleStudent(UniID);
            AllStudents = imanagerStudent.GetStudentsOfOneUniveristy(UniID);
            //AllStudents = imanagerStudent.GetAllStudents();
            this.UniID = UniID;
           

            
        }
        public IActionResult OnPostDelete(int studentID)
        {
            imanagerStudent.DeleteStudent(studentID);
            return RedirectToPage("./Univerties");
        }
        public IActionResult OnPostSearch(string search = "")
        {
            reset = search;
            AllStudents = imanagerStudent.GetSearchedStudents(this.UniID, this.SearchValue);
            if (AllStudents.Count == 0)
            {
                return RedirectToPage("./StudentsNotFound");
            }
            else if(reset == "reset")
            {
                AllStudents = imanagerStudent.GetStudentsOfOneUniveristy(this.UniID);
                return default;
            }
            else
            {
                AllStudents = imanagerStudent.GetSearchedStudents(this.UniID, this.SearchValue);
                return default;
            }
            
        }
        public IActionResult OnPostStud()
        {

            imanagerStudent.AddingStudentToUni(UniID, stud);
             return RedirectToPage("./Univerties");
        }
    }
}
