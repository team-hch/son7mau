using System;
using System.Collections.Generic;

namespace SonQuangHuy.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = null!;
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? Details1 { get; set; }
        public string? Details2 { get; set; }
        public string? Details3 { get; set; }
        public string? Details4 { get; set; }
        public string? Details5 { get; set; }
        public string? Details6 { get; set; }
        public string? Details7 { get; set; }
        public string? Details8 { get; set; }
        public string Unit { get; set; }
        public double? Price { get; set; }
        // public int? Quantity { get; set; }
        // public int Sold { get; set; }
        public int Weight { get; set; }
        public string ProductType { get; set; } = null!;
        public string Avatar { get; set; } = null!;
        public string DetailsImage { get; set; } = null!;
        public int? Promotion { get; set; }
    }
}
