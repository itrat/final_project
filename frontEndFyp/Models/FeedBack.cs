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
    
    public partial class FeedBack
    {
        public FeedBack()
        {
            this.Event_Images = new HashSet<Event_Images>();
        }
    
        public string User_Name { get; set; }
        public string Comment { get; set; }
        public string User_Pic { get; set; }
        public Nullable<int> Restaurant_Id { get; set; }
        public int FeedBack_Id { get; set; }
        public int Ratings { get; set; }
        public string Image_Of_Event { get; set; }
    
        public virtual Restaurant Restaurant { get; set; }
        public virtual ICollection<Event_Images> Event_Images { get; set; }
    }
}
