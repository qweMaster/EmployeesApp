//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EmployeesApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DataAccept
    {
        public string date_accept { get; set; }
        public string date_dis { get; set; }
        public string post { get; set; }
        public int id_history { get; set; }
        public Nullable<int> id_worker { get; set; }
    
        public virtual Worker_information Worker_information { get; set; }
    }
}
