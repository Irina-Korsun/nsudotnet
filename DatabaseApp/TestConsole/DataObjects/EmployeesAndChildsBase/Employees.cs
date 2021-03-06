﻿using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBaseLab.DataObjects
{
    [Table("EmployeesBase")]
    public class Employees
    {
        public Employees(){
            HireDate = DateTime.Now;
            BirthDate = DateTime.Now;
        }
        [Key]
        public long ID { get; set; }

        public Positions Position { get; set; }
        public long DepartmentRefId { get; set; }
        [ForeignKey("ParentRefId")]
        public Departments Department { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime HireDate { get; set; }
        public bool Sex { get; set; }
        public DateTime BirthDate { get; set; }
        public int Salary { get; set; }

        public List<Childs> Children { get; set; }
        public Brigades Brigade { get; set; }

        public override string ToString()
        {
            return Name;
        }
        //public void SetPosition(DataColumn column)
        //{
        //    column.ExtendedProperties.Add("Position", Position.ToString());
        //}
    }
}