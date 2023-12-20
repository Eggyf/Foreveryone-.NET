


using System.ComponentModel.DataAnnotations;
using Foreveryone.Validations;

namespace Foreveryone.Entities
{

    public class Player : IValidatableObject
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The {0} field is required")]
        [StringLength(maximumLength: 5, ErrorMessage = "El campo {0} no debe tener mas de {1} caracteres")]
        [FirstLetterCapital]
        public string Nombre { get; set; }
        public List<Warrior>? Warriors { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!string.IsNullOrEmpty(Nombre))
            {
                var firstLetter = Nombre[0].ToString();

                if (firstLetter != firstLetter.ToUpper())
                {
                    yield return new ValidationResult("the first letter must be capital",
                    new string[] { nameof(Nombre) });
                }
            }
        }
    }
}