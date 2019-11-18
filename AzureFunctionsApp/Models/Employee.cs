using System;
using System.Collections.Generic;
using System.Text;

namespace AzureFunctionsApp.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public DateTime BirthDate { get; set; }
        public int DepartmentId { get; set; }
    }


}
