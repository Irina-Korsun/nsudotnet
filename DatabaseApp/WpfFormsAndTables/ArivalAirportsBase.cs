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
    
    public partial class ArivalAirportsBase
    {
        public ArivalAirportsBase()
        {
            this.FlightsBase = new HashSet<FlightsBase>();
        }
    
        public long ID { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Town { get; set; }
    
        public virtual ICollection<FlightsBase> FlightsBase { get; set; }
    }
}
