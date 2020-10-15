using System.ComponentModel.DataAnnotations;

namespace JWTAuthentication_Front.Models
{
    public class ProductAdd
    {
        [Required(ErrorMessage = "Ad alanı boş geçilemez")]
        public string Name { get; set; }
    }
}