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
    
    public partial class BrigadesBase
    {
        public BrigadesBase()
        {
            this.EmployeesBase = new HashSet<EmployeesBase>();
        }
    
        public long ID { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<EmployeesBase> EmployeesBase { get; set; }
    }
}
