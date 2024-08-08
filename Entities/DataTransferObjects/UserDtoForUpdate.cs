using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public record UserDtoForUpdate :UserDtoForManipulation
    {
        [Required(ErrorMessage = "Bu alan boş geçilemez")]
        public int Id { get; set; }
        public bool UserStatus { get; set; }
       // public ICollection<Product> Products { get; set; }
    }
}
