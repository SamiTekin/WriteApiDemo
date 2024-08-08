using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public abstract record UserDtoForManipulation
    {
        [Required(ErrorMessage = "Bu alan boş geçilemez")]
        [MinLength(2, ErrorMessage = "Minimum 2 karakter olmalıdır.")]
        [MaxLength(30, ErrorMessage = "Maksimum 30 karakter olabilir.")]
        public string UserName { get; init; }

        [Required(ErrorMessage = "Bu alan boş geçilemez")]
        [MinLength(2, ErrorMessage = "Minimum 2 karakter olmalıdır.")]
        [MaxLength(30, ErrorMessage = "Maksimum 30 karakter olabilir.")]
        public string UserSurname { get; init; }

        [Required(ErrorMessage = "Bu alan boş geçilemez")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi olmalıdır")]
        public string Email { get; init; }

        [Required(ErrorMessage = "Bu alan boş geçilemez")]
        [MinLength(2, ErrorMessage = "Minimum 2 karakter olmalıdır.")]
        [MaxLength(30, ErrorMessage = "Maksimum 30 karakter olabilir.")]
        public string Password { get; init; }
    }
}
