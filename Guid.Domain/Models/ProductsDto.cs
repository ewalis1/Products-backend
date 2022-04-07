using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain.Models
{
    public class ProductsDto
    {
        public System.Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [MaxLength(100)]
        public string Name { get; set; }

        public int Number { get; set; }

        public int Quantity { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        public decimal Price { get; set; }
    }
}
