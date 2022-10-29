using System;
using System.Collections.Generic;

namespace SonQuangHuy.Models
{
    public partial class Blog
    {
        public int Id { get; set; }
        public string Avatar { get; set; } = null!;
        public string BlogTitle { get; set; } = null!;
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? Description { get; set; }
        public string? Details1 { get; set; }
        public string? Details2 { get; set; }
        public string? Details3 { get; set; }
        public string? Details4 { get; set; }
        public string? Details5 { get; set; }
        public string? Details6 { get; set; }
        public string? Details7 { get; set; }
        public string? Details8 { get; set; }
    }
}
