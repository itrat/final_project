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
    
    public partial class Food
    {
        public Food()
        {
            this.Reservations = new HashSet<Reservation>();
        }
    
        public int Food_Id { get; set; }
        public Nullable<int> Restaurant_Id { get; set; }
        public string Food_Item { get; set; }
        public Nullable<int> Food_Price { get; set; }
    
        public virtual Restaurant Restaurant { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}