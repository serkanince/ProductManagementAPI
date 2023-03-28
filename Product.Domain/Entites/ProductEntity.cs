using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain.Entites
{
    public class ProductEntity : BaseEntity
    {
        [Key]
        [Required]
        public int ProductId { get; set; }
        [MinLength(200)]
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public decimal Price { get; set; }
        [Required]
        public int Stock { get; set; }
        [Required]
        public int CategoryId { get; set; }

        public virtual CategoryEntity Category { get; set; }

    }
}
