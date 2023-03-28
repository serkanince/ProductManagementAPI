using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain.Entites
{
    public class CategoryEntity : BaseEntity
    {
        [Key]
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string Name { get; set; }

        [Range(1, 1000)]
        [Required]
        public int MinimumStock { get; set; }

        public virtual IEnumerable<ProductEntity> Products { get; set; }
    }
}
