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
    
    public partial class Event_Images
    {
        public int Event_Images_Id { get; set; }
        public Nullable<int> Feedback_Id { get; set; }
        public string Event_images1 { get; set; }
    
        public virtual FeedBack FeedBack { get; set; }
    }
}
