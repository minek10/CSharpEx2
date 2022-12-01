using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.Data.Model
{
    public class User : BaseModel
    {
        [MaxLength(30, ErrorMessage ="Max 30 caractères autorisés")]
        [Required(ErrorMessage = "Le champ 'Nom' est obligatoire")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Le champ 'Prenom' est obligatoire")]
        [MaxLength(50, ErrorMessage ="Max 50 caractères autorisés")]
        public string LastName { get; set; } = string.Empty;


    }
}
