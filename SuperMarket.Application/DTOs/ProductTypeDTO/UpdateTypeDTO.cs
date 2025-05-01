using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Application.DTOs.ProductTypeDTO
{
    public class UpdateTypeDTO
    {
       
        [Required]
        public string TypeName { get; set; } = string.Empty;
    }
}
