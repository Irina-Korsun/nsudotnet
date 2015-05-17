//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfFormsAndTables
{
    using System;
    using System.Collections.Generic;
    
    public partial class EmployeesBase
    {
        public EmployeesBase()
        {
            this.ChildsBase = new HashSet<ChildsBase>();
            this.DepartmentsBase = new HashSet<DepartmentsBase>();
            this.MedicalChecksBase = new HashSet<MedicalChecksBase>();
        }
    
        public long ID { get; set; }
        public long DepartmentRefId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public System.DateTime HireDate { get; set; }
        public bool Sex { get; set; }
        public System.DateTime BirthDate { get; set; }
        public int Salary { get; set; }
        public Nullable<long> Brigade_ID { get; set; }
        public Nullable<long> Position_ID { get; set; }
    
        public virtual BrigadesBase BrigadesBase { get; set; }
        public virtual ICollection<ChildsBase> ChildsBase { get; set; }
        public virtual ICollection<DepartmentsBase> DepartmentsBase { get; set; }
        public virtual DepartmentsBase DepartmentsBase1 { get; set; }
        public virtual PositionsBase PositionsBase { get; set; }
        public virtual ICollection<MedicalChecksBase> MedicalChecksBase { get; set; }
    }
}
