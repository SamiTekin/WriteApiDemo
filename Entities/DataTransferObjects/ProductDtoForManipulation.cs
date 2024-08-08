using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public abstract record ProductDtoForManipulation
    {
        [Required(ErrorMessage ="Bu alan boş geçilemez")]
        [MinLength(2,ErrorMessage ="Minimum 2 karakter olmalıdır.")]
        [MaxLength(50, ErrorMessage ="Maksimum 50 karakter olabilir.")]
        public string ProductName { get; init; }

        [Required(ErrorMessage = "Bu alan boş geçilemez")]
        [MinLength(1,ErrorMessage ="Minimum 1 karakter olmalıdır.")]
        public string ProductDescription { get; init; }
        [Required(ErrorMessage = "Bu alan boş geçilemez")]
        [Range(10, 200000, ErrorMessage ="Fiyat 10-200000 arasında olabilir.")]
        public decimal ProductPrice { get; set; }
    }
}
