using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class ProductToReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }  
        public string ProductType { get; set; } // will cause a slight problem in the auto mapper since the type dosen't really match
        public string ProductBrand { get; set; }  
    }
}