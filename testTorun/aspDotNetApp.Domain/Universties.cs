using System;
using System.Collections.Generic;
using System.Text;

namespace aspDotNetApp.Domain
{
    public class Universties
    {
        public int id { set; get; }
        public string name { set; get; }
        public string address { set; get; }
        public List<Students> students {set;get;}
        public Universties()
        {
            students = new List<Students>();
        }
    }
}
