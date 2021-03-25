using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InveonWebUI.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Ürün Adı")]
        public string ProductName { get; set; }
        [Display(Name = "Barkod")]
        public string ProductBarcode { get; set; }
        [Display(Name = "Açıklama")]
        public string ProductDescryption { get; set; }
        public string ProductImageUrl { get; set; }
        [Display(Name = "Fiyat")]
        public double ProductPrice { get; set; }
        [Display(Name = "Adet")]
        public int ProductUnit { get; set; }
        public bool ProductIsActive { get; set; }
        public IFormFile ProductPhoto { get; set; }

    }
}
