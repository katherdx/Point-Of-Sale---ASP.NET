//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Point_Of_Sale
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employee
    {
        public int ID { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeContact { get; set; }
        public string EmployeeEmail { get; set; }
        public string EmployeePassword { get; set; }
        public bool EmployeeGender { get; set; }
        public System.DateTime EmployeeJoinDate { get; set; }
        public System.DateTime EmployeeDateOfBirth { get; set; }
        public string EmployeeAddress { get; set; }
        public int EmployeeCityID { get; set; }
        public string EmployeePicture { get; set; }
    
        public virtual City City { get; set; }
        public virtual EmployeeAdmin EmployeeAdmin { get; set; }
    }
}