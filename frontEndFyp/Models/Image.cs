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
    
    public partial class Image
    {
        public int Images_Id { get; set; }
        public string Restaurant_Image { get; set; }
        public Nullable<int> Restaurant_Id { get; set; }
    
        public virtual Restaurant Restaurant { get; set; }
    }
}