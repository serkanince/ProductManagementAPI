using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain.Entites
{
    public abstract class BaseEntity
    {      
        [Required]
        public DateTime CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
