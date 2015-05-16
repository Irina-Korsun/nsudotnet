using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBaseLab.DataObjects
{
    [Table("ChildsBase")]
    public class Childs
    {
        [Key]
        public long ID { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }

        public long ParentRefId { get; set; }

        [ForeignKey("ParentRefId")]
        public virtual Employees Parent  { get; set; }
    }
}