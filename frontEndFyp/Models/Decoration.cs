//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace frontEndFyp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Decoration
    {
        public Decoration()
        {
            this.Reservations = new HashSet<Reservation>();
        }
    
        public int Decoration_Id { get; set; }
        public Nullable<int> Restaurant_Id { get; set; }
        public string Decoration_Type { get; set; }
        public Nullable<int> Decoration_Price { get; set; }
    
        public virtual Restaurant Restaurant { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}