using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InveonWebUI.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductBarcode { get; set; }
        public string ProductImageUrl { get; set; }
        public double ProductPrice { get; set; }
        public int ProductUnit { get; set; }
        public bool ProductIsActive { get; set; }
    }
}
