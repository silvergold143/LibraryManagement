using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagement.Models
{
    public class VMFooter
    {
        public int Id { get; set; }
        public string DisplayText { get; set; }
        public string LinkUrl { get; set; }
        public int SortOrder { get; set; }
    }
}