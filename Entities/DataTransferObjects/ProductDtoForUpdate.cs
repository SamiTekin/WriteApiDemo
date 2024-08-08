using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public record ProductDtoForUpdate : ProductDtoForManipulation
    {
        [Required(ErrorMessage = "Bu alan boş geçilemez")]
        public int Id { get; init; }
        public bool ProductType { get; init; }
    }
}
