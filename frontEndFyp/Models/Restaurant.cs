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
    
    public partial class Restaurant
    {
        public Restaurant()
        {
            this.Events = new HashSet<Event>();
            this.FeedBacks = new HashSet<FeedBack>();
            this.Foods = new HashSet<Food>();
            this.Images = new HashSet<Image>();
            this.Reservations = new HashSet<Reservation>();
            this.Decorations = new HashSet<Decoration>();
            this.SoundSystems = new HashSet<SoundSystem>();
        }
    
        public int Restaurant_Id { get; set; }
        public string Restaurant_Name { get; set; }
        public string Restaurant_Address { get; set; }
        public string Time_In { get; set; }
        public string Time_Out { get; set; }
        public string Area { get; set; }
        public string Restaurant_Image { get; set; }
    
        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<FeedBack> FeedBacks { get; set; }
        public virtual ICollection<Food> Foods { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
        public virtual ICollection<Decoration> Decorations { get; set; }
        public virtual ICollection<SoundSystem> SoundSystems { get; set; }
    }
}
