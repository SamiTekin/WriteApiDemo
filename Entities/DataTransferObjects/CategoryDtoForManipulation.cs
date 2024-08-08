using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public abstract record CategoryDtoForManipulation
    {
        [Required(ErrorMessage = "Bu alan boş geçilemez")]
        [MinLength(2, ErrorMessage = "Minimum 2 karakter olmalıdır.")]
        [MaxLength(100, ErrorMessage = "Maksimum 100 karakter olabilir.")]
        public string CategoryName { get; init; }

        [Required(ErrorMessage = "Bu alan boş geçilemez")]
        public string CategoryDescription { get; init; }
    }
}
