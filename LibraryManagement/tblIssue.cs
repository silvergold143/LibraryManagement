//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibraryManagement
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblIssue
    {
        public int Id { get; set; }
        public Nullable<int> BooksId { get; set; }
        public Nullable<int> StudentId { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<System.DateTime> Renewal { get; set; }
        public Nullable<System.DateTime> Expiry { get; set; }
        public string Description { get; set; }
    
        public virtual tblBook tblBook { get; set; }
        public virtual tblStudent tblStudent { get; set; }
    }
}
