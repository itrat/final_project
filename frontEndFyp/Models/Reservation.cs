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

    public partial class Reservation
    {
        public Reservation()
        {
            this.Payments = new HashSet<Payment>();
        }

        public int Reservation_Id { get; set; }
        public string Time_In { get; set; }
        public string Time_Out { get; set; }
        public string Total_Persons { get; set; }
        public string Total_Price { get; set; }
        public Nullable<int> Decoration_Id { get; set; }
        public Nullable<int> Sound_Id { get; set; }
        public Nullable<int> Food_Id { get; set; }
        public Nullable<int> Restaurant_Id { get; set; }
        public Nullable<int> User_Id { get; set; }
        public int Event_Id { get; set; }
        public string Date { get; set; }

        public virtual Decoration Decoration { get; set; }
        public virtual Event Event { get; set; }
        public virtual Food Food { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        public virtual SoundSystem SoundSystem { get; set; }
        public virtual User User { get; set; }
    }
}
